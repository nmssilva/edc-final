<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Presidente.aspx.cs" Inherits="WebApplication1.Presidente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Informação sobre o Presidente </h1>

    <asp:DetailsView GridLines="None" CssClass="table table-condensed table-hover" ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataSourceID="XmlDataSource1">
        <Fields>
            <asp:TemplateField HeaderText="Título" SortExpression="ID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ID") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ID") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID","{0}º Presidente de Portugal") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ImageField DataImageUrlField="Imagem">
                <ControlStyle Width="300px" />
            </asp:ImageField>
            <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
            <asp:BoundField DataField="Nascimento" HeaderText="Data de Nascimento" SortExpression="Nascimento" />
            <asp:BoundField DataField="Morte" HeaderText="Data de Morte" SortExpression="Morte" />
            <asp:BoundField DataField="Inicio_Mandato" HeaderText="Inicio de Mandato" SortExpression="Inicio_Mandato" />
            <asp:BoundField DataField="Fim_Mandato" HeaderText="Fim de Mandato" SortExpression="Fim_Mandato" />
            <asp:BoundField DataField="Partido" HeaderText="Partido" SortExpression="Partido" />
            <asp:BoundField DataField="Esposa" HeaderText="Esposa" SortExpression="Esposa" />
        </Fields>
        </asp:DetailsView>

    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Presidentes.xml" TransformFile="~/presidentes.xslt"></asp:XmlDataSource>

</asp:Content>
