<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Avaliacoes>" %>

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
				<label for="IdAvaliacao">IdAvaliacao:</label>
				<%= Html.TextBox("IdAvaliacao") %>
				<%= Html.ValidationMessage("IdAvaliacao", "*") %>
			</p>
			<p>
				<label for="IdUsuario">IdUsuario:</label>
				<%= Html.TextBox("IdUsuario") %>
				<%= Html.ValidationMessage("IdUsuario", "*") %>
			</p>
			<p>
				<label for="TipoAvaliacao">TipoAvaliacao:</label>
				<%= Html.TextBox("TipoAvaliacao") %>
				<%= Html.ValidationMessage("TipoAvaliacao", "*") %>
			</p>
			<p>
				<label for="DataAvaliacao">DataAvaliacao:</label>
				<%= Html.TextBox("DataAvaliacao") %>
				<%= Html.ValidationMessage("DataAvaliacao", "*") %>
			</p>
			<p>
				<input type="submit" value="Confirmar" />
			</p>
		</fieldset>
	<% } %>

	<div>
		<%=Html.ActionLink("Voltar para Lista", "Index") %>
	</div>

</asp:Content>
