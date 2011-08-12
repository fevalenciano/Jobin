<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Jobin.Model.Formacoes>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% Html.RenderPartial("DisplayMessage"); %>

	<table>
		<tr>
			<th>
				IdFormacao
			</th>
			<th>
				Curso
			</th>
			<th>
				Descricao
			</th>
			<th>
				Instituicao
			</th>
			<th>
				PeridoDe
			</th>
			<th>
				PeriodoAte
			</th>
			<th>
				Ações
			</th>
		</tr>

<% foreach (var item in Model) { %>

		<tr>
			<td>
				<%= Html.Encode(item.IdFormacao) %>
			</td>
			<td>
				<%= Html.Encode(item.Curso) %>
			</td>
			<td>
				<%= Html.Encode(item.Descricao) %>
			</td>
			<td>
				<%= Html.Encode(item.Instituicao) %>
			</td>
			<td>
				<%= Html.Encode(item.PeridoDe) %>
			</td>
			<td>
				<%= Html.Encode(item.PeriodoAte) %>
			</td>
			<td>
				<%= Html.ActionLink("Editar", "Edit", new { IdFormacao = item.IdFormacao }) %> |
				<%= Html.ActionLink("Consultar", "Details", new { IdFormacao = item.IdFormacao }) %> |
				<%= Html.ActionLink("Excluir", "Remove", new { IdFormacao = item.IdFormacao }) %> 
			</td>
		</tr>
<% } %>

	</table>

	<p>
		<%= Html.ActionLink("Novo", "Create") %>
	</p>

</asp:Content>
