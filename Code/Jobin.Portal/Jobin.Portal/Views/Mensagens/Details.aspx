<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Mensagens>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<fieldset>
		<legend>Campos</legend>
		<p>
			IdMensagem:
			<%= Html.Encode(Model.IdMensagem) %>
		</p>
		<p>
			Mensagem:
			<%= Html.Encode(Model.Mensagem) %>
		</p>
		<p>
			IdUsuarioOrigem:
			<%= Html.Encode(Model.IdUsuarioOrigem) %>
		</p>
		<p>
			IdUsuarioDestino:
			<%= Html.Encode(Model.IdUsuarioDestino) %>
		</p>
	</fieldset>

	<p>
		<%=Html.ActionLink("Editar", "Edit", new { IdMensagem = Model.IdMensagem }) %> | 
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</p>

</asp:Content>
