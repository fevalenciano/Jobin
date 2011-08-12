<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Oportunidades>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<%= Html.ValidationSummary("Ocorreu um erro durante a gravação") %>

	<% using (Html.BeginForm()) {%>

		<fieldset>
			<legend>Campos</legend>
			<p>
				<label for="IdOportunidade">IdOportunidade:</label>
				<%= Html.TextBox("IdOportunidade") %>
				<%= Html.ValidationMessage("IdOportunidade", "*") %>
			</p>
			<p>
				<label for="IdCategoria">IdCategoria:</label>
				<%= Html.TextBox("IdCategoria") %>
				<%= Html.ValidationMessage("IdCategoria", "*") %>
			</p>
			<p>
				<label for="IdMensagem">IdMensagem:</label>
				<%= Html.TextBox("IdMensagem") %>
				<%= Html.ValidationMessage("IdMensagem", "*") %>
			</p>
			<p>
				<label for="IdFornecedor">IdFornecedor:</label>
				<%= Html.TextBox("IdFornecedor") %>
				<%= Html.ValidationMessage("IdFornecedor", "*") %>
			</p>
			<p>
				<label for="IdAvaliacao">IdAvaliacao:</label>
				<%= Html.TextBox("IdAvaliacao") %>
				<%= Html.ValidationMessage("IdAvaliacao", "*") %>
			</p>
			<p>
				<label for="Titulo">Titulo:</label>
				<%= Html.TextBox("Titulo") %>
				<%= Html.ValidationMessage("Titulo", "*") %>
			</p>
			<p>
				<label for="Subtitulo">Subtitulo:</label>
				<%= Html.TextBox("Subtitulo") %>
				<%= Html.ValidationMessage("Subtitulo", "*") %>
			</p>
			<p>
				<label for="Descricao">Descricao:</label>
				<%= Html.TextBox("Descricao") %>
				<%= Html.ValidationMessage("Descricao", "*") %>
			</p>
			<p>
				<label for="IdDestaque">IdDestaque:</label>
				<%= Html.TextBox("IdDestaque") %>
				<%= Html.ValidationMessage("IdDestaque", "*") %>
			</p>
			<p>
				<label for="GoogleMaps">GoogleMaps:</label>
				<%= Html.TextBox("GoogleMaps") %>
				<%= Html.ValidationMessage("GoogleMaps", "*") %>
			</p>
			<p>
				<label for="ImagemVideo">ImagemVideo:</label>
				<%= Html.TextBox("ImagemVideo") %>
				<%= Html.ValidationMessage("ImagemVideo", "*") %>
			</p>
			<p>
				<input type="submit" value="Salvar" />
			</p>
		</fieldset>
	<% } %>

	<div>
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</div>

</asp:Content>
