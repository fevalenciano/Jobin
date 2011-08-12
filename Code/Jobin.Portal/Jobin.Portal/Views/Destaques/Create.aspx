<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Destaques>" %>

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
				<label for="IdDestaque">IdDestaque:</label>
				<%= Html.TextBox("IdDestaque") %>
				<%= Html.ValidationMessage("IdDestaque", "*") %>
			</p>
			<p>
				<label for="Destaque">Destaque:</label>
				<%= Html.TextBox("Destaque") %>
				<%= Html.ValidationMessage("Destaque", "*") %>
			</p>
			<p>
				<label for="DescricaoSimples">DescricaoSimples:</label>
				<%= Html.TextBox("DescricaoSimples") %>
				<%= Html.ValidationMessage("DescricaoSimples", "*") %>
			</p>
			<p>
				<label for="DescricaoComplexa">DescricaoComplexa:</label>
				<%= Html.TextBox("DescricaoComplexa") %>
				<%= Html.ValidationMessage("DescricaoComplexa", "*") %>
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
