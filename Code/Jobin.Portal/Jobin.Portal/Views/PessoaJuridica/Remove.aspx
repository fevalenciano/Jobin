<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.PessoaJuridica>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<% using (Html.BeginForm()) {%>
		<fieldset>
			<legend>Confirma a exclusão do registro?</legend>
			<p>
				IdPessoaJuridica:
				<%= Html.Encode(Model.IdPessoaJuridica) %>
			</p>
			<p>
				IdFornecedor:
				<%= Html.Encode(Model.IdFornecedor) %>
			</p>
			<p>
				CNPJ:
				<%= Html.Encode(Model.CNPJ) %>
			</p>
			<p>
				RazaoSocial:
				<%= Html.Encode(Model.RazaoSocial) %>
			</p>
			<p>
				Site:
				<%= Html.Encode(Model.Site) %>
			</p>
			<p>
				Responsavel:
				<%= Html.Encode(Model.Responsavel) %>
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
