using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.LibrarianScreen
{
    public partial class LibrarianSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LblAdminName.Text ="Hi Admin," + Session["userfullname"].ToString();
                LabelAdminNameinPara.Text = Session["userfullname"].ToString();
            }
        }
    }
}