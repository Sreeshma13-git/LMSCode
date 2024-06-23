using LibraryManagementSystem.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.UserScreen
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LblUserName.Text = Session["userfullname"].ToString();
                LabelUserNameinPara.Text = Session["userfullname"].ToString();
                string name = Session["username"].ToString();
                using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
                {
                    using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadCommitted)))
                    {
                        bool data = dbconn.Datatbl_User.AsNoTracking().
                        FirstOrDefault(n => n.user_name == name).user_is_active ?? false;

                        lblMemberStatus.Text = data ? "Active" : "In Active";
                        lblPara.Text = data ? "Enjoy your reading journey...!" : "";
                    }
                }
            }
        }
    }
}