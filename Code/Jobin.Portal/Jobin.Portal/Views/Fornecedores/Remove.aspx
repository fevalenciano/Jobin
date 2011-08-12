<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Fornecedores>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% using (Html.BeginForm()) {%>
		<fieldset>
			<legend>Confirma a exclusão do registro?</legend>
			<p>
				IdFornecedor:
				<%= Html.Encode(Model.IdFornecedor) %>
			</p>
			<p>
				IdUsuario:
				<%= Html.Encode(Model.IdUsuario) %>
			</p>
			<p>
				IdEndereco:
				<%= Html.Encode(Model.IdEndereco) %>
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
