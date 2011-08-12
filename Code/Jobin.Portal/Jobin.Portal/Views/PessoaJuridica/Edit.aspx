<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.PessoaJuridica>" %>

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
				<label for="IdPessoaJuridica">IdPessoaJuridica:</label>
				<%= Html.TextBox("IdPessoaJuridica") %>
				<%= Html.ValidationMessage("IdPessoaJuridica", "*") %>
			</p>
			<p>
				<label for="IdFornecedor">IdFornecedor:</label>
				<%= Html.TextBox("IdFornecedor") %>
				<%= Html.ValidationMessage("IdFornecedor", "*") %>
			</p>
			<p>
				<label for="CNPJ">CNPJ:</label>
				<%= Html.TextBox("CNPJ") %>
				<%= Html.ValidationMessage("CNPJ", "*") %>
			</p>
			<p>
				<label for="RazaoSocial">RazaoSocial:</label>
				<%= Html.TextBox("RazaoSocial") %>
				<%= Html.ValidationMessage("RazaoSocial", "*") %>
			</p>
			<p>
				<label for="Site">Site:</label>
				<%= Html.TextBox("Site") %>
				<%= Html.ValidationMessage("Site", "*") %>
			</p>
			<p>
				<label for="Responsavel">Responsavel:</label>
				<%= Html.TextBox("Responsavel") %>
				<%= Html.ValidationMessage("Responsavel", "*") %>
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
