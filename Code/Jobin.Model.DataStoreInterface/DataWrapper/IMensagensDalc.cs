namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface IMensagensDalc
	{
		void Insert(MensagensVO mensagensVO);
		void Update(MensagensVO mensagensVO);
		void Delete(int idMensagem);
		MensagensVO Get(int idMensagem);
		MensagensVOCollection GetAll();
		MensagensVOCollection GetAllPaged(long startRowIndex, int maximumRows);
		MensagensVOCollection GetByOportunidades(int idUsuarioDestino);
		MensagensVOCollection GetByUsuarios(int idUsuarioOrigem);
	}
}
