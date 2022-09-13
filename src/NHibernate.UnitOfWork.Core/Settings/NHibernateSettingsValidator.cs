using System;
using System.Collections.Generic;

namespace NHibernate.UnitOfWork.Core.Settings
{
    public class NHibernateSettingsValidator
    {
        private readonly NHibernateSettings _settings;

        public NHibernateSettingsValidator(NHibernateSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public IDictionary<string, string> Validate()
        {
            var errors = new Dictionary<string, string>();

            if (_settings.Dialect == null)
                errors.Add(nameof(_settings.Dialect), "Dialect can not be empty.");

            return errors;
        }
    }
}
