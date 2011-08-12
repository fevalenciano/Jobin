<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Segmentos>" %>

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
				<label for="IdSegmento">IdSegmento:</label>
				<%= Html.TextBox("IdSegmento") %>
				<%= Html.ValidationMessage("IdSegmento", "*") %>
			</p>
			<p>
				<label for="Nome">Nome:</label>
				<%= Html.TextBox("Nome") %>
				<%= Html.ValidationMessage("Nome", "*") %>
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
