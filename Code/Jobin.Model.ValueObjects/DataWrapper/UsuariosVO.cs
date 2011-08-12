namespace Jobin.Model.ValueObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class UsuariosVO
	{
		[DataMember]
		public bool IsPersisted { get; set; }
		public bool IsRemoved { get; set; }

		[DataMember]
		public int? IdUsuario { get; set; }

		[DataMember]
		public string Email { get; set; }

		[DataMember]
		public string Senha { get; set; }

		[DataMember]
		public DateTime? DataInclusao { get; set; }

		[DataMember]
		public DateTime? DataAlteracao { get; set; }

		[DataMember]
		public string Nome { get; set; }

		[DataMember]
		public string Sobrenome { get; set; }

		#region Comparadores
		public static bool operator ==(UsuariosVO a, UsuariosVO b)
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
				resultEqual = resultEqual && ((a.IdUsuario == null && b.IdUsuario == null) || (a.IdUsuario == b.IdUsuario));
				resultEqual = resultEqual && ((a.Email == null && b.Email == null) || (a.Email == b.Email));
				resultEqual = resultEqual && ((a.Senha == null && b.Senha == null) || (a.Senha == b.Senha));
				resultEqual = resultEqual && ((a.DataInclusao == null && b.DataInclusao == null) || (a.DataInclusao == b.DataInclusao));
				resultEqual = resultEqual && ((a.DataAlteracao == null && b.DataAlteracao == null) || (a.DataAlteracao == b.DataAlteracao));
				resultEqual = resultEqual && ((a.Nome == null && b.Nome == null) || (a.Nome == b.Nome));
				resultEqual = resultEqual && ((a.Sobrenome == null && b.Sobrenome == null) || (a.Sobrenome == b.Sobrenome));
				return resultEqual;
			}
		}

		public static bool operator !=(UsuariosVO a, UsuariosVO b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			UsuariosVO typedInstance = obj as UsuariosVO;
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

	public class UsuariosVOCollection : List<UsuariosVO>
	{
		public int TotalRows { get; set; }
		public int? PageSize { get; set; }
	}
}
