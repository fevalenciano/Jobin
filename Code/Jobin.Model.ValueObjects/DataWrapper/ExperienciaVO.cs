namespace Jobin.Model.ValueObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class ExperienciaVO
	{
		[DataMember]
		public bool IsPersisted { get; set; }
		public bool IsRemoved { get; set; }

		[DataMember]
		public int? IdExperiencia { get; set; }

		[DataMember]
		public string Funcao { get; set; }

		[DataMember]
		public string Descricao { get; set; }

		[DataMember]
		public DateTime? PeriodoDe { get; set; }

		[DataMember]
		public DateTime? PeriodoAte { get; set; }

		[DataMember]
		public string Empresa { get; set; }

		#region Comparadores
		public static bool operator ==(ExperienciaVO a, ExperienciaVO b)
		{
			if ( Object.ReferenceEquals(a, b)) // Optimization for a common success case.
				return true;
			else if (Object.ReferenceEquals(a, null) ^ Object.ReferenceEquals(b, null))
				return false;
			else if (Object.ReferenceEquals(a, null) && Object.ReferenceEquals(b, null))
				return true;
			else
			{
				bool resultEqual = true;
				resultEqual = resultEqual && ((a.IdExperiencia == null && b.IdExperiencia == null) || (a.IdExperiencia == b.IdExperiencia));
				resultEqual = resultEqual && ((a.Funcao == null && b.Funcao == null) || (a.Funcao == b.Funcao));
				resultEqual = resultEqual && ((a.Descricao == null && b.Descricao == null) || (a.Descricao == b.Descricao));
				resultEqual = resultEqual && ((a.PeriodoDe == null && b.PeriodoDe == null) || (a.PeriodoDe == b.PeriodoDe));
				resultEqual = resultEqual && ((a.PeriodoAte == null && b.PeriodoAte == null) || (a.PeriodoAte == b.PeriodoAte));
				resultEqual = resultEqual && ((a.Empresa == null && b.Empresa == null) || (a.Empresa == b.Empresa));
				return resultEqual;
			}
		}

		public static bool operator !=(ExperienciaVO a, ExperienciaVO b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			ExperienciaVO typedInstance = obj as ExperienciaVO;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}

 		public int GetHashCode(Object obj)
 		{
  			return obj.GetHashCode();
 		}

		#endregion
	}

	public class ExperienciaVOCollection : List<ExperienciaVO>
	{
		public int TotalRows { get; set; }
		public int? PageSize { get; set; }
	}
}
