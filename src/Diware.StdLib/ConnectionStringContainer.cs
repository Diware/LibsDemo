using System;
using System.Collections.Generic;
using System.Text;

namespace Diware.SL
{
	public class ConnectionStringContainer
		: IConnectionStringContainer
	{

		private string m_ConnString = string.Empty;

		public ConnectionStringContainer()
		{

		}

		public ConnectionStringContainer(string connectionString)
		{
			SetConnectionString(connectionString);
		}

		string IConnectionStringContainer.ConnectionString
		{
			get => m_ConnString;
		}

		public void SetConnectionString(string connectionString)
		{
			if (string.IsNullOrWhiteSpace(connectionString))
				throw new ArgumentException("Connection string must be non-empty.", nameof(connectionString));

			m_ConnString = connectionString;
		}
	}
}
