<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Avaliacoes>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<fieldset>
		<legend>Campos</legend>
		<p>
			IdAvaliacao:
			<%= Html.Encode(Model.IdAvaliacao) %>
		</p>
		<p>
			IdUsuario:
			<%= Html.Encode(Model.IdUsuario) %>
		</p>
		<p>
			TipoAvaliacao:
			<%= Html.Encode(Model.TipoAvaliacao) %>
		</p>
		<p>
			DataAvaliacao:
			<%= Html.Encode(Model.DataAvaliacao) %>
		</p>
	</fieldset>

	<p>
		<%=Html.ActionLink("Editar", "Edit", new { IdAvaliacao = Model.IdAvaliacao }) %> | 
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</p>

</asp:Content>
