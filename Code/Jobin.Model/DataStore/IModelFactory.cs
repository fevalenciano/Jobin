using System;
namespace Jobin.Model.DataStore
{
	public interface IModelFactory
	{
		IDataStore Resolve<IDataStore>();
	}
}
