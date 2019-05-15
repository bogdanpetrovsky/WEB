using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Purchase> carts = (List<Purchase>)Session[User.Identity.GetUserId()];
            PurchaseModel model = new PurchaseModel();
            model.MarkOrderAsPaid(carts);

            Session[User.Identity.GetUserId()] = null;
        }
    }
}