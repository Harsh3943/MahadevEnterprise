<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="MahadevEnterprise.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0 text-dark">Category</h1>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Home</li>
                        </ol>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content-header -->

        <!-- Main content -->
        <div class="content">
            <div class="container-fluid">
                <!-- SELECT2 EXAMPLE -->
                <div class="card card-default">
                    <div class="card-header">
                        <%--<h3 class="card-title">--%><%--Select2 (Default Theme)--%><%--</h3>--%>

                        <%--<div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-tool" data-card-widget="remove">
                                <i class="fas fa-times"></i>
                            </button>
                        </div>--%>
                    </div>
                    <!-- /.card-header -->
                    <div class="card-body">


                        <%--  <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Minimal</label>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="far fa-calendar-alt"></i></span>
                                        </div>
                                        <asp:TextBox ID="TextBox7" TextMode="Date" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Minimal</label>
                                    <asp:TextBox ID="TextBox8" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                                </div>




                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Minimal</label>
                                    <asp:TextBox ID="TextBox9" TextMode="Email" class="form-control" runat="server"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Minimal</label>
                                    <asp:TextBox ID="TextBox10" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Minimal</label>
                                    <asp:TextBox ID="TextBox11" class="form-control" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Minimal</label>
                                    <asp:TextBox ID="TextBox12" class="form-control" runat="server"></asp:TextBox>
                                </div>

                            </div>
                        </div>



                        <div class="row">
                            <div class="col-md-12">
                                <div class="card card-default">
                                    <div class="card-header">
                                        <h3 class="card-title">bs-stepper</h3>
                                    </div>
                                    <div class="card-body p-0">
                                        <div class="bs-stepper linear">
                                            <div class="bs-stepper-header" role="tablist">
                                                <!-- your steps here -->
                                                <div class="step active" data-target="#logins-part">
                                                    <button type="button" class="step-trigger" role="tab" aria-controls="logins-part" id="logins-part-trigger" aria-selected="true">
                                                        <span class="bs-stepper-circle">1</span>
                                                        <span class="bs-stepper-label">Logins</span>
                                                    </button>
                                                </div>
                                                <div class="line"></div>
                                                <div class="step" data-target="#information-part">
                                                    <button type="button" class="step-trigger" role="tab" aria-controls="information-part" id="information-part-trigger" aria-selected="false" disabled="disabled">
                                                        <span class="bs-stepper-circle">2</span>
                                                        <span class="bs-stepper-label">Various information</span>
                                                    </button>
                                                </div>
                                            </div>
                                            <div class="bs-stepper-content">
                                                <!-- your steps content here -->
                                                <div id="logins-part" class="content active dstepper-block" role="tabpanel" aria-labelledby="logins-part-trigger">

                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Minimal</label>
                                                                <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Minimal</label>
                                                                <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Minimal</label>
                                                                <asp:TextBox ID="TextBox3" class="form-control" runat="server"></asp:TextBox>
                                                            </div>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Country</label>
                                                                <asp:DropDownList ID="DropDownList1" class="form-control" runat="server"></asp:DropDownList>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Minimal</label>
                                                                <asp:DropDownList ID="DropDownList2" class="form-control" runat="server"></asp:DropDownList>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Minimal</label>
                                                                <asp:DropDownList ID="DropDownList3" class="form-control" runat="server"></asp:DropDownList>

                                                            </div>

                                                        </div>
                                                    </div>



                                                    <button class="btn btn-primary" onclick="stepper.next()">Next</button>
                                                </div>
                                                <div id="information-part" class="content" role="tabpanel" aria-labelledby="information-part-trigger">



                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Minimal</label>
                                                                <asp:TextBox ID="TextBox4" class="form-control" runat="server"></asp:TextBox>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Minimal</label>
                                                                <asp:TextBox ID="TextBox5" class="form-control" runat="server"></asp:TextBox>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Minimal</label>
                                                                <asp:TextBox ID="TextBox6" class="form-control" runat="server"></asp:TextBox>
                                                            </div>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Country</label>
                                                                <asp:DropDownList ID="DropDownList4" class="form-control" runat="server"></asp:DropDownList>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Minimal</label>
                                                                <asp:DropDownList ID="DropDownList5" class="form-control" runat="server"></asp:DropDownList>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Minimal</label>
                                                                <asp:DropDownList ID="DropDownList6" class="form-control" runat="server"></asp:DropDownList>

                                                            </div>

                                                        </div>
                                                    </div>
                                                    <button class="btn btn-primary" onclick="stepper.previous()">Previous</button>
                                                    <button type="submit" class="btn btn-primary">Submit</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.card-body -->
                                    <div class="card-footer">
                                        Visit <a href="https://github.com/Johann-S/bs-stepper/#how-to-use-it">bs-stepper documentation</a> for more examples and information about the plugin.
                                    </div>
                                </div>
                                <!-- /.card -->
                            </div>
                        </div>--%>



                        <asp:Panel ID="ListPanel" runat="server">


                            <div class="row">
                                <div class="col-md-12">
                                    
                                    <asp:TextBox ID="txtserch"  runat="server"></asp:TextBox>
                                    <asp:Button ID="btnserch"  runat="server"  Class="btn-info" Text="Serech" />
                                    <asp:Button ID="btnAddNew" OnClick="btnAddNew_Click" runat="server"  Class="btn-info" Text="AddCategory" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">


                                    <asp:GridView ID="GridCategory" class="table table-bordered table-striped dataTable dtr-inline" OnRowCommand="GridCategory_RowCommand"
                                        AutoGenerateColumns="false"
                                        runat="server">
                                        <Columns>

                                            <%--<asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="CategoryName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="Category Image ">
                                                <ItemTemplate>
                                                    <asp:Image ID="ImageCategory" Width="100px" Height="75px" ImageUrl='<%# "../ProductPhoto/"+ Eval("CategoryImage") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Detail">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDetail" runat="server" Text='<%# Eval("Detail") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="Email Id">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EmailId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>


                                            <asp:TemplateField>
                                                <ItemTemplate>

                                                    <asp:Button ID="btnEdit" CommandName="CategoryEdit" Class="btn btn-warning btn-md " CommandArgument='<%# Eval("CategoryId") %>' runat="server" Text="Edit" />
                                                    <asp:Button ID="BtnDelete" runat="server" Class="btn btn-primary btn-md "  CommandArgument='<%# Eval("CategoryId") %>' CommandName="CategoryDelete" Text="Delete" />
                                                    <asp:Button ID="BtnView" runat="server" Class="btn btn-secondary btn-md" CommandArgument='<%# Eval("CategoryId") %>' CommandName="CategoryView" Text="View" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>



                                </div>



                            </div>
                        </asp:Panel>

                        <asp:Panel ID="AddPanel" Visible="false" runat="server">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>CategoryName</label>
                                        <asp:TextBox ID="txtCategoryName" class="form-control" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Detail</label>
                                        <asp:TextBox ID="txtDetail" class="form-control" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                                <%--<div class="col-md-6">
                                    <div class="form-group">
                                        <label>CategoryImage</label>
                                        <asp:FileUpload ID="FileUploadImage" runat="server" />
                                    </div>

                                </div>--%>
                                <%--<div class="col-md-4">
                                    <div class="form-group">
                                        <label>EmailId</label>
                                        <asp:TextBox ID="txtEMailId" class="form-control" runat="server"></asp:TextBox>
                                    </div>

                                </div>--%>
                            </div>

                            <div class="row" style="margin: 15px">
                                    <div class="form-actions text-center">
                                        <div>
                                            <%--<asp:Button   ID="BtnUplod" OnClick="BtnUplod_Click"  runat="server" Text="UPLOD" class="btn btn-info btn-sm" ValidationGroup="a"  />--%>
                                         
                                            <asp:Button ID="BtnSubmit" OnClick="BtnSubmit_Click"  runat="server" Text="SUBMIT" class="btn btn-info btn-sm" ValidationGroup="a"  />
                                        </div>
                                    </div>

                                <%--<div class="col-md-4">
                                    <div class="form-group">

                                        <asp:Image ID="ImageProfileImage" Width="50%" runat="server" />

                                        <asp:Label ID="lblFilePath" runat="server" Text=""></asp:Label>
                                    </div>

                                    </div>--%>

                                </div>
                        </asp:Panel>

                    </div>
                    <!-- /.card-body -->
                    <%--<div class="card-footer">--%>
                        <%--Visit <a href="https://select2.github.io/">--%><%--Select2 documentation--%></a> <%--for more examples and information about
            the plugin.--%>
                    <%--</div>--%>
                </div>
                <!-- /.card -->

                <!-- /.row -->
            </div>
        </div>
        <!-- /.content -->
    </div>
</asp:Content>