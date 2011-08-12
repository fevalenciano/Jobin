<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Fornecedores>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<fieldset>
		<legend>Campos</legend>
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
	</fieldset>

	<p>
		<%=Html.ActionLink("Editar", "Edit", new { IdFornecedor = Model.IdFornecedor }) %> | 
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</p>

</asp:Content>
