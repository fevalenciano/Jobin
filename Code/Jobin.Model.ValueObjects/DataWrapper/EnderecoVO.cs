namespace Jobin.Model.ValueObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class EnderecoVO
	{
		[DataMember]
		public bool IsPersisted { get; set; }
		public bool IsRemoved { get; set; }

		[DataMember]
		public int? IdEndereco { get; set; }

		[DataMember]
		public string Logradouro { get; set; }

		[DataMember]
		public string Complemento { get; set; }

		[DataMember]
		public string Numero { get; set; }

		[DataMember]
		public string Estado { get; set; }

		[DataMember]
		public string Cidade { get; set; }

		[DataMember]
		public string CEP { get; set; }

		[DataMember]
		public string Bairro { get; set; }

		#region Comparadores
		public static bool operator ==(EnderecoVO a, EnderecoVO b)
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
				resultEqual = resultEqual && ((a.IdEndereco == null && b.IdEndereco == null) || (a.IdEndereco == b.IdEndereco));
				resultEqual = resultEqual && ((a.Logradouro == null && b.Logradouro == null) || (a.Logradouro == b.Logradouro));
				resultEqual = resultEqual && ((a.Complemento == null && b.Complemento == null) || (a.Complemento == b.Complemento));
				resultEqual = resultEqual && ((a.Numero == null && b.Numero == null) || (a.Numero == b.Numero));
				resultEqual = resultEqual && ((a.Estado == null && b.Estado == null) || (a.Estado == b.Estado));
				resultEqual = resultEqual && ((a.Cidade == null && b.Cidade == null) || (a.Cidade == b.Cidade));
				resultEqual = resultEqual && ((a.CEP == null && b.CEP == null) || (a.CEP == b.CEP));
				resultEqual = resultEqual && ((a.Bairro == null && b.Bairro == null) || (a.Bairro == b.Bairro));
				return resultEqual;
			}
		}

		public static bool operator !=(EnderecoVO a, EnderecoVO b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			EnderecoVO typedInstance = obj as EnderecoVO;
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

	public class EnderecoVOCollection : List<EnderecoVO>
	{
		public int TotalRows { get; set; }
		public int? PageSize { get; set; }
	}
}
