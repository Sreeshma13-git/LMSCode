<%@ Page Title="" Language="C#" MasterPageFile="~/LibrarianScreen/LibrarianSite.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="LibraryManagementSystem.LibrarianScreen.DashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row">
        <div class="col-lg-4 mb-4">
            <!--  card 1-->
            <div class="card h-100 border-start-lg border-start-primary">
                <div class="card-body">
                    <div class="small text-muted"> Most Available Book Genre</div>
                    <div class="h3"> <asp:Label ID="lblMostAvailablebook" runat="server" Text="Label"></asp:Label></div>
                    
                </div>
            </div>
        </div>
        <div class="col-lg-4 mb-4">
            <!-- Billing card 2-->
            <div class="card h-100 border-start-lg border-start-secondary">
                <div class="card-body">
                    <div class="small text-muted"> Most Checked-out Book Genre </div>
                    <div class="h3"><asp:Label ID="lblMostCheckedOutbooks" runat="server" Text="Label"></asp:Label></div>
                    
                </div>
            </div>
        </div>
        <div class="col-lg-4 mb-4">
            <!-- Billing card 3-->
            <div class="card h-100 border-start-lg border-start-success">
                <div class="card-body">
                    <div class="small text-muted">Total Active Members</div>
                    <div class="h3 d-flex align-items-center"><asp:Label ID="lblTotalMembers" runat="server" Text="Label"></asp:Label></div>
                   
                </div>
            </div>
        </div>
    </div>

</asp:Content>
