<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Endereco>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<%= Html.ValidationSummary("Ocorreu um erro durante a gravação") %>

	<% using (Html.BeginForm()) {%>

		<fieldset>
			<legend>Campos</legend>
			<p>
				<label for="IdEndereco">IdEndereco:</label>
				<%= Html.TextBox("IdEndereco") %>
				<%= Html.ValidationMessage("IdEndereco", "*") %>
			</p>
			<p>
				<label for="Logradouro">Logradouro:</label>
				<%= Html.TextBox("Logradouro") %>
				<%= Html.ValidationMessage("Logradouro", "*") %>
			</p>
			<p>
				<label for="Complemento">Complemento:</label>
				<%= Html.TextBox("Complemento") %>
				<%= Html.ValidationMessage("Complemento", "*") %>
			</p>
			<p>
				<label for="Numero">Numero:</label>
				<%= Html.TextBox("Numero") %>
				<%= Html.ValidationMessage("Numero", "*") %>
			</p>
			<p>
				<label for="Estado">Estado:</label>
				<%= Html.TextBox("Estado") %>
				<%= Html.ValidationMessage("Estado", "*") %>
			</p>
			<p>
				<label for="Cidade">Cidade:</label>
				<%= Html.TextBox("Cidade") %>
				<%= Html.ValidationMessage("Cidade", "*") %>
			</p>
			<p>
				<label for="CEP">CEP:</label>
				<%= Html.TextBox("CEP") %>
				<%= Html.ValidationMessage("CEP", "*") %>
			</p>
			<p>
				<label for="Bairro">Bairro:</label>
				<%= Html.TextBox("Bairro") %>
				<%= Html.ValidationMessage("Bairro", "*") %>
			</p>
			<p>
				<input type="submit" value="Confirmar" />
			</p>
		</fieldset>
	<% } %>

	<div>
		<%=Html.ActionLink("Voltar para Lista", "Index") %>
	</div>

</asp:Content>
