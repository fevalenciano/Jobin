<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Formacoes>" %>

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
				<label for="IdFormacao">IdFormacao:</label>
				<%= Html.TextBox("IdFormacao") %>
				<%= Html.ValidationMessage("IdFormacao", "*") %>
			</p>
			<p>
				<label for="Curso">Curso:</label>
				<%= Html.TextBox("Curso") %>
				<%= Html.ValidationMessage("Curso", "*") %>
			</p>
			<p>
				<label for="Descricao">Descricao:</label>
				<%= Html.TextBox("Descricao") %>
				<%= Html.ValidationMessage("Descricao", "*") %>
			</p>
			<p>
				<label for="Instituicao">Instituicao:</label>
				<%= Html.TextBox("Instituicao") %>
				<%= Html.ValidationMessage("Instituicao", "*") %>
			</p>
			<p>
				<label for="PeridoDe">PeridoDe:</label>
				<%= Html.TextBox("PeridoDe") %>
				<%= Html.ValidationMessage("PeridoDe", "*") %>
			</p>
			<p>
				<label for="PeriodoAte">PeriodoAte:</label>
				<%= Html.TextBox("PeriodoAte") %>
				<%= Html.ValidationMessage("PeriodoAte", "*") %>
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
