namespace Jobin.Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;

	public static class NameConvert
	{
		private static Dictionary<string, string> dictionary = null;

		public static string GetName(string key)
		{
			string value = key;
			LoadDictionary();

			if (dictionary.ContainsKey(key))
				value = dictionary[key];

			return value;
		}

		private static void LoadDictionary()
		{
			if (dictionary == null)
			{
				dictionary = new Dictionary<string, string>();
				dictionary.Add("Avaliacoes.IdAvaliacao", "Avaliacoes.IdAvaliacao");
				dictionary.Add("Avaliacoes.IdUsuario", "Avaliacoes.IdUsuario");
				dictionary.Add("Avaliacoes.TipoAvaliacao", "Avaliacoes.TipoAvaliacao");
				dictionary.Add("Avaliacoes.DataAvaliacao", "Avaliacoes.DataAvaliacao");
				dictionary.Add("Categorias.IdCategoria", "Categorias.IdCategoria");
				dictionary.Add("Categorias.IdSegmento", "Categorias.IdSegmento");
				dictionary.Add("Categorias.Nome", "Categorias.Nome");
				dictionary.Add("Destaques.IdDestaque", "Destaques.IdDestaque");
				dictionary.Add("Destaques.Destaque", "Destaques.Destaque");
				dictionary.Add("Destaques.DescricaoSimples", "Destaques.DescricaoSimples");
				dictionary.Add("Destaques.DescricaoComplexa", "Destaques.DescricaoComplexa");
				dictionary.Add("Endereco.IdEndereco", "Endereco.IdEndereco");
				dictionary.Add("Endereco.Logradouro", "Endereco.Logradouro");
				dictionary.Add("Endereco.Complemento", "Endereco.Complemento");
				dictionary.Add("Endereco.Numero", "Endereco.Numero");
				dictionary.Add("Endereco.Estado", "Endereco.Estado");
				dictionary.Add("Endereco.Cidade", "Endereco.Cidade");
				dictionary.Add("Endereco.CEP", "Endereco.CEP");
				dictionary.Add("Endereco.Bairro", "Endereco.Bairro");
				dictionary.Add("Experiencia.IdExperiencia", "Experiencia.IdExperiencia");
				dictionary.Add("Experiencia.Funcao", "Experiencia.Funcao");
				dictionary.Add("Experiencia.Descricao", "Experiencia.Descricao");
				dictionary.Add("Experiencia.PeriodoDe", "Experiencia.PeriodoDe");
				dictionary.Add("Experiencia.PeriodoAte", "Experiencia.PeriodoAte");
				dictionary.Add("Experiencia.Empresa", "Experiencia.Empresa");
				dictionary.Add("Formacoes.IdFormacao", "Formacoes.IdFormacao");
				dictionary.Add("Formacoes.Curso", "Formacoes.Curso");
				dictionary.Add("Formacoes.Descricao", "Formacoes.Descricao");
				dictionary.Add("Formacoes.Instituicao", "Formacoes.Instituicao");
				dictionary.Add("Formacoes.PeridoDe", "Formacoes.PeridoDe");
				dictionary.Add("Formacoes.PeriodoAte", "Formacoes.PeriodoAte");
				dictionary.Add("Fornecedores.IdFornecedor", "Fornecedores.IdFornecedor");
				dictionary.Add("Fornecedores.IdUsuario", "Fornecedores.IdUsuario");
				dictionary.Add("Fornecedores.IdEndereco", "Fornecedores.IdEndereco");
				dictionary.Add("Mensagens.IdMensagem", "Mensagens.IdMensagem");
				dictionary.Add("Mensagens.Mensagem", "Mensagens.Mensagem");
				dictionary.Add("Mensagens.IdUsuarioOrigem", "Mensagens.IdUsuarioOrigem");
				dictionary.Add("Mensagens.IdUsuarioDestino", "Mensagens.IdUsuarioDestino");
				dictionary.Add("Oportunidades.IdOportunidade", "Oportunidades.IdOportunidade");
				dictionary.Add("Oportunidades.IdCategoria", "Oportunidades.IdCategoria");
				dictionary.Add("Oportunidades.IdMensagem", "Oportunidades.IdMensagem");
				dictionary.Add("Oportunidades.IdFornecedor", "Oportunidades.IdFornecedor");
				dictionary.Add("Oportunidades.IdAvaliacao", "Oportunidades.IdAvaliacao");
				dictionary.Add("Oportunidades.Titulo", "Oportunidades.Titulo");
				dictionary.Add("Oportunidades.Subtitulo", "Oportunidades.Subtitulo");
				dictionary.Add("Oportunidades.Descricao", "Oportunidades.Descricao");
				dictionary.Add("Oportunidades.IdDestaque", "Oportunidades.IdDestaque");
				dictionary.Add("Oportunidades.GoogleMaps", "Oportunidades.GoogleMaps");
				dictionary.Add("Oportunidades.ImagemVideo", "Oportunidades.ImagemVideo");
				dictionary.Add("PessoaFisica.IdPessoaFisica", "PessoaFisica.IdPessoaFisica");
				dictionary.Add("PessoaFisica.IdFornecedor", "PessoaFisica.IdFornecedor");
				dictionary.Add("PessoaFisica.CPF", "PessoaFisica.CPF");
				dictionary.Add("PessoaFisica.IdFormacao", "PessoaFisica.IdFormacao");
				dictionary.Add("PessoaFisica.IdExperiencia", "PessoaFisica.IdExperiencia");
				dictionary.Add("PessoaJuridica.IdPessoaJuridica", "PessoaJuridica.IdPessoaJuridica");
				dictionary.Add("PessoaJuridica.IdFornecedor", "PessoaJuridica.IdFornecedor");
				dictionary.Add("PessoaJuridica.CNPJ", "PessoaJuridica.CNPJ");
				dictionary.Add("PessoaJuridica.RazaoSocial", "PessoaJuridica.RazaoSocial");
				dictionary.Add("PessoaJuridica.Site", "PessoaJuridica.Site");
				dictionary.Add("PessoaJuridica.Responsavel", "PessoaJuridica.Responsavel");
				dictionary.Add("Segmentos.IdSegmento", "Segmentos.IdSegmento");
				dictionary.Add("Segmentos.Nome", "Segmentos.Nome");
				dictionary.Add("Telefones.IdTelefone", "Telefones.IdTelefone");
				dictionary.Add("Telefones.IdUsuario", "Telefones.IdUsuario");
				dictionary.Add("Telefones.Telefone", "Telefones.Telefone");
				dictionary.Add("Usuarios.IdUsuario", "Usuarios.IdUsuario");
				dictionary.Add("Usuarios.Email", "Usuarios.Email");
				dictionary.Add("Usuarios.Senha", "Usuarios.Senha");
				dictionary.Add("Usuarios.DataInclusao", "Usuarios.DataInclusao");
				dictionary.Add("Usuarios.DataAlteracao", "Usuarios.DataAlteracao");
				dictionary.Add("Usuarios.Nome", "Usuarios.Nome");
				dictionary.Add("Usuarios.Sobrenome", "Usuarios.Sobrenome");
			}
		}
	}
}
