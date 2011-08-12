<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Formacoes>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<fieldset>
		<legend>Campos</legend>
		<p>
			IdFormacao:
			<%= Html.Encode(Model.IdFormacao) %>
		</p>
		<p>
			Curso:
			<%= Html.Encode(Model.Curso) %>
		</p>
		<p>
			Descricao:
			<%= Html.Encode(Model.Descricao) %>
		</p>
		<p>
			Instituicao:
			<%= Html.Encode(Model.Instituicao) %>
		</p>
		<p>
			PeridoDe:
			<%= Html.Encode(Model.PeridoDe) %>
		</p>
		<p>
			PeriodoAte:
			<%= Html.Encode(Model.PeriodoAte) %>
		</p>
	</fieldset>

	<p>
		<%=Html.ActionLink("Editar", "Edit", new { IdFormacao = Model.IdFormacao }) %> | 
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</p>

</asp:Content>
