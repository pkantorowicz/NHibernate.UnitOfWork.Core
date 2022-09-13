namespace NHibernate.UnitOfWork.Core.Queries
{
    public abstract class SearchableFilter
    {
        private readonly string _search;

        public string Search
        {
            get => !string.IsNullOrEmpty(_search) && _search.Length >= 3 ? _search : null;
            init => _search = value;
        }
    }
}
