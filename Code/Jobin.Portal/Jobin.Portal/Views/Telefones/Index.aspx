<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Jobin.Model.Telefones>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% Html.RenderPartial("DisplayMessage"); %>

	<table>
		<tr>
			<th>
				IdTelefone
			</th>
			<th>
				IdUsuario
			</th>
			<th>
				Telefone
			</th>
			<th>
				Ações
			</th>
		</tr>

<% foreach (var item in Model) { %>

		<tr>
			<td>
				<%= Html.Encode(item.IdTelefone) %>
			</td>
			<td>
				<%= Html.Encode(item.IdUsuario) %>
			</td>
			<td>
				<%= Html.Encode(item.Telefone) %>
			</td>
			<td>
				<%= Html.ActionLink("Editar", "Edit", new { IdTelefone = item.IdTelefone }) %> |
				<%= Html.ActionLink("Consultar", "Details", new { IdTelefone = item.IdTelefone }) %> |
				<%= Html.ActionLink("Excluir", "Remove", new { IdTelefone = item.IdTelefone }) %> 
			</td>
		</tr>
<% } %>

	</table>

	<p>
		<%= Html.ActionLink("Novo", "Create") %>
	</p>

</asp:Content>
