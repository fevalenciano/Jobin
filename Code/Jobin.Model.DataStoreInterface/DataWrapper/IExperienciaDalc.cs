namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface IExperienciaDalc
	{
		void Insert(ExperienciaVO experienciaVO);
		void Update(ExperienciaVO experienciaVO);
		void Delete(int idExperiencia);
		ExperienciaVO Get(int idExperiencia);
		ExperienciaVOCollection GetAll();
		ExperienciaVOCollection GetAllPaged(long startRowIndex, int maximumRows);
	}
}
