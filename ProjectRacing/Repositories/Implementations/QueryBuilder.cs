using System.Text;
namespace ProjectRacing.Repositories.Implementations
{
    /// <summary>
    /// Класс для созданий запроса к БД
    /// </summary>
    public class QueryBuilder
    {
        /// <summary>
        /// Строка запроса к БД
        /// </summary>
        private readonly StringBuilder _builder;
        /// <summary>
        /// Конструктор класса создания запроса к БД
        /// </summary>
        public QueryBuilder() => _builder = new();      
        /// <summary>
        /// Добавление данных к запросу
        /// </summary>
        /// <param name="condition">Текст запроса</param>
        /// <returns>Возвращает полученный запрос</returns>
        public QueryBuilder AddCondition(string condition)
        {
            if (_builder.Length > 0) _builder.Append(" AND ");
            _builder.Append(condition);
            return this;
        }
        /// <summary>
        /// Построение запроса
        /// </summary>
        /// <returns>Возвращает конечный запрос</returns>
        public string Build()
        {
            if (_builder.Length == 0) return string.Empty;           
            return $"WHERE {_builder}";
        }
    }
}