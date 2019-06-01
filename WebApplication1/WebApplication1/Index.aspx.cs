using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Index : System.Web.UI.Page
    {
        public static int i = 0;
        public int temp = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        private void FillPage()
        {
            Models.ProductModel productModel = new Models.ProductModel();
            List<Product> products = productModel.GetAllProducts();

            if(products != null)
            {
                if (i > products.Count)
                {
                    foreach (Product product in products)
                    {
                        Panel productPanel = new Panel();
                        ImageButton imageButton = new ImageButton();
                        Label lblName = new Label();
                        Label lblPrice = new Label();

                        imageButton.ImageUrl = "~/Images/Products/" + product.Image;
                        imageButton.CssClass = "productImage";
                        imageButton.PostBackUrl = "~/Pages/Product.aspx?id=" + product.ID;

                        lblName.Text = product.Name;
                        lblName.CssClass = "productName";

                        lblPrice.Text = "$ " + product.Price;
                        lblPrice.CssClass = "productPrice";

                        productPanel.Controls.Add(imageButton);
                        productPanel.Controls.Add(new Literal {Text = "<br />"});
                        productPanel.Controls.Add(lblName);
                        productPanel.Controls.Add(new Literal {Text = "<br />"});
                        productPanel.Controls.Add(lblPrice);

                        pnlProducts.Controls.Add(productPanel);
                    }


                }
                else
                {
                    foreach (Product product in products)
                    {

                            temp++;
                        if (temp - 1 < i + 4 && temp > i)
                        {
                            Panel productPanel = new Panel();
                            ImageButton imageButton = new ImageButton();
                            Label lblName = new Label();
                            Label lblPrice = new Label();

                            imageButton.ImageUrl = "~/Images/Products/" + product.Image;
                            imageButton.CssClass = "productImage";
                            imageButton.PostBackUrl = "~/Pages/Product.aspx?id=" + product.ID;

                            lblName.Text = product.Name;
                            lblName.CssClass = "productName";

                            lblPrice.Text = "$ " + product.Price;
                            lblPrice.CssClass = "productPrice";

                            productPanel.Controls.Add(imageButton);
                            productPanel.Controls.Add(new Literal { Text = "<br />" });
                            productPanel.Controls.Add(lblName);
                            productPanel.Controls.Add(new Literal { Text = "<br />" });
                            productPanel.Controls.Add(lblPrice);

                            pnlProducts.Controls.Add(productPanel);


                        }


                    }
                    i += 4;
                }
            }
            else
            {
                pnlProducts.Controls.Add(new Literal { Text = "No products Found!" });
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Models.ProductModel productModel = new Models.ProductModel();
            List<Product> products = productModel.GetAllProducts();
            if (i <= products.Count)
                FillPage();
            else
            {
                i -= 4;
                temp -= 4;
                Label1.Visible = true;
                Label1.Text = "There are no more products!";
                FillPage();

            }
        }
    }
    
}