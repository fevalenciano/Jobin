<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Jobin.Model.PessoaJuridica>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Object
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Data Object</h2>

	<fieldset>
		<legend>Campos</legend>
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
	</fieldset>

	<p>
		<%=Html.ActionLink("Editar", "Edit", new { IdPessoaJuridica = Model.IdPessoaJuridica }) %> | 
		<%=Html.ActionLink("Voltar para Lista", "Index")%>
	</p>

</asp:Content>
