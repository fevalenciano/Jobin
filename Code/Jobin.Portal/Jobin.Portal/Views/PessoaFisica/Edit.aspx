<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.PessoaFisica>" %>

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
				<label for="IdPessoaFisica">IdPessoaFisica:</label>
				<%= Html.TextBox("IdPessoaFisica") %>
				<%= Html.ValidationMessage("IdPessoaFisica", "*") %>
			</p>
			<p>
				<label for="IdFornecedor">IdFornecedor:</label>
				<%= Html.TextBox("IdFornecedor") %>
				<%= Html.ValidationMessage("IdFornecedor", "*") %>
			</p>
			<p>
				<label for="CPF">CPF:</label>
				<%= Html.TextBox("CPF") %>
				<%= Html.ValidationMessage("CPF", "*") %>
			</p>
			<p>
				<label for="IdFormacao">IdFormacao:</label>
				<%= Html.TextBox("IdFormacao") %>
				<%= Html.ValidationMessage("IdFormacao", "*") %>
			</p>
			<p>
				<label for="IdExperiencia">IdExperiencia:</label>
				<%= Html.TextBox("IdExperiencia") %>
				<%= Html.ValidationMessage("IdExperiencia", "*") %>
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
