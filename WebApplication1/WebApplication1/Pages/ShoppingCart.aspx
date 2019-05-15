<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="WebApplication1.Pages.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID ="pnlShoppingCart" runat ="server">

    </asp:Panel>  
    
    <table>
        <tr>
            <td><b>Total:</b></td>
            <td><asp:Literal ID="litTotal" runat ="server" Text="" /></td>
        </tr>

        <tr>
            <td><b>Vat:</b></td>
            <td><asp:Literal ID="litVat" runat ="server" Text="" /></td>
        </tr>

        <tr>
            <td><b>Shipping:</b></td>
            <td>$ 15</td>
        </tr>

        <tr>
            <td class="auto-style1"><b>Total:</b></td>
            <td class="auto-style1"><asp:Literal ID="litTotalAmount" runat ="server" Text="" /></td>
        </tr>

        <tr>
            <td>
                <asp:LinkButton ID="lnkContinue" runat="server" PostbackUrl ="~/Index.aspx"
                    CssClass ="button" Width="250px" Text="Continue shopping" />
                OR
                <asp:Button ID="btnCheckOut" runat="server" PostbackUrl ="~/Pages/Success.aspx"
                    CssClass ="button" Width="250px" Text="Continue CheckOut" OnClick="btnCheckOut_Click" />
                
            </td>
            
        </tr>

    </table>
</asp:Content>
