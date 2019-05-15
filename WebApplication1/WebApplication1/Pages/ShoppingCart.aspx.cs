﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = User.Identity.GetUserId();
            GetPurchasesInCart(userId);
        }

        private void GetPurchasesInCart(string userId)
        {
            PurchaseModel model = new PurchaseModel();
            double subTotal = 0;

            List<Purchase> purchaseList = model.GetOrdersInPurchase(userId);
            CreateShopTable(purchaseList, out subTotal);

            double vat = subTotal * 0.1;
            double totalAmount = subTotal + vat + 15;

            litTotal.Text = "$ " + subTotal;
            litVat.Text = "$ " + vat;
            litTotalAmount.Text = "$ " + totalAmount;
        }

        private void CreateShopTable(List<Purchase> purchaseList, out double subTotal)
        {
            subTotal = new Double();
            ProductModel model = new ProductModel();

            foreach(Purchase purchase in purchaseList)
            {
                WebApplication1.Product product = model.GetProduct(purchase.ProductID);


                ImageButton btnImage = new ImageButton
                {
                    ImageUrl = string.Format("~/Images/Products/{0}", product.Image),
                    PostBackUrl = string.Format("~/Pages/Product.aspx?id={0}", product.ID),
                    CssClass = "productImage"
                };

                LinkButton lnkDelete = new LinkButton
                {
                    PostBackUrl = string.Format("~/Pages/ShoppingCart.aspx?id={0}", purchase.ID),
                    Text = "Delete Item",
                    ID = "del" + purchase.ID
                };

                lnkDelete.Click += Delete_Item;

                int[] amount = Enumerable.Range(1, 20).ToArray();
                DropDownList ddlAmount = new DropDownList
                {
                    DataSource = amount,
                    AppendDataBoundItems = true,
                    AutoPostBack = true,
                    ID = purchase.ID.ToString()
                };

                ddlAmount.DataBind();
                ddlAmount.SelectedValue = purchase.Amount.ToString();
                ddlAmount.SelectedIndexChanged += ddlAmount_SelectedIndexChanged;

                Table table = new Table { CssClass = "CartTable" };
                TableRow row1 = new TableRow();
                TableRow row2 = new TableRow();

                TableCell cell1_1 = new TableCell { RowSpan = 2, Width = 50 };
                TableCell cell1_2 = new TableCell
                {
                    Text = string.Format("<h4>{0}</h4><br />{1}<br/>In Stock",
                    product.Name, "Item No:" + product.ID),
                    HorizontalAlign = HorizontalAlign.Left,
                    Width = 350,
                };
                TableCell cell1_3 = new TableCell { Text = "Unit Price<hr/>" };
                TableCell cell1_4 = new TableCell { Text = "Quantity<hr/>" };
                TableCell cell1_5 = new TableCell { Text = "Item Total<hr/>" };
                TableCell cell1_6 = new TableCell();

                TableCell cell2_1 = new TableCell();
                TableCell cell2_2 = new TableCell { Text = "$ " + product.Price };
                TableCell cell2_3 = new TableCell();
                TableCell cell2_4 = new TableCell { Text = "$ " + Math.Round((purchase.Amount * product.Price), 2) };
                TableCell cell2_5 = new TableCell();

                // Set custom controls
                cell1_1.Controls.Add(btnImage);
                cell1_6.Controls.Add(lnkDelete);
                cell2_3.Controls.Add(ddlAmount);

                // Add rows & cells to table
                row1.Cells.Add(cell1_1);
                row1.Cells.Add(cell1_2);
                row1.Cells.Add(cell1_3);
                row1.Cells.Add(cell1_4);
                row1.Cells.Add(cell1_5);
                row1.Cells.Add(cell1_6);

                row2.Cells.Add(cell2_1);
                row2.Cells.Add(cell2_2);
                row2.Cells.Add(cell2_3);
                row2.Cells.Add(cell2_4);
                row2.Cells.Add(cell2_5);
                table.Rows.Add(row1);
                table.Rows.Add(row2);
                pnlShoppingCart.Controls.Add(table);

                // Add total of current purchased item to subtotal
                subTotal += (purchase.Amount * Convert.ToInt32(product.Price));
            }

            // Add selected objects to Session
            Session[User.Identity.GetUserId()] = purchaseList;
        }

        private void ddlAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList selectedList = (DropDownList)sender;
            int quantity = Convert.ToInt32(selectedList.SelectedValue);
            int cartId = Convert.ToInt32(selectedList.ID);

            PurchaseModel model = new PurchaseModel();
            model.UpdateQuantity(cartId, quantity);
            Response.Redirect("~/Pages/ShoppingCart.aspx");
        }

        private void Delete_Item(object sender, EventArgs e)
        {
            LinkButton selectedLink = (LinkButton)sender;
            string link = selectedLink.ID.Replace("del", "");
            int cartId = Convert.ToInt32(link);

            PurchaseModel model = new PurchaseModel();
            model.DeletePurchase(cartId);
            Response.Redirect("~/Pages/ShoppingCart.aspx");
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {

        }
    }
}