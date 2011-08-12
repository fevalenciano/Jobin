<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.Usuarios>" %>

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
				<label for="IdUsuario">IdUsuario:</label>
				<%= Html.TextBox("IdUsuario") %>
				<%= Html.ValidationMessage("IdUsuario", "*") %>
			</p>
			<p>
				<label for="Email">Email:</label>
				<%= Html.TextBox("Email") %>
				<%= Html.ValidationMessage("Email", "*") %>
			</p>
			<p>
				<label for="Senha">Senha:</label>
				<%= Html.TextBox("Senha") %>
				<%= Html.ValidationMessage("Senha", "*") %>
			</p>
			<p>
				<label for="DataInclusao">DataInclusao:</label>
				<%= Html.TextBox("DataInclusao") %>
				<%= Html.ValidationMessage("DataInclusao", "*") %>
			</p>
			<p>
				<label for="DataAlteracao">DataAlteracao:</label>
				<%= Html.TextBox("DataAlteracao") %>
				<%= Html.ValidationMessage("DataAlteracao", "*") %>
			</p>
			<p>
				<label for="Nome">Nome:</label>
				<%= Html.TextBox("Nome") %>
				<%= Html.ValidationMessage("Nome", "*") %>
			</p>
			<p>
				<label for="Sobrenome">Sobrenome:</label>
				<%= Html.TextBox("Sobrenome") %>
				<%= Html.ValidationMessage("Sobrenome", "*") %>
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
