namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface IFornecedoresDalc
	{
		void Insert(FornecedoresVO fornecedoresVO);
		void Update(FornecedoresVO fornecedoresVO);
		void Delete(int idFornecedor);
		FornecedoresVO Get(int idFornecedor);
		FornecedoresVOCollection GetAll();
		FornecedoresVOCollection GetAllPaged(long startRowIndex, int maximumRows);
		FornecedoresVOCollection GetByEndereco(int idEndereco);
		FornecedoresVOCollection GetByUsuarios(int idUsuario);
	}
}
