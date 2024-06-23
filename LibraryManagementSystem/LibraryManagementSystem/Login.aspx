<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibraryManagementSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <%--Bootstrap CSS--%>

    <link href="Bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <%--Datatable CSS--%>

    <link href="Datatables/css/dataTables.dataTables.min.css" rel="stylesheet" />

    <%--FontAwesome CSS--%>

    <link href="fontawesome/fontawesome-free-6.5.2-web/css/all.css" rel="stylesheet" />

    <%--Jquery js--%>
    <script src="Bootstrap/js/jquery-3.3.1.slim.min.js"></script>

    <%--popper js--%>

    <script src="Bootstrap/js/popper.min.js"></script>

    <%--Bootstrap js--%>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-sm navbar-dark bg-primary">
                <a class="navbar-brand" href="Index.aspx">
                    <img src="LogoImg/image.png" alt="logo" width="49" height="49" /> Library</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                    <span class="navbar-toggler-icon"></span>
                </button>


                <%--Menu Bar--%>
                <div class="collapse navbar-collapse" id="collapsibleNavbar">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Home</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Contact us</b></a>
                        </li>
                    </ul>
                </div>



            </nav>


            <%--Centre library management sytem--%>
            <div class="jumbotron text-center alert alert-primary" style="margin-bottom: 0">
                <%--<a class="navbar-brand" href="#"><img src="LogoImg/back.jpg"  width="1200" height=450"  /></a>--%>
                <h1>Welcome to library world please give credentials to login</h1>
                <p>Enter your credentials to login!</p>
            </div>

            <div class="col-sm-20 border border-info">
                <%--Login screen--%>
                <div class="container mt-3">
                    <!-- Tab panes -->
                    <div class="tab-content">
                        <div id="home" class="container tab-pane active">
                            <br>
                            <%--<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>--%>

                            <%--design login form--%>

                            <div class="container">
                                <div class="row">
                                    <div class="col-md-6 mx-auto">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col">
                                                        <center>
                                                            <img width="150" src="LogoImg/user.jpg" />
                                                        </center>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col">
                                                        <center>
                                                            <h3>Login...!</h3>
                                                        </center>

                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col">

                                                        <hr />

                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col">

                                                        <label>User Name</label>
                                                        <div class="form-group">
                                                            <asp:TextBox ID="TUserName" CssClass="form-control" placeholder="User Name" runat="server"></asp:TextBox>
                                                        </div>

                                                        <label>Password</label>
                                                        <div class="form-group">
                                                            <asp:TextBox ID="TPassword" CssClass="form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                                                        </div>

                                                        <label></label>

                                                        <div class="form-group">
                                                            <asp:Button ID="ButtonLogin" CssClass="btn btn-success btn-lg w-100" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
                                                        </div>
                                                    </div>
                                                  
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                </div>
                            </div>

                            <%--design end--%>
                        </div>
                        <%-- <div id="menu1" class="container tab-pane fade">
                            <br>
                            <h3>Menu 1</h3>
                            <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                        </div>
                        <div id="menu2" class="container tab-pane fade">
                            <br>
                            <h3>Menu 2</h3>
                            <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam.</p>
                        </div>--%>
                    </div>
                </div>
                <!----End login---->
            </div>


          
        </div>
    </form>
</body>
</html>
