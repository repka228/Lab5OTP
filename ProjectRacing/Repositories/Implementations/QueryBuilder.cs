using System.Text;
namespace ProjectRacing.Repositories.Implementations
{
    public class QueryBuilder
    {
        private readonly StringBuilder _builder;
        public QueryBuilder()
        {
            _builder = new();
        }
        public QueryBuilder AddCondition(string condition)
        {
            if (_builder.Length > 0)
            {
                _builder.Append(" AND ");
            }
            _builder.Append(condition);
            return this;
        }
        public string Build()
        {
            if (_builder.Length == 0)
            {
                return string.Empty;
            }
            return $"WHERE {_builder}";
        }
    }
}