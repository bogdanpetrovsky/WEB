<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication1.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlProducts" runat="server">
</asp:Panel>
    <asp:Button ID="Button1"  runat="server" CssClass="button" OnClick="Button1_Click" Text="Show More" />
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    <div style = "clear:both"> </div>
</asp:Content>
