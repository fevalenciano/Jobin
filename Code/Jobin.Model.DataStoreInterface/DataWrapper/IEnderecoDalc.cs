namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface IEnderecoDalc
	{
		void Insert(EnderecoVO enderecoVO);
		void Update(EnderecoVO enderecoVO);
		void Delete(int idEndereco);
		EnderecoVO Get(int idEndereco);
		EnderecoVOCollection GetAll();
		EnderecoVOCollection GetAllPaged(long startRowIndex, int maximumRows);
	}
}
