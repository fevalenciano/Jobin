using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Jobin.Model.ValueObjects;
using Jobin.Model;

namespace Jobin.Model.WebSite.Controllers
{
	public class PessoaJuridicaController : Controller
	{
		private const string MENSAGEM_INCLUSAO = "Registro inserido com sucesso!";
		private const string MENSAGEM_ALTERACAO = "Registro alterado com sucesso!";
		private const string MENSAGEM_EXCLUSAO = "Registro removido com sucesso!";
		private const string MENSAGEM_CAMPOS_OBRIGATORIOS = "Os campos marcados com * são obrigatórios";

		public ActionResult Index()
		{
			PessoaJuridicaCollection lista = PessoaJuridica.FactoryInstance.GetAll();

			return View(lista);
		}

		public ActionResult Create()
		{
			return View();
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Create(PessoaJuridica objeto)
		{
			try
			{
				PessoaJuridica.TransactionInstance.Save(objeto);
				
				return RedirectToAction("Index", new { displayMessage = MENSAGEM_INCLUSAO });
			}
			catch (ApplicationException ex)
			{
				string[] campos = ex.Message.Split(',');
				ModelState.AddModelError(string.Empty, MENSAGEM_CAMPOS_OBRIGATORIOS);
				foreach (string campo in campos)
				{
					ModelState[campo].Errors.Add(ex);
				}

				return View(objeto);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);

				return View(objeto);
			}
		}

		public ActionResult Edit(int IdPessoaJuridica)
		{
			PessoaJuridica objeto = PessoaJuridica.FactoryInstance.Get(IdPessoaJuridica);

			return View(objeto);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit(PessoaJuridica objeto)
		{
			try
			{
				PessoaJuridica.TransactionInstance.Save(objeto);
				
				return RedirectToAction("Index", new { displayMessage = MENSAGEM_ALTERACAO });
			}
			catch (ApplicationException ex)
			{
				string[] campos = ex.Message.Split(',');
				ModelState.AddModelError(string.Empty, MENSAGEM_CAMPOS_OBRIGATORIOS);
				foreach (string campo in campos)
				{
					ModelState[campo].Errors.Add(ex);
				}

				return View(objeto);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);

				return View(objeto);
			}
		}

		public ActionResult Details(int IdPessoaJuridica)
		{
			PessoaJuridica objeto = PessoaJuridica.FactoryInstance.Get(IdPessoaJuridica);

			return View(objeto);
		}

		public ActionResult Remove(int IdPessoaJuridica)
		{
			PessoaJuridica objeto = PessoaJuridica.FactoryInstance.Get(IdPessoaJuridica);

			return View(objeto);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Remove(PessoaJuridica objeto)
		{
				PessoaJuridica.TransactionInstance.Remove(objeto);

			return RedirectToAction("Index", new { displayMessage = MENSAGEM_EXCLUSAO });
		}
	}
}
