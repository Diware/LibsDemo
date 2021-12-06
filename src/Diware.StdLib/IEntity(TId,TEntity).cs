using System;

namespace Diware.SL
{
	public interface IEntity<TId, TEntity>
		: IEntity<TId>, IEquatable<TEntity> 
		where TEntity : IEntity<TId, TEntity>
	{
	}
}
