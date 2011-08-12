<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Destaques>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<fieldset>
		<legend>Campos</legend>
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
	</fieldset>

	<p>
		<%=Html.ActionLink("Editar", "Edit", new { IdDestaque = Model.IdDestaque }) %> | 
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</p>

</asp:Content>
