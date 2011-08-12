namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface IPessoaFisicaDalc
	{
		void Insert(PessoaFisicaVO pessoaFisicaVO);
		void Update(PessoaFisicaVO pessoaFisicaVO);
		void Delete(int idPessoaFisica);
		PessoaFisicaVO Get(int idPessoaFisica);
		PessoaFisicaVOCollection GetAll();
		PessoaFisicaVOCollection GetAllPaged(long startRowIndex, int maximumRows);
		PessoaFisicaVOCollection GetByExperiencia(int idExperiencia);
		PessoaFisicaVOCollection GetByFormacoes(int idFormacao);
		PessoaFisicaVOCollection GetByFornecedores(int idFornecedor);
	}
}
