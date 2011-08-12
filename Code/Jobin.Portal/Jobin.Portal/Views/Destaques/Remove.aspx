<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Destaques>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% using (Html.BeginForm()) {%>
		<fieldset>
			<legend>Confirma a exclusão do registro?</legend>
			<p>
				IdDestaque:
				<%= Html.Encode(Model.IdDestaque) %>
			</p>
			<p>
				Destaque:
				<%= Html.Encode(Model.Destaque) %>
			</p>
			<p>
				DescricaoSimples:
				<%= Html.Encode(Model.DescricaoSimples) %>
			</p>
			<p>
				DescricaoComplexa:
				<%= Html.Encode(Model.DescricaoComplexa) %>
			</p>
			<p>
				<input type="submit" value="Confirmar" />
			</p>
		</fieldset>

	<% } %>
	<div>
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</div>

</asp:Content>
