using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Pages
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        private void FillPage()
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Models.ProductModel productModel = new Models.ProductModel();
                WebApplication1.Product product = productModel.GetProduct(id);

                lblPrice.Text = "Price per unit: <br/>$ " + product.Price;
                lblTitle.Text = product.Name;
                lblDescription.Text = product.Description;
                lblItemNr.Text = id.ToString();
                imgProduct.ImageUrl = "~/Images/Products/" + product.Image;

                int[] amount = Enumerable.Range(1, 20).ToArray();
                ddlAmount.DataSource = amount;
                ddlAmount.AppendDataBoundItems = true;
                ddlAmount.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                //int clientId = Convert.ToInt32(Context.User.Identity.GetUserId());
                int clientId = 1;

                if (clientId != null)

                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    int amount = Convert.ToInt32(ddlAmount.SelectedValue);

                    Purchase purchase = new Purchase
                    {

                        CustomerID = clientId,
                        ProductID = id,
                        Amount = amount,
                        Date = DateTime.Now.ToUniversalTime(),
                        IsInCart = true

                    };

                    Models.PurchaseModel model = new Models.PurchaseModel();
                    lblResult.Text = model.InsertPurchase(purchase);
                }
                else
                {
                    lblResult.Text = "Please Log In to Order";
                }
            }
        }
    }

   
}