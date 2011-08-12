<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Jobin.Model.Segmentos>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% Html.RenderPartial("DisplayMessage"); %>

	<table>
		<tr>
			<th>
				IdSegmento
			</th>
			<th>
				Nome
			</th>
			<th>
				Ações
			</th>
		</tr>

<% foreach (var item in Model) { %>

		<tr>
			<td>
				<%= Html.Encode(item.IdSegmento) %>
			</td>
			<td>
				<%= Html.Encode(item.Nome) %>
			</td>
			<td>
				<%= Html.ActionLink("Editar", "Edit", new { IdSegmento = item.IdSegmento }) %> |
				<%= Html.ActionLink("Consultar", "Details", new { IdSegmento = item.IdSegmento }) %> |
				<%= Html.ActionLink("Excluir", "Remove", new { IdSegmento = item.IdSegmento }) %> 
			</td>
		</tr>
<% } %>

	</table>

	<p>
		<%= Html.ActionLink("Novo", "Create") %>
	</p>

</asp:Content>
