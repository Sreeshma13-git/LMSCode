<%@ Page Title="Member Management" Language="C#" MasterPageFile="~/LibrarianScreen/LibrarianSite.Master" AutoEventWireup="true" CodeBehind="MemberManagement.aspx.cs" Inherits="LibraryManagementSystem.LibrarianScreen.MemberManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container border">
        <div class="row">
            <div class="col-lg-10 px-lg-4">
                <h4 class="text-base text-primary text-uppercase mb-4 text-center">Enter Member Details</h4>
            </div>
        </div>

        <div class="row">

            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:TextBox ID="txtName" required="true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Name" runat="server"></asp:TextBox>
                </div>
            </div>
             <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:TextBox ID="txtEmail" required="true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Email" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:TextBox ID="txtAdress" required="true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Adress" runat="server"></asp:TextBox>
                </div>
            </div>

             <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:TextBox ID="txtPhnNumber" required="true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Contact No" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:DropDownList ID="DropDownmemeber" required="true" CssClass="form-control shadow form-control-lg text-base" runat="server">
                        <asp:ListItem Text="Membership Status" Value="Status"></asp:ListItem>
                        <asp:ListItem Text="Active" Value="1" />
                        <asp:ListItem Text="In Active" Value="0" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:TextBox ID="txtuserId" runat="server" Visible="false"></asp:TextBox>
                </div>
            </div>



            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:Button ID="btnSubmit" Text="Submit" CssClass="btn btn-success" Height="50" Width="200" runat="server" OnClick="UserSubmit_Click" />
                    <asp:Button ID="btnUpdate" CssClass="btn btn-info" Height="50" Width="200" runat="server" Text="Update" Visible="false" OnClick="UserUpdate_Click" />
                    <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Height="50" Width="200" Text="Cancel" Visible="false" OnClick="UserCancel_Click" />
                </div>
            </div>

        </div>

    </div>

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
                                    <th><span>Member Name</span>   </th>
                                    <th><span>Adress</span>   </th>
                                    <th><span>Contact no</span>   </th>
                                    <th><span>Status</span>   </th>
                                    <th>&nbsp </th>


                                </tr>
                            </thead>

                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("MemberName") %></td>
                            <td><%#Eval("Adress") %></td>
                            <td><%#Eval("Contactno") %></td>
                            <td><%#Eval("Status") %></td>
                            <td hidden><%#Eval("UserId")%></td>

                            <td style="width: 10%">

                                <asp:LinkButton ID="LnkEdit" class="table-link text-primary" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="EDIT" ToolTip="Edit">
                          <span class="fa-stack">  
                                    <i class="fa fa-square fa-stack-2x"> </i>
                                    <i class="fa fa-pencil fa-stack-1x fa-inverse"> </i>

                                </span>
                                </asp:LinkButton>

                                <asp:LinkButton ID="LnkDelete" class="table-link text-danger" runat="server" CommandArgument='<%#Eval("UserId") %>' CommandName="DELETE" Text="Delete" ToolTip="Delete" OnClientClick="return confirm('Do you want to delete this row?');">
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
</asp:Content>
