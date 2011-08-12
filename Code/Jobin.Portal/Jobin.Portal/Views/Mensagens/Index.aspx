<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Jobin.Model.Mensagens>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% Html.RenderPartial("DisplayMessage"); %>

	<table>
		<tr>
			<th>
				IdMensagem
			</th>
			<th>
				Mensagem
			</th>
			<th>
				IdUsuarioOrigem
			</th>
			<th>
				IdUsuarioDestino
			</th>
			<th>
				Ações
			</th>
		</tr>

<% foreach (var item in Model) { %>

		<tr>
			<td>
				<%= Html.Encode(item.IdMensagem) %>
			</td>
			<td>
				<%= Html.Encode(item.Mensagem) %>
			</td>
			<td>
				<%= Html.Encode(item.IdUsuarioOrigem) %>
			</td>
			<td>
				<%= Html.Encode(item.IdUsuarioDestino) %>
			</td>
			<td>
				<%= Html.ActionLink("Editar", "Edit", new { IdMensagem = item.IdMensagem }) %> |
				<%= Html.ActionLink("Consultar", "Details", new { IdMensagem = item.IdMensagem }) %> |
				<%= Html.ActionLink("Excluir", "Remove", new { IdMensagem = item.IdMensagem }) %> 
			</td>
		</tr>
<% } %>

	</table>

	<p>
		<%= Html.ActionLink("Novo", "Create") %>
	</p>

</asp:Content>
