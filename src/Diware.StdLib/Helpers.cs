using System;
using System.Collections.Generic;
using System.Text;

namespace Diware.SL
{
	internal static class Helpers
	{

		/// <summary>
		/// Returns a trimmed or empty string.
		/// </summary>
		/// <param name="value">The string value.</param>
		/// <returns>A string.</returns>
		public static string SetString(string value) => value?.Trim() ?? string.Empty;


		/// <summary>
		/// Returns a trimmed and cropped to <paramref name="maxLength"/> 
		/// symbols string, or empty string.
		/// </summary>
		/// <param name="value">The string value.</param>
		/// <param name="maxLength">The maximum length of string.</param>
		/// <returns>A string.</returns>
		public static string SetString(string value, int maxLength)
		{
			if (value == null)
			{
				return string.Empty;
			}
			else
			{
				value = value.Trim();
				return value.Substring(0, Math.Min(value.Length, maxLength));
			}
		}

	}
}
