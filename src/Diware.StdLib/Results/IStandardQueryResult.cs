namespace Diware.SL.Results
{
    /// <summary>
    /// A query result which has only outcomes, defined in 
    /// <see cref="StandardQueryResultType"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStandardQueryResult<out T>
        : IQueryResult<T, StandardQueryResultType>
    {
    }
}
