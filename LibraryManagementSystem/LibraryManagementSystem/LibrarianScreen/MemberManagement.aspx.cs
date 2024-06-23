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
    public partial class MemberManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindRepeator();
        }

        protected void UserUpdate_Click(object sender, EventArgs e)
        {
            using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
            {
                using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadUncommitted)))
                {
                    try
                    {
                        #region Update
                        int id = Convert.ToInt32(txtuserId.Text);
                        var userdetails = dbconn.Datatbl_User.FirstOrDefault(l => l.user_id == id);

                        userdetails.user_full_name = txtName.Text;
                        userdetails.user_adress = txtAdress.Text;
                        userdetails.user_contact_no = txtPhnNumber.Text;
                        userdetails.user_email = txtEmail.Text;
                        userdetails.user_name = txtEmail.Text;
                        userdetails.user_is_active = Convert.ToBoolean((int.Parse(DropDownmemeber.SelectedItem.Value)));
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

        protected void UserCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("MemberManagement.aspx");
        }

        protected void UserSubmit_Click(object sender, EventArgs e)
        {
            using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
            {
                using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadUncommitted)))
                {
                    try
                    {
                        var data = dbconn.Datatbl_User.AsNoTracking().
                         Where(k => k.user_full_name == txtName.Text && k.user_contact_no == txtPhnNumber.Text).ToArray();

                        if (data.Any())
                        {
                            Response.Write("<script>alert('Number already exist with anoother user please enter different number ')</script>");
                        }
                        else
                        {
                            #region Saving
                            string pass = "789";
                            int passHash = pass.GetHashCode();
                            Datatbl_User userdetails = new Datatbl_User();
                            userdetails.user_full_name = txtName.Text;
                            userdetails.user_name = txtEmail.Text;
                            userdetails.user_email = txtEmail.Text;
                            userdetails.user_password = passHash.ToString();
                            userdetails.user_adress = txtAdress.Text;
                            userdetails.user_contact_no = txtPhnNumber.Text;
                            userdetails.user_is_active = Convert.ToBoolean((int.Parse(DropDownmemeber.SelectedItem.Value)));
                            userdetails.user_is_admin = false;
                            dbconn.Datatbl_User.Add(userdetails);
                            dbconn.ChangeTracker.DetectChanges();
                            dbconn.SaveChanges();
                            transaction.Commit();
                            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success'),'Details Saved succesfully','success')", true);
                            BindRepeator();
                            clear();
                            #endregion
                        }
                    }

                    catch (Exception ex)
                    {
                        // ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error'),'error occured','Error')", true);
                        transaction.Rollback();
                        //throw;
                    }
                }
            }
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
                        var userdata = dbconn.Datatbl_User.
                                  Where(l => l.user_id == id).
                                  Select(l => new
                                  {
                                      user_full_name = l.user_full_name,
                                      user_adress = l.user_adress,
                                      user_contact_no = l.user_contact_no,
                                      user_is_active = l.user_is_active,
                                      user_email = l.user_email,
                                      user_id = l.user_id
                                  }).ToArray();

                        if (userdata.Any())
                        {
                            var data = userdata.FirstOrDefault();
                            txtName.Text = data.user_full_name;
                            txtAdress.Text = data.user_adress;
                            txtPhnNumber.Text = data.user_contact_no;
                            txtEmail.Text = data.user_email;
                            DropDownmemeber.SelectedItem.Text = (data.user_is_active ?? false) ? "Active" : "In Active";
                            DropDownmemeber.SelectedItem.Value = (data.user_is_active ?? false) ? "1" : "0";
                            txtuserId.Text = data.user_id.ToString();
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
                        var userdata = dbconn.Datatbl_User.
                                  FirstOrDefault(l => l.user_id == id);

                        if (userdata != null)
                        {
                            dbconn.Datatbl_User.Remove(userdata);
                            dbconn.ChangeTracker.DetectChanges();
                            dbconn.SaveChanges();
                            transaction.Commit();

                            BindRepeator();
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

        protected void BindRepeator()
        {
            using (LibraryDBEntitiesModels dbconn = new LibraryDBEntitiesModels())
            {
                using (var transaction = dbconn.Database.BeginTransaction((IsolationLevel.ReadCommitted)))
                {
                    #region Selection
                    var data = dbconn.Datatbl_User.AsNoTracking().
                              Where(m => !(m.user_is_admin ?? false)).
                              Select(l => new
                              {
                                  MemberName = l.user_full_name,
                                  Contactno = l.user_contact_no,
                                  Adress = l.user_adress,
                                  Status = (l.user_is_active ?? false) ? "Active" : "InActive",
                                  UserId = l.user_id
                              }).ToArray();
                    Repeater1.DataSource = data.ToList();
                    Repeater1.DataBind();
                    #endregion

                }
            }
        }

        protected void clear()
        {
            txtName.Text = string.Empty;
            txtAdress.Text = string.Empty;
            txtPhnNumber.Text = string.Empty;
            DropDownmemeber.SelectedItem.Text = "Status";
            txtEmail.Text = string.Empty;
            txtName.Focus();
        }

    }
}