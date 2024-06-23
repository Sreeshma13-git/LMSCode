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
    public partial class BookManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindRepeator();
        }

        protected void BookSubmit_Click(object sender, EventArgs e)
        {
            using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
            {
                using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadUncommitted)))
                {

                    try
                    {
                        var data = dbconn.Datatbl_Book_Details.AsNoTracking().
                            Where(k => k.book_title_name == txtTitle.Text).ToArray();

                        if (data.Any())
                        {
                            Response.Write("<script>alert('Item Already Exists')</script>");
                        }
                        else
                        {

                            #region Saving
                            Datatbl_Book_Details bookdetails = new Datatbl_Book_Details();
                            bookdetails.book_title_name = txtTitle.Text;
                            bookdetails.book_author_name = txtAuthorname.Text;
                            bookdetails.book_genre_id = int.Parse(DropdwnGenere.SelectedItem.Value);
                            bookdetails.book_availability_status = Convert.ToBoolean((int.Parse(DropDownAvailability.SelectedItem.Value)));
                            dbconn.Datatbl_Book_Details.Add(bookdetails);
                            dbconn.ChangeTracker.DetectChanges();
                            dbconn.SaveChanges();
                            transaction.Commit();
                            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success'),'Details Saved succesfully','success')", true);
                            BindRepeator();
                            clear();
                            #endregion
                        }
                    }

                    catch (Exception)
                    {
                        Response.Write("<script>alert('Error')</script>");
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        protected void BookUpdate_Click(object sender, EventArgs e)
        {
            using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
            {
                using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadUncommitted)))
                {
                    try
                    {
                        #region Update
                        int id = Convert.ToInt32(txtBookId.Text);
                        var bookdetails = dbconn.Datatbl_Book_Details.FirstOrDefault(l => l.book_id == id);

                        bookdetails.book_title_name = txtTitle.Text;
                        bookdetails.book_author_name = txtAuthorname.Text;
                        bookdetails.book_genre_id = int.Parse(DropdwnGenere.SelectedItem.Value);
                        bookdetails.book_availability_status = Convert.ToBoolean((int.Parse(DropDownAvailability.SelectedItem.Value)));
                        dbconn.ChangeTracker.DetectChanges();
                        dbconn.SaveChanges();
                        transaction.Commit();
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success'),'Details Saved succesfully','success')", true);
                        BindRepeator();
                        clear();
                        #endregion

                        btnUpdate.Visible = false;
                        btnCancel.Visible = false;
                        btnSubmit.Visible = true;

                    }

                    catch (Exception)
                    {
                        // ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error'),'error occured','Error')", true);
                        transaction.Rollback();
                        //throw;
                    }
                }
            }
        }

        protected void BookCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("BookManagement.aspx");
        }

        protected void Repeater1_itemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "EDIT")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                UpdateData(Convert.ToInt32(id));
            }
            else if (e.CommandName == "DELETE")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                Deletedata(Convert.ToInt32(id));
            }
        }

        private void UpdateData(int id)
        {
            using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
            {
                using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadCommitted)))
                {
                    try
                    {
                        #region Selection
                        var bookdata = dbconn.Datatbl_Book_Details.
                                  Where(l => l.book_id == id).
                                  Select(l => new
                                  {
                                      BookName = l.book_title_name,
                                      AuthorName = l.book_author_name,
                                      Genre = l.Permnt_tbl_Genre.permnt_tbl_genre_name,
                                      Genreid = l.book_genre_id,
                                      AvailabilityStatus = l.book_availability_status,
                                      Bookid = l.book_id
                                  }).ToArray();

                        if (bookdata.Any())
                        {
                            var data = bookdata.FirstOrDefault();
                            txtTitle.Text = data.BookName;
                            txtAuthorname.Text = data.AuthorName;
                            DropdwnGenere.SelectedItem.Text = data.Genre;
                            DropdwnGenere.SelectedItem.Value = data.Genreid.ToString();
                            DropDownAvailability.SelectedItem.Text = data.AvailabilityStatus ? "Available" : "Checked-out";
                            DropDownAvailability.SelectedItem.Value = data.AvailabilityStatus ? "1" : "0";
                            txtBookId.Text = data.Bookid.ToString();
                            btnSubmit.Visible = false;
                            btnUpdate.Visible = true;
                            btnCancel.Visible = true;
                        }
                        #endregion
                    }

                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        private void Deletedata(int id)
        {
            using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
            {
                using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadUncommitted)))
                {
                    try
                    {
                        #region Delete
                        var bookdata = dbconn.Datatbl_Book_Details.
                                  FirstOrDefault(l => l.book_id == id);

                        if (bookdata != null)
                        {
                            dbconn.Datatbl_Book_Details.Remove(bookdata);
                            dbconn.SaveChanges();
                            transaction.Commit();
                            BindRepeator();
                        }
                        #endregion
                    }

                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        protected void BindRepeator()
        {
            using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
            {
                using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadCommitted)))
                {
                    #region Selection
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
                    #endregion
                }
            }
        }

        protected void clear()
        {
            txtTitle.Text = string.Empty;
            txtAuthorname.Text = string.Empty;
            DropdwnGenere.SelectedItem.Text = "Genre";
            DropDownAvailability.SelectedItem.Text = "Availability Status";
            txtTitle.Focus();
        }


    }
}