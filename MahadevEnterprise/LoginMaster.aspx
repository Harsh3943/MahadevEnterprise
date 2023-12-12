<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginMaster.aspx.cs" Inherits="MahadevEnterprise.LoginMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>HCart | Log in (v2)</title>

    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="../../dist/css/adminlte.min.css">
</head>
<body class="hold-transition login-page"  >
    <form id="Login" runat="server" >
        <div class="login-box">
            <!-- /.login-logo -->
            <div class="card card-outline card-primary">
                <div class="card-header text-center">
                    <a href="../../index2.html" class="h1"><b>H</b>Cart</a>
                </div>
                <div class="card-body">
                    <p class="login-box-msg">Sign in to start your session</p>


                    <div class="input-group mb-3">
                      

                        <asp:TextBox ID="txtUserName" class="form-control" MaxLength="50" placeholder="Email" runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-envelope">
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                    

                        <asp:TextBox ID="txtPassword" TextMode="Password" MaxLength="10" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                                
                            </div>
                            
                        </div>
                        
                             <div class="input-group mb-3">

                            <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
                        <div class="input-group-append">
                            
                                
                            </div>
                            
                        </div>
                       
                    
                    <div class="row">
                        <div class="col-8">
                            <div class="icheck-primary">
                                <asp:CheckBox ID="CheckBoxRememberMe" runat="server" />
                                <label for="remember">
                                    Remember Me
             
                                </label>
                            </div>
                        </div>
                        <!-- /.col -->
                        <div class="col-4">

                            <asp:Button ID="btnLogin" OnClick="btnLogin_Click" class="btn btn-primary btn-block" runat="server" Text="Sign In" />
                            
                        </div>
                        <!-- /.col -->
                    </div>


                 
                    <p class="mb-1">
                        <a href="forgot-password.html">I forgot my password</a>
                    </p>
                    <p class="mb-0">
                        <a href="Registration.aspx" class="text-center">Register a new membership</a>
                    </p>
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.login-box -->

        <!-- jQuery -->
        <script src="../../plugins/jquery/jquery.min.js"></script>
        <!-- Bootstrap 4 -->
        <script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
        <!-- AdminLTE App -->
        <script src="../../dist/js/adminlte.min.js"></script>
    </form>
</body>
</html>
