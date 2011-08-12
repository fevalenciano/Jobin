namespace Jobin.Model.ValueObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class PessoaJuridicaVO
	{
		[DataMember]
		public bool IsPersisted { get; set; }
		public bool IsRemoved { get; set; }

		[DataMember]
		public int? IdPessoaJuridica { get; set; }

		[DataMember]
		public int? IdFornecedor { get; set; }

		[DataMember]
		public string CNPJ { get; set; }

		[DataMember]
		public string RazaoSocial { get; set; }

		[DataMember]
		public string Site { get; set; }

		[DataMember]
		public string Responsavel { get; set; }

		#region Comparadores
		public static bool operator ==(PessoaJuridicaVO a, PessoaJuridicaVO b)
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
				resultEqual = resultEqual && ((a.IdPessoaJuridica == null && b.IdPessoaJuridica == null) || (a.IdPessoaJuridica == b.IdPessoaJuridica));
				resultEqual = resultEqual && ((a.IdFornecedor == null && b.IdFornecedor == null) || (a.IdFornecedor == b.IdFornecedor));
				resultEqual = resultEqual && ((a.CNPJ == null && b.CNPJ == null) || (a.CNPJ == b.CNPJ));
				resultEqual = resultEqual && ((a.RazaoSocial == null && b.RazaoSocial == null) || (a.RazaoSocial == b.RazaoSocial));
				resultEqual = resultEqual && ((a.Site == null && b.Site == null) || (a.Site == b.Site));
				resultEqual = resultEqual && ((a.Responsavel == null && b.Responsavel == null) || (a.Responsavel == b.Responsavel));
				return resultEqual;
			}
		}

		public static bool operator !=(PessoaJuridicaVO a, PessoaJuridicaVO b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			PessoaJuridicaVO typedInstance = obj as PessoaJuridicaVO;
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

	public class PessoaJuridicaVOCollection : List<PessoaJuridicaVO>
	{
		public int TotalRows { get; set; }
		public int? PageSize { get; set; }
	}
}
