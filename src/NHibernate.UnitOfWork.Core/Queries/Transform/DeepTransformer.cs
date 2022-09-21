using NHibernate.Transform;
using NHibernate.UnitOfWork.Core.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NHibernate.UnitOfWork.Core.Queries.Transform
{
    public sealed class DeepTransformer<TEntity> : IResultTransformer
        where TEntity : class
    {
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            try
            {
                var list = new List<string>(aliases);

                var propertyAliases = new List<string>(list);
                var complexAliases = new List<string>();

                for (var i = 0; i < list.Count; i++)
                {
                    var alias = list[i];

                    if (!alias.Contains('.'))
                        continue;

                    complexAliases.Add(alias);
                    propertyAliases[i] = null;
                }

                var result = Transformers
                    .AliasToBean<TEntity>()
                    .TransformTuple(tuple, propertyAliases.ToArray());

                TransformPersistentChain(tuple, complexAliases, result, list);

                return result;
            }
            catch (Exception exception)
            {
                throw new TransformException(
                    $"Error occured when transforming entity: {typeof(TEntity).Name}.", 
                    exception, 
                    ErrorCode.TransformError);
            }
        }

        public IList TransformList(IList collection)
        {
            var results = Transformers.AliasToBean<TEntity>().TransformList(collection);

            return results;
        }

#pragma warning disable S3011
        private static void TransformPersistentChain(
            object[] tuple,
            List<string> complexAliases,
            object result,
            List<string> list)
        {
            var entity = result as TEntity;

            foreach (var aliases in complexAliases)
            {
                var index = list.IndexOf(aliases);
                var value = tuple[index];

                if (value is null)
                    continue;

                var parts = aliases.Split('.');
                var name = parts[0];

                var propertyInfo = entity!
                    .GetType()
                    .GetProperty(name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

                object currentObject = entity;
                var current = 1;

                while (current < parts.Length)
                {
                    name = parts[current];

                    var instance = propertyInfo!.GetValue(currentObject);

                    if (instance is null)
                    {
                        var cons = propertyInfo.PropertyType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                        var noParamConstructor = cons.FirstOrDefault(c => c.IsFamilyOrAssembly);

                        instance = noParamConstructor?.Invoke(Array.Empty<object>());
                        propertyInfo.SetValue(currentObject, instance);
                    }

                    propertyInfo = propertyInfo.PropertyType.GetProperty(
                        name,

                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);


                    currentObject = instance;
                    current++;
                }

                if (currentObject is IDictionary dictionary)
                {
                    dictionary[name] = value;
                }
                else
                {
                    propertyInfo!.SetValue(currentObject, value);
                }
            }
        }
#pragma warning restore S3011
    }
}
