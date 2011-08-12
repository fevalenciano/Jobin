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
	public class PessoaFisicaController : Controller
	{
		private const string MENSAGEM_INCLUSAO = "Registro inserido com sucesso!";
		private const string MENSAGEM_ALTERACAO = "Registro alterado com sucesso!";
		private const string MENSAGEM_EXCLUSAO = "Registro removido com sucesso!";
		private const string MENSAGEM_CAMPOS_OBRIGATORIOS = "Os campos marcados com * são obrigatórios";

		public ActionResult Index()
		{
			PessoaFisicaCollection lista = PessoaFisica.FactoryInstance.GetAll();

			return View(lista);
		}

		public ActionResult Create()
		{
			return View();
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Create(PessoaFisica objeto)
		{
			try
			{
				PessoaFisica.TransactionInstance.Save(objeto);
				
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

		public ActionResult Edit(int IdPessoaFisica)
		{
			PessoaFisica objeto = PessoaFisica.FactoryInstance.Get(IdPessoaFisica);

			return View(objeto);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit(PessoaFisica objeto)
		{
			try
			{
				PessoaFisica.TransactionInstance.Save(objeto);
				
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

		public ActionResult Details(int IdPessoaFisica)
		{
			PessoaFisica objeto = PessoaFisica.FactoryInstance.Get(IdPessoaFisica);

			return View(objeto);
		}

		public ActionResult Remove(int IdPessoaFisica)
		{
			PessoaFisica objeto = PessoaFisica.FactoryInstance.Get(IdPessoaFisica);

			return View(objeto);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Remove(PessoaFisica objeto)
		{
				PessoaFisica.TransactionInstance.Remove(objeto);

			return RedirectToAction("Index", new { displayMessage = MENSAGEM_EXCLUSAO });
		}
	}
}
