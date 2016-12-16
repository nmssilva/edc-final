<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Presidente.aspx.cs" Inherits="WebApplication1.Presidente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Informação sobre o Presidente </h1>

    <asp:DetailsView GridLines="None" CssClass="table table-condensed table-hover" ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataSourceID="XmlDataSource1">
        <Fields>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
            <asp:BoundField DataField="Imagem" HeaderText="Imagem" SortExpression="Imagem" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
            <asp:BoundField DataField="Nascimento" HeaderText="Nascimento" SortExpression="Nascimento" />
            <asp:BoundField DataField="Inicio_Mandato" HeaderText="Inicio_Mandato" SortExpression="Inicio_Mandato" />
            <asp:BoundField DataField="Fim_Mandato" HeaderText="Fim_Mandato" SortExpression="Fim_Mandato" />
            <asp:BoundField DataField="Morte" HeaderText="Morte" SortExpression="Morte" />
            <asp:BoundField DataField="Partidos" HeaderText="Partidos" SortExpression="Partidos" />
            <asp:BoundField DataField="Esposa" HeaderText="Esposa" SortExpression="Esposa" />
        </Fields>
        </asp:DetailsView>

    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Presidentes.xml" TransformFile="~/presidente.xslt"></asp:XmlDataSource>

</asp:Content>
