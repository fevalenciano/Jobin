<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Experiencia>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<fieldset>
		<legend>Campos</legend>
		<p>
			IdExperiencia:
			<%= Html.Encode(Model.IdExperiencia) %>
		</p>
		<p>
			Funcao:
			<%= Html.Encode(Model.Funcao) %>
		</p>
		<p>
			Descricao:
			<%= Html.Encode(Model.Descricao) %>
		</p>
		<p>
			PeriodoDe:
			<%= Html.Encode(Model.PeriodoDe) %>
		</p>
		<p>
			PeriodoAte:
			<%= Html.Encode(Model.PeriodoAte) %>
		</p>
		<p>
			Empresa:
			<%= Html.Encode(Model.Empresa) %>
		</p>
	</fieldset>

	<p>
		<%=Html.ActionLink("Editar", "Edit", new { IdExperiencia = Model.IdExperiencia }) %> | 
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</p>

</asp:Content>
