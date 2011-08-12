namespace Jobin.Model.DataStore
{
	using System;
	using Microsoft.Practices.EnterpriseLibrary.Data;
	using System.Configuration;

	public static partial class ConnectionFactory
	{
		public static Database CreateDatabase(string databaseName)
		{
			Database db = null;
			if(System.Configuration.ConfigurationManager.ConnectionStrings[databaseName] != null)
			{
				db = DatabaseFactory.CreateDatabase(databaseName);
			}
			else
			{
				db = CreateCustomConnection(databaseName);
			}
			if (db == null) throw new ApplicationException("A base de dados '" + databaseName + "' não está configurada!");

			return db;
		}

		private static GenericDatabase CreateCustomConnection(string databaseName)
		{
			GenericDatabase genericDatabase = null;
			LoadCustomConnection(databaseName, ref genericDatabase);
			return genericDatabase;
		}
		static partial void LoadCustomConnection(string databaseName, ref GenericDatabase genericDatabase);
	}
}
