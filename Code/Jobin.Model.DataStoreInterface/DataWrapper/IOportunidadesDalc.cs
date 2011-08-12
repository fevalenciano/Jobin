namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface IOportunidadesDalc
	{
		void Insert(OportunidadesVO oportunidadesVO);
		void Update(OportunidadesVO oportunidadesVO);
		void Delete(int idOportunidade);
		OportunidadesVO Get(int idOportunidade);
		OportunidadesVOCollection GetAll();
		OportunidadesVOCollection GetAllPaged(long startRowIndex, int maximumRows);
		OportunidadesVOCollection GetByAvaliacoes(int idAvaliacao);
		OportunidadesVOCollection GetByCategorias(int idCategoria);
		OportunidadesVOCollection GetByDestaques(int idDestaque);
		OportunidadesVOCollection GetByFornecedores(int idFornecedor);
		OportunidadesVOCollection GetByMensagens(int idMensagem);
	}
}
