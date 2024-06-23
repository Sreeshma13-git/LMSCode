<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/UserScreen/User.Master" AutoEventWireup="true" CodeBehind="AllBookDetails.aspx.cs" Inherits="LibraryManagementSystem.UserScreen.AllBookDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%--book details view--%>
    <div class="container">
        <div class="row">
            <div class="table-responsive">
                <h4>Book List</h4>
                <hr />
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_itemCommand">
                    <HeaderTemplate>
                        <table class="table table-bordered table-hover">
                            <thead class="alert-info">
                                <tr>
                                    <th style="background-color:cornflowerblue"><span>Book Name</span> </th>
                                    <th style="background-color:cornflowerblue"><span>Author Name</span> </th>
                                    <th style="background-color:cornflowerblue"><span>Genre</span> </th>
                                    <th style="background-color:cornflowerblue"><span>Availabilty Status</span> </th>
                                </tr>
                            </thead>
                            <tbody>
                      </HeaderTemplate>
                    <ItemTemplate>
                       <tr> 
                           <td><%#Eval("BookName") %> </td>
                           <td><%#Eval("AuthorName") %> </td>
                           <td><%#Eval("Genre") %> </td>
                           <td><%#Eval("AvailabilityStatus") %> </td>
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
