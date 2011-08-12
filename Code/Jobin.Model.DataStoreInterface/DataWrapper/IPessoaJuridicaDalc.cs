namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface IPessoaJuridicaDalc
	{
		void Insert(PessoaJuridicaVO pessoaJuridicaVO);
		void Update(PessoaJuridicaVO pessoaJuridicaVO);
		void Delete(int idPessoaJuridica);
		PessoaJuridicaVO Get(int idPessoaJuridica);
		PessoaJuridicaVOCollection GetAll();
		PessoaJuridicaVOCollection GetAllPaged(long startRowIndex, int maximumRows);
		PessoaJuridicaVOCollection GetByFornecedores(int idFornecedor);
	}
}
