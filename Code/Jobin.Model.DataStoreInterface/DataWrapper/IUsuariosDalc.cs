namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface IUsuariosDalc
	{
		UsuariosVO Insert(UsuariosVO usuariosVO);
		void Update(UsuariosVO usuariosVO);
		void Delete(int idUsuario);
		UsuariosVO Get(int idUsuario);
		UsuariosVOCollection GetAll();
		UsuariosVOCollection GetAllPaged(long startRowIndex, int maximumRows);
	}
}
