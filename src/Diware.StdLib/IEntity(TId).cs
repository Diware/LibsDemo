namespace Diware.SL
{
	public interface IEntity<TId>
		: IEntity
	{
		TId Id { get; set; }
	}
}
