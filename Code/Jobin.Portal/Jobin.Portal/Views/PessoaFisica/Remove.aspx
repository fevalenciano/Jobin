<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.PessoaFisica>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% using (Html.BeginForm()) {%>
		<fieldset>
			<legend>Confirma a exclusão do registro?</legend>
			<p>
				IdPessoaFisica:
				<%= Html.Encode(Model.IdPessoaFisica) %>
			</p>
			<p>
				IdFornecedor:
				<%= Html.Encode(Model.IdFornecedor) %>
			</p>
			<p>
				CPF:
				<%= Html.Encode(Model.CPF) %>
			</p>
			<p>
				IdFormacao:
				<%= Html.Encode(Model.IdFormacao) %>
			</p>
			<p>
				IdExperiencia:
				<%= Html.Encode(Model.IdExperiencia) %>
			</p>
			<p>
				<input type="submit" value="Confirmar" />
			</p>
		</fieldset>

	<% } %>
	<div>
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</div>

</asp:Content>
