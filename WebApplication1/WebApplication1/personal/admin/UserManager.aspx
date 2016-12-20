<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManager.aspx.cs" Inherits="WebApplication1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <asp:GridView class="table table-striped table-hover " ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1"><EditRowStyle BackColor="Green" /><SelectedRowStyle BackColor="Green" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text=""><i class="fa fa-check-square-o" aria-hidden="true"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text=""><i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text=""><i class="fa fa-ban" aria-hidden="true"></i></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="False" CommandName="Edit" Text=""><i class="fa fa-pencil" aria-hidden="true"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton8" runat="server" CausesValidation="False" CommandName="Delete" Text=""><i class="fa fa-trash-o" aria-hidden="true"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="LockoutEndDateUtc" HeaderText="LockoutEndDateUtc" SortExpression="LockoutEndDateUtc" />
            <asp:CheckBoxField DataField="LockoutEnabled" HeaderText="LockoutEnabled" SortExpression="LockoutEnabled" />
            <asp:BoundField DataField="AccessFailedCount" HeaderText="AccessFailedCount" SortExpression="AccessFailedCount" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AspNetUsers]"></asp:SqlDataSource>
</asp:Content>
