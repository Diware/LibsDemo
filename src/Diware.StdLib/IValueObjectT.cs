using System;

namespace Diware.SL
{

	public interface IValueObject<T> 
		: IValueObject, IEquatable<T> where T : IValueObject<T>
	{
	}

}
