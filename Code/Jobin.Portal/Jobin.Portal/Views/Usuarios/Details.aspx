<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Usuarios>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<fieldset>
		<legend>Campos</legend>
		<p>
			IdUsuario:
			<%= Html.Encode(Model.IdUsuario) %>
		</p>
		<p>
			Email:
			<%= Html.Encode(Model.Email) %>
		</p>
		<p>
			Senha:
			<%= Html.Encode(Model.Senha) %>
		</p>
		<p>
			DataInclusao:
			<%= Html.Encode(Model.DataInclusao) %>
		</p>
		<p>
			DataAlteracao:
			<%= Html.Encode(Model.DataAlteracao) %>
		</p>
		<p>
			Nome:
			<%= Html.Encode(Model.Nome) %>
		</p>
		<p>
			Sobrenome:
			<%= Html.Encode(Model.Sobrenome) %>
		</p>
	</fieldset>

	<p>
		<%=Html.ActionLink("Editar", "Edit", new { IdUsuario = Model.IdUsuario }) %> | 
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</p>

</asp:Content>
