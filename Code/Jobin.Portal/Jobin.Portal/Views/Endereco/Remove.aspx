<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Endereco>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% using (Html.BeginForm()) {%>
		<fieldset>
			<legend>Confirma a exclusão do registro?</legend>
			<p>
				IdEndereco:
				<%= Html.Encode(Model.IdEndereco) %>
			</p>
			<p>
				Logradouro:
				<%= Html.Encode(Model.Logradouro) %>
			</p>
			<p>
				Complemento:
				<%= Html.Encode(Model.Complemento) %>
			</p>
			<p>
				Numero:
				<%= Html.Encode(Model.Numero) %>
			</p>
			<p>
				Estado:
				<%= Html.Encode(Model.Estado) %>
			</p>
			<p>
				Cidade:
				<%= Html.Encode(Model.Cidade) %>
			</p>
			<p>
				CEP:
				<%= Html.Encode(Model.CEP) %>
			</p>
			<p>
				Bairro:
				<%= Html.Encode(Model.Bairro) %>
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
