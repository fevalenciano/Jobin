namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface IDestaquesDalc
	{
		void Insert(DestaquesVO destaquesVO);
		void Update(DestaquesVO destaquesVO);
		void Delete(int idDestaque);
		DestaquesVO Get(int idDestaque);
		DestaquesVOCollection GetAll();
		DestaquesVOCollection GetAllPaged(long startRowIndex, int maximumRows);
	}
}
