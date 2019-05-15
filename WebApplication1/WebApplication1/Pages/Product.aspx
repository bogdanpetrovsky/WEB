<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="WebApplication1.Pages.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td rowspan ="4">
                <asp:Image ID="imgProduct" runat="server" CssClass ="detailsImage"/> </td>
            <td><h2>
                    <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
                    <hr/>
                </h2></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescription" runat="server" CssClass ="detailsDescription"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPrice" runat="server" CssClass="detailsPrice"></asp:Label> </td><br/>
            Quantity :
            <asp:DropDownList ID="ddlAmount" runat="server"></asp:DropDownList> <br/>
            <asp:Button ID="btnSubmit" runat="server" OnClick="Button1_Click" Text="Add to Cart" Width="120px" CssClass="button"/>
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </tr>
        <tr>
            <td>Product Number: <asp:Label ID="lblItemNr" runat="server" Text="Label"></asp:Label> </td>

        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Available" CssClass ="productPrice"></asp:Label> </td>

        </tr>
    </table>
</asp:Content>
