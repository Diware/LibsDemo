namespace Diware.SL.UnitTests.EntityT
{
	public class JustEntity<TId> 
		: Entity<TId>
	{
		public TId MyId
		{
			get => ((IEntity<TId>)this).Id;
			set => ((IEntity<TId>)this).Id = value;
		}

		public int Payload { get; set; }
	}
}
