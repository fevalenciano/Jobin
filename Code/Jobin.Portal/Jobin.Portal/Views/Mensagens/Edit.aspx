<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Mensagens>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<%= Html.ValidationSummary("Ocorreu um erro durante a gravação") %>

	<% using (Html.BeginForm()) {%>

		<fieldset>
			<legend>Campos</legend>
			<p>
				<label for="IdMensagem">IdMensagem:</label>
				<%= Html.TextBox("IdMensagem") %>
				<%= Html.ValidationMessage("IdMensagem", "*") %>
			</p>
			<p>
				<label for="Mensagem">Mensagem:</label>
				<%= Html.TextBox("Mensagem") %>
				<%= Html.ValidationMessage("Mensagem", "*") %>
			</p>
			<p>
				<label for="IdUsuarioOrigem">IdUsuarioOrigem:</label>
				<%= Html.TextBox("IdUsuarioOrigem") %>
				<%= Html.ValidationMessage("IdUsuarioOrigem", "*") %>
			</p>
			<p>
				<label for="IdUsuarioDestino">IdUsuarioDestino:</label>
				<%= Html.TextBox("IdUsuarioDestino") %>
				<%= Html.ValidationMessage("IdUsuarioDestino", "*") %>
			</p>
			<p>
				<input type="submit" value="Salvar" />
			</p>
		</fieldset>
	<% } %>

	<div>
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</div>

</asp:Content>
