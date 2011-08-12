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
	public class FormacoesController : Controller
	{
		private const string MENSAGEM_INCLUSAO = "Registro inserido com sucesso!";
		private const string MENSAGEM_ALTERACAO = "Registro alterado com sucesso!";
		private const string MENSAGEM_EXCLUSAO = "Registro removido com sucesso!";
		private const string MENSAGEM_CAMPOS_OBRIGATORIOS = "Os campos marcados com * são obrigatórios";

		public ActionResult Index()
		{
			FormacoesCollection lista = Formacoes.FactoryInstance.GetAll();

			return View(lista);
		}

		public ActionResult Create()
		{
			return View();
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Create(Formacoes objeto)
		{
			try
			{
				Formacoes.TransactionInstance.Save(objeto);
				
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

		public ActionResult Edit(int IdFormacao)
		{
			Formacoes objeto = Formacoes.FactoryInstance.Get(IdFormacao);

			return View(objeto);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit(Formacoes objeto)
		{
			try
			{
				Formacoes.TransactionInstance.Save(objeto);
				
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

		public ActionResult Details(int IdFormacao)
		{
			Formacoes objeto = Formacoes.FactoryInstance.Get(IdFormacao);

			return View(objeto);
		}

		public ActionResult Remove(int IdFormacao)
		{
			Formacoes objeto = Formacoes.FactoryInstance.Get(IdFormacao);

			return View(objeto);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Remove(Formacoes objeto)
		{
				Formacoes.TransactionInstance.Remove(objeto);

			return RedirectToAction("Index", new { displayMessage = MENSAGEM_EXCLUSAO });
		}
	}
}
