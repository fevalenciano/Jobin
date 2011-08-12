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
	public class MensagensController : Controller
	{
		private const string MENSAGEM_INCLUSAO = "Registro inserido com sucesso!";
		private const string MENSAGEM_ALTERACAO = "Registro alterado com sucesso!";
		private const string MENSAGEM_EXCLUSAO = "Registro removido com sucesso!";
		private const string MENSAGEM_CAMPOS_OBRIGATORIOS = "Os campos marcados com * são obrigatórios";

		public ActionResult Index()
		{
			MensagensCollection lista = Mensagens.FactoryInstance.GetAll();

			return View(lista);
		}

		public ActionResult Create()
		{
			return View();
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Create(Mensagens objeto)
		{
			try
			{
				Mensagens.TransactionInstance.Save(objeto);
				
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

		public ActionResult Edit(int IdMensagem)
		{
			Mensagens objeto = Mensagens.FactoryInstance.Get(IdMensagem);

			return View(objeto);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit(Mensagens objeto)
		{
			try
			{
				Mensagens.TransactionInstance.Save(objeto);
				
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

		public ActionResult Details(int IdMensagem)
		{
			Mensagens objeto = Mensagens.FactoryInstance.Get(IdMensagem);

			return View(objeto);
		}

		public ActionResult Remove(int IdMensagem)
		{
			Mensagens objeto = Mensagens.FactoryInstance.Get(IdMensagem);

			return View(objeto);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Remove(Mensagens objeto)
		{
				Mensagens.TransactionInstance.Remove(objeto);

			return RedirectToAction("Index", new { displayMessage = MENSAGEM_EXCLUSAO });
		}
	}
}
