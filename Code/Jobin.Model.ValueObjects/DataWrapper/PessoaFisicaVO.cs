namespace Jobin.Model.ValueObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class PessoaFisicaVO
	{
		[DataMember]
		public bool IsPersisted { get; set; }
		public bool IsRemoved { get; set; }

		[DataMember]
		public int? IdPessoaFisica { get; set; }

		[DataMember]
		public int? IdFornecedor { get; set; }

		[DataMember]
		public string CPF { get; set; }

		[DataMember]
		public int? IdFormacao { get; set; }

		[DataMember]
		public int? IdExperiencia { get; set; }

		#region Comparadores
		public static bool operator ==(PessoaFisicaVO a, PessoaFisicaVO b)
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
				resultEqual = resultEqual && ((a.IdPessoaFisica == null && b.IdPessoaFisica == null) || (a.IdPessoaFisica == b.IdPessoaFisica));
				resultEqual = resultEqual && ((a.IdFornecedor == null && b.IdFornecedor == null) || (a.IdFornecedor == b.IdFornecedor));
				resultEqual = resultEqual && ((a.CPF == null && b.CPF == null) || (a.CPF == b.CPF));
				resultEqual = resultEqual && ((a.IdFormacao == null && b.IdFormacao == null) || (a.IdFormacao == b.IdFormacao));
				resultEqual = resultEqual && ((a.IdExperiencia == null && b.IdExperiencia == null) || (a.IdExperiencia == b.IdExperiencia));
				return resultEqual;
			}
		}

		public static bool operator !=(PessoaFisicaVO a, PessoaFisicaVO b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			PessoaFisicaVO typedInstance = obj as PessoaFisicaVO;
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

	public class PessoaFisicaVOCollection : List<PessoaFisicaVO>
	{
		public int TotalRows { get; set; }
		public int? PageSize { get; set; }
	}
}
