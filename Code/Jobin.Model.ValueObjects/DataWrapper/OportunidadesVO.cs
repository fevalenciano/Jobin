namespace Jobin.Model.ValueObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class OportunidadesVO
	{
		[DataMember]
		public bool IsPersisted { get; set; }
		public bool IsRemoved { get; set; }

		[DataMember]
		public int? IdOportunidade { get; set; }

		[DataMember]
		public int? IdCategoria { get; set; }

		[DataMember]
		public int? IdMensagem { get; set; }

		[DataMember]
		public int? IdFornecedor { get; set; }

		[DataMember]
		public int? IdAvaliacao { get; set; }

		[DataMember]
		public string Titulo { get; set; }

		[DataMember]
		public string Subtitulo { get; set; }

		[DataMember]
		public string Descricao { get; set; }

		[DataMember]
		public int? IdDestaque { get; set; }

		[DataMember]
		public string GoogleMaps { get; set; }

		[DataMember]
		public string ImagemVideo { get; set; }

		#region Comparadores
		public static bool operator ==(OportunidadesVO a, OportunidadesVO b)
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
				resultEqual = resultEqual && ((a.IdOportunidade == null && b.IdOportunidade == null) || (a.IdOportunidade == b.IdOportunidade));
				resultEqual = resultEqual && ((a.IdCategoria == null && b.IdCategoria == null) || (a.IdCategoria == b.IdCategoria));
				resultEqual = resultEqual && ((a.IdMensagem == null && b.IdMensagem == null) || (a.IdMensagem == b.IdMensagem));
				resultEqual = resultEqual && ((a.IdFornecedor == null && b.IdFornecedor == null) || (a.IdFornecedor == b.IdFornecedor));
				resultEqual = resultEqual && ((a.IdAvaliacao == null && b.IdAvaliacao == null) || (a.IdAvaliacao == b.IdAvaliacao));
				resultEqual = resultEqual && ((a.Titulo == null && b.Titulo == null) || (a.Titulo == b.Titulo));
				resultEqual = resultEqual && ((a.Subtitulo == null && b.Subtitulo == null) || (a.Subtitulo == b.Subtitulo));
				resultEqual = resultEqual && ((a.Descricao == null && b.Descricao == null) || (a.Descricao == b.Descricao));
				resultEqual = resultEqual && ((a.IdDestaque == null && b.IdDestaque == null) || (a.IdDestaque == b.IdDestaque));
				resultEqual = resultEqual && ((a.GoogleMaps == null && b.GoogleMaps == null) || (a.GoogleMaps == b.GoogleMaps));
				resultEqual = resultEqual && ((a.ImagemVideo == null && b.ImagemVideo == null) || (a.ImagemVideo == b.ImagemVideo));
				return resultEqual;
			}
		}

		public static bool operator !=(OportunidadesVO a, OportunidadesVO b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			OportunidadesVO typedInstance = obj as OportunidadesVO;
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

	public class OportunidadesVOCollection : List<OportunidadesVO>
	{
		public int TotalRows { get; set; }
		public int? PageSize { get; set; }
	}
}
