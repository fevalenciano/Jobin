<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Jobin.Model.Avaliacoes>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% Html.RenderPartial("DisplayMessage"); %>

	<table>
		<tr>
			<th>
				IdAvaliacao
			</th>
			<th>
				IdUsuario
			</th>
			<th>
				TipoAvaliacao
			</th>
			<th>
				DataAvaliacao
			</th>
			<th>
				Ações
			</th>
		</tr>

<% foreach (var item in Model) { %>

		<tr>
			<td>
				<%= Html.Encode(item.IdAvaliacao) %>
			</td>
			<td>
				<%= Html.Encode(item.IdUsuario) %>
			</td>
			<td>
				<%= Html.Encode(item.TipoAvaliacao) %>
			</td>
			<td>
				<%= Html.Encode(item.DataAvaliacao) %>
			</td>
			<td>
				<%= Html.ActionLink("Editar", "Edit", new { IdAvaliacao = item.IdAvaliacao }) %> |
				<%= Html.ActionLink("Consultar", "Details", new { IdAvaliacao = item.IdAvaliacao }) %> |
				<%= Html.ActionLink("Excluir", "Remove", new { IdAvaliacao = item.IdAvaliacao }) %> 
			</td>
		</tr>
<% } %>

	</table>

	<p>
		<%= Html.ActionLink("Novo", "Create") %>
	</p>

</asp:Content>
