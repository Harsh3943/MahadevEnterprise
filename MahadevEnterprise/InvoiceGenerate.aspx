 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InvoiceGenerate.aspx.cs" Inherits="MahadevEnterprise.InvoiceGenerate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="padding:0px 0px 0px 243px";>
  <div class="invoice p-3 mb-3">

<div class="row">
<div class="col-12">
<h4>
<i class="fas fa-globe"></i> MAHADEV ENTERPRISE PVTL.LTD
<small class="float-right">Date:<asp:Label ID="lbldate" runat="server" Text=""></asp:Label></small>
</h4>
</div>
</div>

<div class="row invoice-info">
<div class="col-sm-4 invoice-col">
From
<address>
<strong>Admin, Inc.</strong><br>
795 Folsom Ave, Suite 600<br>
San Francisco, CA 94107<br>
Phone: (804) 123-5432<br>
Email: info@almasaeedstudio.com
</address>
</div>

<div class="col-sm-4 invoice-col">
To
<address>
<strong>
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label></strong><br>
    <asp:Label ID="lblAdress" runat="server" Text=""></asp:Label><br>
Phone: <asp:Label ID="lblMobileNumber" runat="server" Text=""></asp:Label><br>
Email:<asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
</address>
</div>

<div class="col-sm-4 invoice-col">
<b>Invoice ID:</b><asp:Label ID="lblInvoiceId" runat="server" Text=""></asp:Label><br>
<b>Order ID:</b> <asp:Label ID="lblOrderId" runat="server" Text=" "></asp:Label><br>
<b>Coustumer ID:</b> <asp:Label ID="lblCoustumerId" runat="server" Text=" "></asp:Label><br>
<%--<b>Account:</b> 968-34567--%>
</div>

</div>


<div class="row">
<div class="col-12 table-responsive">
<table class="table table-striped">
<thead>
<tr>
<th>Qty</th>
<th>Product</th>
<th>Product ID</th>
<th>Description</th>
<th>Subtotal</th>
</tr>
</thead>
<tbody>
<tr>
<td><asp:Label ID="lblQuantity" runat="server" Text=""></asp:Label></td>
<td><asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></td>
<td><asp:Label ID="Labelid" runat="server" Text=" "></asp:Label></td>
<td><asp:Label ID="lblDescription" runat="server" Text=" "></asp:Label></td>
<td><asp:Label ID="lblSubTotal" runat="server" Text=" "></asp:Label>₹</td>
</tr>
</tbody>
</table>
</div>

</div>

<div class="row">

<div class="col-6">
<p class="lead">Payment Methods:</p>
<img src="../../dist/img/credit/visa.png" alt="Visa">
<img src="../../dist/img/credit/mastercard.png" alt="Mastercard">
<img src="../../dist/img/credit/american-express.png" alt="American Express">
<img src="../../dist/img/credit/paypal2.png" alt="Paypal">
<p class="text-muted well well-sm shadow-none" style="margin-top: 10px;">
Declaration :<br />

We declare that this invoice shows the actual price of the goods described and that all particulars are true and correct.

</p>
</div>

<div class="col-6">
<p class="lead">Amount Due 2/22/2014</p>
<div class="table-responsive">
<table class="table">
<tbody><tr>
<th style="width:50%">Subtotal:</th>
<td>
    <asp:Label ID="lblSubtotalLower" runat="server" Text=" "></asp:Label>₹</td>
</tr>
<tr>
<th>Tax (9.3%)</th>
<td>
    <asp:Label ID="lblTax" runat="server" Text=" "></asp:Label>₹</td>
</tr>
<tr>
<th>GST:</th>
<td>
    <asp:Label ID="lblGst" runat="server" Text=" "></asp:Label>₹</td>
</tr>
<tr>
<th>CGST:</th>
<td>
    <asp:Label ID="lblCGST" runat="server" Text=" "></asp:Label>₹</td>
</tr>
<tr>
<th>Total:</th>
<td>
    <asp:Label ID="lblTotal" runat="server" Text=" "></asp:Label>₹</td>
</tr>
</tbody></table>
</div>
</div>

</div>


<div class="row no-print">
<div class="col-12">
<a href="" rel="noopener" target="_blank" class="btn btn-default">
    <i class="fas fa-print"></i> Print
</a>
<button type="button" class="btn btn-success float-right"><i class="far fa-credit-card"></i> Submit
Payment
</button>
<asp:Button ID="btnpdf"  type="button" class="btn btn-primary float-right" style="margin-right: 5px;">
<i class="fas fa-download"></i> Generate PDF
</asp:Button>
</div>
</div>
</div>
        </div>
</asp:Content>
