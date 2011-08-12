<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Jobin.Model.PessoaFisica>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% Html.RenderPartial("DisplayMessage"); %>

	<table>
		<tr>
			<th>
				IdPessoaFisica
			</th>
			<th>
				IdFornecedor
			</th>
			<th>
				CPF
			</th>
			<th>
				IdFormacao
			</th>
			<th>
				IdExperiencia
			</th>
			<th>
				Ações
			</th>
		</tr>

<% foreach (var item in Model) { %>

		<tr>
			<td>
				<%= Html.Encode(item.IdPessoaFisica) %>
			</td>
			<td>
				<%= Html.Encode(item.IdFornecedor) %>
			</td>
			<td>
				<%= Html.Encode(item.CPF) %>
			</td>
			<td>
				<%= Html.Encode(item.IdFormacao) %>
			</td>
			<td>
				<%= Html.Encode(item.IdExperiencia) %>
			</td>
			<td>
				<%= Html.ActionLink("Editar", "Edit", new { IdPessoaFisica = item.IdPessoaFisica }) %> |
				<%= Html.ActionLink("Consultar", "Details", new { IdPessoaFisica = item.IdPessoaFisica }) %> |
				<%= Html.ActionLink("Excluir", "Remove", new { IdPessoaFisica = item.IdPessoaFisica }) %> 
			</td>
		</tr>
<% } %>

	</table>

	<p>
		<%= Html.ActionLink("Novo", "Create") %>
	</p>

</asp:Content>
