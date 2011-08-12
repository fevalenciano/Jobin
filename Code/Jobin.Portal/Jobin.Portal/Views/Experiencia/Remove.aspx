<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Experiencia>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% using (Html.BeginForm()) {%>
		<fieldset>
			<legend>Confirma a exclusão do registro?</legend>
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
			<p>
				<input type="submit" value="Confirmar" />
			</p>
		</fieldset>

	<% } %>
	<div>
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</div>

</asp:Content>
