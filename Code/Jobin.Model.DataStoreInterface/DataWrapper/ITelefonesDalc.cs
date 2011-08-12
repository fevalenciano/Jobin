namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface ITelefonesDalc
	{
		void Insert(TelefonesVO telefonesVO);
		void Update(TelefonesVO telefonesVO);
		void Delete(int idTelefone);
		TelefonesVO Get(int idTelefone);
		TelefonesVOCollection GetAll();
		TelefonesVOCollection GetAllPaged(long startRowIndex, int maximumRows);
		TelefonesVOCollection GetByUsuarios(int idUsuario);
	}
}
