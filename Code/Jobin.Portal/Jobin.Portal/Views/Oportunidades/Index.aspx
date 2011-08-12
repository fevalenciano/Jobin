<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Jobin.Model.Oportunidades>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% Html.RenderPartial("DisplayMessage"); %>

	<table>
		<tr>
			<th>
				IdOportunidade
			</th>
			<th>
				IdCategoria
			</th>
			<th>
				IdMensagem
			</th>
			<th>
				IdFornecedor
			</th>
			<th>
				IdAvaliacao
			</th>
			<th>
				Titulo
			</th>
			<th>
				Subtitulo
			</th>
			<th>
				Descricao
			</th>
			<th>
				IdDestaque
			</th>
			<th>
				GoogleMaps
			</th>
			<th>
				ImagemVideo
			</th>
			<th>
				Ações
			</th>
		</tr>

<% foreach (var item in Model) { %>

		<tr>
			<td>
				<%= Html.Encode(item.IdOportunidade) %>
			</td>
			<td>
				<%= Html.Encode(item.IdCategoria) %>
			</td>
			<td>
				<%= Html.Encode(item.IdMensagem) %>
			</td>
			<td>
				<%= Html.Encode(item.IdFornecedor) %>
			</td>
			<td>
				<%= Html.Encode(item.IdAvaliacao) %>
			</td>
			<td>
				<%= Html.Encode(item.Titulo) %>
			</td>
			<td>
				<%= Html.Encode(item.Subtitulo) %>
			</td>
			<td>
				<%= Html.Encode(item.Descricao) %>
			</td>
			<td>
				<%= Html.Encode(item.IdDestaque) %>
			</td>
			<td>
				<%= Html.Encode(item.GoogleMaps) %>
			</td>
			<td>
				<%= Html.Encode(item.ImagemVideo) %>
			</td>
			<td>
				<%= Html.ActionLink("Editar", "Edit", new { IdOportunidade = item.IdOportunidade }) %> |
				<%= Html.ActionLink("Consultar", "Details", new { IdOportunidade = item.IdOportunidade }) %> |
				<%= Html.ActionLink("Excluir", "Remove", new { IdOportunidade = item.IdOportunidade }) %> 
			</td>
		</tr>
<% } %>

	</table>

	<p>
		<%= Html.ActionLink("Novo", "Create") %>
	</p>

</asp:Content>
