<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Formacoes>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% using (Html.BeginForm()) {%>
		<fieldset>
			<legend>Confirma a exclusão do registro?</legend>
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
			<p>
				<input type="submit" value="Confirmar" />
			</p>
		</fieldset>

	<% } %>
	<div>
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</div>

</asp:Content>
