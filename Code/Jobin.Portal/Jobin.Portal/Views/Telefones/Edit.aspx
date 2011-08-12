<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Telefones>" %>

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
				<label for="IdTelefone">IdTelefone:</label>
				<%= Html.TextBox("IdTelefone") %>
				<%= Html.ValidationMessage("IdTelefone", "*") %>
			</p>
			<p>
				<label for="IdUsuario">IdUsuario:</label>
				<%= Html.TextBox("IdUsuario") %>
				<%= Html.ValidationMessage("IdUsuario", "*") %>
			</p>
			<p>
				<label for="Telefone">Telefone:</label>
				<%= Html.TextBox("Telefone") %>
				<%= Html.ValidationMessage("Telefone", "*") %>
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
