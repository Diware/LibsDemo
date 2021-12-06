using System;
using System.Collections.Generic;
using System.Text;

namespace Diware.SL
{

	/// <summary>
	/// Implementer determines if it contains only empty data.
	/// </summary>
	public interface IEmptyDataTester
	{

		/// <summary>
		/// Determines if object has only empty data.
		/// </summary>
		/// 
		/// <returns>
		/// If all the data properties are empty - <c>true</c>,
		/// if at least one data property is not empty - <c>false</c>.
		/// </returns>
		/// 
		/// <remarks>
		/// <para>
		/// Data is considered empty by application logic, not by data types.
		/// </para>
		/// 
		/// <para>
		/// For example: if some property contains a name of book and it is formatted 
		/// as "name={}", then value "name=Mathematics" is considered as not empty, 
		/// but value "name=" is considered empty. This is so because "name=" is a 
		/// part of format, not data. It is opposite to data type definition of 
		/// empty, as "name=" is not an empty string.
		/// </para>
		/// </remarks>
		bool IsEmpty();

	}

}
