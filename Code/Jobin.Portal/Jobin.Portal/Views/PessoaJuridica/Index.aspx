<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Jobin.Model.PessoaJuridica>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% Html.RenderPartial("DisplayMessage"); %>

	<table>
		<tr>
			<th>
				IdPessoaJuridica
			</th>
			<th>
				IdFornecedor
			</th>
			<th>
				CNPJ
			</th>
			<th>
				RazaoSocial
			</th>
			<th>
				Site
			</th>
			<th>
				Responsavel
			</th>
			<th>
				Ações
			</th>
		</tr>

<% foreach (var item in Model) { %>

		<tr>
			<td>
				<%= Html.Encode(item.IdPessoaJuridica) %>
			</td>
			<td>
				<%= Html.Encode(item.IdFornecedor) %>
			</td>
			<td>
				<%= Html.Encode(item.CNPJ) %>
			</td>
			<td>
				<%= Html.Encode(item.RazaoSocial) %>
			</td>
			<td>
				<%= Html.Encode(item.Site) %>
			</td>
			<td>
				<%= Html.Encode(item.Responsavel) %>
			</td>
			<td>
				<%= Html.ActionLink("Editar", "Edit", new { IdPessoaJuridica = item.IdPessoaJuridica }) %> |
				<%= Html.ActionLink("Consultar", "Details", new { IdPessoaJuridica = item.IdPessoaJuridica }) %> |
				<%= Html.ActionLink("Excluir", "Remove", new { IdPessoaJuridica = item.IdPessoaJuridica }) %> 
			</td>
		</tr>
<% } %>

	</table>

	<p>
		<%= Html.ActionLink("Novo", "Create") %>
	</p>

</asp:Content>
