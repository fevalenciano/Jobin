namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface IFormacoesDalc
	{
		void Insert(FormacoesVO formacoesVO);
		void Update(FormacoesVO formacoesVO);
		void Delete(int idFormacao);
		FormacoesVO Get(int idFormacao);
		FormacoesVOCollection GetAll();
		FormacoesVOCollection GetAllPaged(long startRowIndex, int maximumRows);
	}
}
