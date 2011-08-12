<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Jobin.Model.Endereco>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% Html.RenderPartial("DisplayMessage"); %>

	<table>
		<tr>
			<th>
				IdEndereco
			</th>
			<th>
				Logradouro
			</th>
			<th>
				Complemento
			</th>
			<th>
				Numero
			</th>
			<th>
				Estado
			</th>
			<th>
				Cidade
			</th>
			<th>
				CEP
			</th>
			<th>
				Bairro
			</th>
			<th>
				Ações
			</th>
		</tr>

<% foreach (var item in Model) { %>

		<tr>
			<td>
				<%= Html.Encode(item.IdEndereco) %>
			</td>
			<td>
				<%= Html.Encode(item.Logradouro) %>
			</td>
			<td>
				<%= Html.Encode(item.Complemento) %>
			</td>
			<td>
				<%= Html.Encode(item.Numero) %>
			</td>
			<td>
				<%= Html.Encode(item.Estado) %>
			</td>
			<td>
				<%= Html.Encode(item.Cidade) %>
			</td>
			<td>
				<%= Html.Encode(item.CEP) %>
			</td>
			<td>
				<%= Html.Encode(item.Bairro) %>
			</td>
			<td>
				<%= Html.ActionLink("Editar", "Edit", new { IdEndereco = item.IdEndereco }) %> |
				<%= Html.ActionLink("Consultar", "Details", new { IdEndereco = item.IdEndereco }) %> |
				<%= Html.ActionLink("Excluir", "Remove", new { IdEndereco = item.IdEndereco }) %> 
			</td>
		</tr>
<% } %>

	</table>

	<p>
		<%= Html.ActionLink("Novo", "Create") %>
	</p>

</asp:Content>
