<%@ Page Title="Book management" Language="C#" MasterPageFile="~/LibrarianScreen/LibrarianSite.Master" AutoEventWireup="true" CodeBehind="BookManagement.aspx.cs" Inherits="LibraryManagementSystem.LibrarianScreen.BookManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--book entering--%>
    <div class="container border">
        <div class="row">
            <div class="col-lg-10 px-lg-4">
                <h4 class="text-base text-primary text-uppercase mb-4 text-center">Enter Book Detials</h4>
            </div>
        </div>

        <div class="row">

            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:TextBox ID="txtTitle" required="true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Title" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:TextBox ID="txtAuthorname" required="true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Author name" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:DropDownList ID="DropdwnGenere" required="true" CssClass="form-control shadow form-control-lg text-base" runat="server">
                        <asp:ListItem Text="Genre" Value="Genre"></asp:ListItem>
                        <asp:ListItem Text="Romance" Value="1" />
                        <asp:ListItem Text="Horror" Value="2" />
                        <asp:ListItem Text="Thriller" Value="3" />
                        <asp:ListItem Text="Crime" Value="4" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:DropDownList ID="DropDownAvailability" required="true" CssClass="form-control shadow form-control-lg text-base" runat="server">
                        <asp:ListItem Text="Availablity Status" Value="Availablity Status"></asp:ListItem>
                        <asp:ListItem Text="Available" Value="1" />
                        <asp:ListItem Text="Checked-out" Value="0" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:TextBox ID="txtBookId" runat="server" Visible="false"></asp:TextBox>
                </div>
            </div>



            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:Button ID="btnSubmit" Text="Submit" CssClass="btn btn-success" Height="50" Width="200" runat="server" OnClick="BookSubmit_Click" />
                    <asp:Button ID="btnUpdate" CssClass="btn btn-info" Height="50" Width="200" runat="server" Text="Update" Visible="false" OnClick="BookUpdate_Click" />
                    <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Height="50" Width="200" Text="Cancel" Visible="false" OnClick="BookCancel_Click" />
                </div>
            </div>

        </div>

    </div>
    <%--book entering ending--%>

    <%--book details view--%>
    <div class="container">
        <div class="row">
            <div class="table-responsive">
                <h4 class="text-base text-primary text-uppercase mb-4 text-left">All book details</h4>
                <hr />
              

                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_itemCommand">
                    <HeaderTemplate>
                        <table class="table table-bordered table-hover">
                            <thead class="alert-info">
                                <tr>
                                    <th><span>Book Name</span>   </th>
                                    <th><span>Author Name</span>   </th>
                                    <th><span>Genre</span>   </th>
                                    <th><span>Availabilty Status</span>   </th>
                                    <th>&nbsp </th>


                                </tr>
                            </thead>

                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("BookName") %></td>
                            <td><%#Eval("AuthorName") %></td>
                            <td><%#Eval("Genre") %></td>
                            <td><%#Eval("AvailabilityStatus") %></td>
                            <td hidden><%#Eval("BookId")%></td>

                            <td style="width: 10%">

                                <asp:LinkButton ID="LnkEdit" class="table-link text-primary" runat="server" CommandArgument='<%#Eval("BookId") %>' CommandName="EDIT" ToolTip="Edit">
                          <span class="fa-stack">  
                                    <i class="fa fa-square fa-stack-2x"> </i>
                                    <i class="fa fa-pencil fa-stack-1x fa-inverse"> </i>

                                </span>
                                </asp:LinkButton>

                                <asp:LinkButton ID="LnkDelete" class="table-link text-danger" runat="server" CommandArgument='<%#Eval("BookId") %>' CommandName="DELETE" Text="Delete" ToolTip="Delete" OnClientClick="return confirm('Do you want to delete this row?');">
                                <span class="fa-stack">  
                                    <i class="fa fa-square fa-stack-2x"> </i>
                                    <i class="fa fa-trash fa-stack-1x fa-inverse"> </i>

                                </span>
                                </asp:LinkButton>
                            </td>
                        </tr>

                    </ItemTemplate>

                    <FooterTemplate>
                        </tbody>
                            
                        </table>
                    </FooterTemplate>


                </asp:Repeater>
            </div>
        </div>
    </div>
    <%--book details view ending--%>
</asp:Content>
