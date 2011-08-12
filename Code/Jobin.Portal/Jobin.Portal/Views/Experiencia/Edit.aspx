<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Experiencia>" %>

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
				<label for="IdExperiencia">IdExperiencia:</label>
				<%= Html.TextBox("IdExperiencia") %>
				<%= Html.ValidationMessage("IdExperiencia", "*") %>
			</p>
			<p>
				<label for="Funcao">Funcao:</label>
				<%= Html.TextBox("Funcao") %>
				<%= Html.ValidationMessage("Funcao", "*") %>
			</p>
			<p>
				<label for="Descricao">Descricao:</label>
				<%= Html.TextBox("Descricao") %>
				<%= Html.ValidationMessage("Descricao", "*") %>
			</p>
			<p>
				<label for="PeriodoDe">PeriodoDe:</label>
				<%= Html.TextBox("PeriodoDe") %>
				<%= Html.ValidationMessage("PeriodoDe", "*") %>
			</p>
			<p>
				<label for="PeriodoAte">PeriodoAte:</label>
				<%= Html.TextBox("PeriodoAte") %>
				<%= Html.ValidationMessage("PeriodoAte", "*") %>
			</p>
			<p>
				<label for="Empresa">Empresa:</label>
				<%= Html.TextBox("Empresa") %>
				<%= Html.ValidationMessage("Empresa", "*") %>
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
