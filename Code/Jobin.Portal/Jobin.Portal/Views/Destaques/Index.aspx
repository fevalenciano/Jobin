<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Jobin.Model.Destaques>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% Html.RenderPartial("DisplayMessage"); %>

	<table>
		<tr>
			<th>
				IdDestaque
			</th>
			<th>
				Destaque
			</th>
			<th>
				DescricaoSimples
			</th>
			<th>
				DescricaoComplexa
			</th>
			<th>
				Ações
			</th>
		</tr>

<% foreach (var item in Model) { %>

		<tr>
			<td>
				<%= Html.Encode(item.IdDestaque) %>
			</td>
			<td>
				<%= Html.Encode(item.Destaque) %>
			</td>
			<td>
				<%= Html.Encode(item.DescricaoSimples) %>
			</td>
			<td>
				<%= Html.Encode(item.DescricaoComplexa) %>
			</td>
			<td>
				<%= Html.ActionLink("Editar", "Edit", new { IdDestaque = item.IdDestaque }) %> |
				<%= Html.ActionLink("Consultar", "Details", new { IdDestaque = item.IdDestaque }) %> |
				<%= Html.ActionLink("Excluir", "Remove", new { IdDestaque = item.IdDestaque }) %> 
			</td>
		</tr>
<% } %>

	</table>

	<p>
		<%= Html.ActionLink("Novo", "Create") %>
	</p>

</asp:Content>
