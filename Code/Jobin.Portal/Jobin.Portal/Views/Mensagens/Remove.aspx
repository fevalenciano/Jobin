<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Mensagens>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% using (Html.BeginForm()) {%>
		<fieldset>
			<legend>Confirma a exclusão do registro?</legend>
			<p>
				IdMensagem:
				<%= Html.Encode(Model.IdMensagem) %>
			</p>
			<p>
				Mensagem:
				<%= Html.Encode(Model.Mensagem) %>
			</p>
			<p>
				IdUsuarioOrigem:
				<%= Html.Encode(Model.IdUsuarioOrigem) %>
			</p>
			<p>
				IdUsuarioDestino:
				<%= Html.Encode(Model.IdUsuarioDestino) %>
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
