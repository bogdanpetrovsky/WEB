<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Pages.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="litStatus" runat="server"></asp:Literal>
    <br />
    <br />
    UserName:<br />
    <br />
    <asp:TextBox ID="txtUserName" runat="server" CssClass="input"></asp:TextBox>
    <br />
    Password:<br />
    <br />
    <asp:TextBox ID="txtPassword" runat="server" CssClass="input"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnLogin" runat="server" CssClass="button" OnClick="btnLogin_Click" Text="Log In" />
    <br />
    <br />
</asp:Content>
