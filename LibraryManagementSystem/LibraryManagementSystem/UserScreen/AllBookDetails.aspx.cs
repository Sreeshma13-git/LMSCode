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
    public partial class AllBookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindRepeator();
        }


        protected void Repeater1_itemCommand(object source, RepeaterCommandEventArgs e)
        {
           
        }


        protected void BindRepeator()
        {
            using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
            {
                using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadCommitted)))
                {

                    var data = dbconn.Datatbl_Book_Details.AsNoTracking().
                    Select(l => new
                    {
                        BookName = l.book_title_name,
                        AuthorName = l.book_author_name,
                        Genre = l.Permnt_tbl_Genre.permnt_tbl_genre_name,
                        AvailabilityStatus = l.book_availability_status ? "Available" : "Checked-out",
                        Bookid = l.book_id
                    }).ToArray();
                    Repeater1.DataSource = data.ToList();
                    Repeater1.DataBind();
                }
            }
        }
    }
}