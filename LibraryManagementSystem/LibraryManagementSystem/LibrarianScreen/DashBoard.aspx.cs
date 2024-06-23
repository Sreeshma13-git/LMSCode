using LibraryManagementSystem.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.LibrarianScreen
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    GetMostAvailableBook();
                    GetMostCheckedOutBook();
                    GetTotalNumberActiveMembers();
                }
            }

        }

        private void GetTotalNumberActiveMembers()
        {
            using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
            {
                using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadCommitted)))
                {
                    try
                    {
                        #region Selection
                        string usercount = dbconn.Datatbl_User.Where(m => m.user_is_active ?? false && (!m.user_is_admin ?? false)).Count().ToString();
                        lblTotalMembers.Text = usercount;
                        #endregion
                    }

                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }
        }

        private void GetMostCheckedOutBook()
        {
            using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
            {
                using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadCommitted)))
                {
                    try
                    {
                        #region Selection
                        var bookdetails = dbconn.Datatbl_Book_Details.AsNoTracking().
                            Where(k => !k.book_availability_status).
                            Select(m => new
                            {
                                permnt_tbl_genre_name = m.Permnt_tbl_Genre.permnt_tbl_genre_name,
                                book_genre_id = m.book_genre_id,
                            }).ToArray();

                        var coll = bookdetails.GroupBy(m => m.permnt_tbl_genre_name).
                            Select(n => new
                            {
                                count = n.Count(),
                                name = n.Key
                            }).ToArray();

                        string name = coll.OrderByDescending(l => l.count).Select(n => n.name).FirstOrDefault();

                        lblMostCheckedOutbooks.Text = name;
                        #endregion
                    }

                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        private void GetMostAvailableBook()
        {
            using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
            {
                using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadUncommitted)))
                {
                    try
                    {
                        #region Selection
                        var bookdetails = dbconn.Datatbl_Book_Details.AsNoTracking().
                            Where(k => k.book_availability_status).
                            Select(m => new
                            {
                                permnt_tbl_genre_name = m.Permnt_tbl_Genre.permnt_tbl_genre_name,
                                book_genre_id = m.book_genre_id,
                            }).ToArray();

                        var coll = bookdetails.GroupBy(m => m.permnt_tbl_genre_name).
                            Select(n => new
                            {
                                count = n.Count(),
                                name = n.Key
                            }).ToArray();

                        string name = coll.OrderByDescending(l => l.count).Select(n => n.name).FirstOrDefault();

                        lblMostAvailablebook.Text = name;
                        #endregion
                    }

                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}