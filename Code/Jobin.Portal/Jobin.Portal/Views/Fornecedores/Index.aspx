<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Jobin.Model.Fornecedores>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% Html.RenderPartial("DisplayMessage"); %>

	<table>
		<tr>
			<th>
				IdFornecedor
			</th>
			<th>
				IdUsuario
			</th>
			<th>
				IdEndereco
			</th>
			<th>
				Ações
			</th>
		</tr>

<% foreach (var item in Model) { %>

		<tr>
			<td>
				<%= Html.Encode(item.IdFornecedor) %>
			</td>
			<td>
				<%= Html.Encode(item.IdUsuario) %>
			</td>
			<td>
				<%= Html.Encode(item.IdEndereco) %>
			</td>
			<td>
				<%= Html.ActionLink("Editar", "Edit", new { IdFornecedor = item.IdFornecedor }) %> |
				<%= Html.ActionLink("Consultar", "Details", new { IdFornecedor = item.IdFornecedor }) %> |
				<%= Html.ActionLink("Excluir", "Remove", new { IdFornecedor = item.IdFornecedor }) %> 
			</td>
		</tr>
<% } %>

	</table>

	<p>
		<%= Html.ActionLink("Novo", "Create") %>
	</p>

</asp:Content>
