using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Pages.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //В Get-версии метода Login мы получаем адрес для возврата в виде параметра returnUrl и передаем его в модель LoginViewModel.
        //Post-version Login 
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Microsoft.AspNet.Identity.EntityFramework.UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

            userStore.Context.Database.Connection.ConnectionString =
                System.Configuration.ConfigurationManager.
                ConnectionStrings["GarageDBConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            var user = manager.Find(txtUserName.Text, txtPassword.Text);

            if(user !=null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;//Инкапсулирует все связанные с НТТР сведения об отдельном НТТР-запросе.
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
                {
                    IsPersistent = false//Відповідає за збереження даних логування після закриття браузера
                }, userIdentity);

                Response.Redirect("~/Index.aspx");
            }
            else
            {
                litStatus.Text = "Wrong username or password";
            }

        }
    }
}