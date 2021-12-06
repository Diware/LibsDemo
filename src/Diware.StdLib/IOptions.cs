using System;
using System.Collections.Generic;
using System.Text;

namespace Diware.SL
{
	/// <summary>
	/// Represents options data object with validation.
	/// </summary>
	public interface IOptions
	{

		/// <summary>
		/// Validates options object and if it is misconfigured - throws
		/// <see cref="Exceptions.OptionsException"/>.
		/// </summary>
		void Validate();

	}
}
