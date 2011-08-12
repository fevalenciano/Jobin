<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Categorias>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<fieldset>
		<legend>Campos</legend>
		<p>
			IdCategoria:
			<%= Html.Encode(Model.IdCategoria) %>
		</p>
		<p>
			IdSegmento:
			<%= Html.Encode(Model.IdSegmento) %>
		</p>
		<p>
			Nome:
			<%= Html.Encode(Model.Nome) %>
		</p>
	</fieldset>

	<p>
		<%=Html.ActionLink("Editar", "Edit", new { IdCategoria = Model.IdCategoria }) %> | 
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</p>

</asp:Content>
