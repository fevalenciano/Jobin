<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Jobin.Model.Experiencia>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% Html.RenderPartial("DisplayMessage"); %>

	<table>
		<tr>
			<th>
				IdExperiencia
			</th>
			<th>
				Funcao
			</th>
			<th>
				Descricao
			</th>
			<th>
				PeriodoDe
			</th>
			<th>
				PeriodoAte
			</th>
			<th>
				Empresa
			</th>
			<th>
				Ações
			</th>
		</tr>

<% foreach (var item in Model) { %>

		<tr>
			<td>
				<%= Html.Encode(item.IdExperiencia) %>
			</td>
			<td>
				<%= Html.Encode(item.Funcao) %>
			</td>
			<td>
				<%= Html.Encode(item.Descricao) %>
			</td>
			<td>
				<%= Html.Encode(item.PeriodoDe) %>
			</td>
			<td>
				<%= Html.Encode(item.PeriodoAte) %>
			</td>
			<td>
				<%= Html.Encode(item.Empresa) %>
			</td>
			<td>
				<%= Html.ActionLink("Editar", "Edit", new { IdExperiencia = item.IdExperiencia }) %> |
				<%= Html.ActionLink("Consultar", "Details", new { IdExperiencia = item.IdExperiencia }) %> |
				<%= Html.ActionLink("Excluir", "Remove", new { IdExperiencia = item.IdExperiencia }) %> 
			</td>
		</tr>
<% } %>

	</table>

	<p>
		<%= Html.ActionLink("Novo", "Create") %>
	</p>

</asp:Content>
