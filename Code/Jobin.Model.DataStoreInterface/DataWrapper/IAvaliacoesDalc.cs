namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface IAvaliacoesDalc
	{
		void Insert(AvaliacoesVO avaliacoesVO);
		void Update(AvaliacoesVO avaliacoesVO);
		void Delete(int idAvaliacao);
		AvaliacoesVO Get(int idAvaliacao);
		AvaliacoesVOCollection GetAll();
		AvaliacoesVOCollection GetAllPaged(long startRowIndex, int maximumRows);
		AvaliacoesVOCollection GetByUsuarios(int idUsuario);
	}
}
