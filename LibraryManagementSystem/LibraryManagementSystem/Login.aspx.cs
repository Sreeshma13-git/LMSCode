using LibraryManagementSystem.Database;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            //for user login
            using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
            {
                using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadUncommitted)))
                {
                    int pashash = TPassword.Text.GetHashCode();

                    var collect = dbconn.Datatbl_User.AsNoTracking().
                        Where(l => l.user_name == TUserName.Text && l.user_password == pashash.ToString()).
                        Select(m => new UserModel
                        {
                            UserName = m.user_name,
                            PassWord = m.user_password,
                            UserFirstName = m.user_full_name,
                            IsAdmin = m.user_is_admin ?? false
                        }).FirstOrDefault();

                    if (collect == null)
                    {
                        Response.Write("<script> alert('Invalid Credentials Please Try Agian');</script>");
                    }
                    else
                    {
                        Response.Write("<script> alert('Login Succesfull');</script>");
                        Session["username"] = collect.UserName;
                        Session["password"] = collect.PassWord;
                        Session["userfullname"] = collect.UserFirstName;
                        Session["isadmin"] = collect.IsAdmin;

                        if (collect.IsAdmin)
                        {
                            Response.Redirect("~/LibrarianScreen/LibrarianHomePage.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/UserScreen/UserHome.aspx");
                        }
                    }
                }

            }
        }
    }
}