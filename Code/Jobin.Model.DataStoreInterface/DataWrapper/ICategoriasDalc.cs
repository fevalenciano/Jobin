namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface ICategoriasDalc
	{
		CategoriasVO Insert(CategoriasVO categoriasVO);
		void Update(CategoriasVO categoriasVO);
		void Delete(int idCategoria);
		CategoriasVO Get(int idCategoria);
		CategoriasVOCollection GetAll();
		CategoriasVOCollection GetAllPaged(long startRowIndex, int maximumRows);
		CategoriasVOCollection GetBySegmentos(int idSegmento);
	}
}
