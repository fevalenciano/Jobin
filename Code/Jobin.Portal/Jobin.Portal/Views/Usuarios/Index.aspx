<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Jobin.Model.Usuarios>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% Html.RenderPartial("DisplayMessage"); %>

	<table>
		<tr>
			<th>
				IdUsuario
			</th>
			<th>
				Email
			</th>
			<th>
				Senha
			</th>
			<th>
				DataInclusao
			</th>
			<th>
				DataAlteracao
			</th>
			<th>
				Nome
			</th>
			<th>
				Sobrenome
			</th>
			<th>
				Ações
			</th>
		</tr>

<% foreach (var item in Model) { %>

		<tr>
			<td>
				<%= Html.Encode(item.IdUsuario) %>
			</td>
			<td>
				<%= Html.Encode(item.Email) %>
			</td>
			<td>
				<%= Html.Encode(item.Senha) %>
			</td>
			<td>
				<%= Html.Encode(item.DataInclusao) %>
			</td>
			<td>
				<%= Html.Encode(item.DataAlteracao) %>
			</td>
			<td>
				<%= Html.Encode(item.Nome) %>
			</td>
			<td>
				<%= Html.Encode(item.Sobrenome) %>
			</td>
			<td>
				<%= Html.ActionLink("Editar", "Edit", new { IdUsuario = item.IdUsuario }) %> |
				<%= Html.ActionLink("Consultar", "Details", new { IdUsuario = item.IdUsuario }) %> |
				<%= Html.ActionLink("Excluir", "Remove", new { IdUsuario = item.IdUsuario }) %> 
			</td>
		</tr>
<% } %>

	</table>

	<p>
		<%= Html.ActionLink("Novo", "Create") %>
	</p>

</asp:Content>
