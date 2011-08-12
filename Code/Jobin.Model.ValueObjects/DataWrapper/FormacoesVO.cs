namespace Jobin.Model.ValueObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class FormacoesVO
	{
		[DataMember]
		public bool IsPersisted { get; set; }
		public bool IsRemoved { get; set; }

		[DataMember]
		public int? IdFormacao { get; set; }

		[DataMember]
		public string Curso { get; set; }

		[DataMember]
		public string Descricao { get; set; }

		[DataMember]
		public string Instituicao { get; set; }

		[DataMember]
		public DateTime? PeridoDe { get; set; }

		[DataMember]
		public DateTime? PeriodoAte { get; set; }

		#region Comparadores
		public static bool operator ==(FormacoesVO a, FormacoesVO b)
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
				resultEqual = resultEqual && ((a.IdFormacao == null && b.IdFormacao == null) || (a.IdFormacao == b.IdFormacao));
				resultEqual = resultEqual && ((a.Curso == null && b.Curso == null) || (a.Curso == b.Curso));
				resultEqual = resultEqual && ((a.Descricao == null && b.Descricao == null) || (a.Descricao == b.Descricao));
				resultEqual = resultEqual && ((a.Instituicao == null && b.Instituicao == null) || (a.Instituicao == b.Instituicao));
				resultEqual = resultEqual && ((a.PeridoDe == null && b.PeridoDe == null) || (a.PeridoDe == b.PeridoDe));
				resultEqual = resultEqual && ((a.PeriodoAte == null && b.PeriodoAte == null) || (a.PeriodoAte == b.PeriodoAte));
				return resultEqual;
			}
		}

		public static bool operator !=(FormacoesVO a, FormacoesVO b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			FormacoesVO typedInstance = obj as FormacoesVO;
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

	public class FormacoesVOCollection : List<FormacoesVO>
	{
		public int TotalRows { get; set; }
		public int? PageSize { get; set; }
	}
}
