<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SIgnUp.aspx.cs" Inherits="SignUpForm_Swapnil.SIgnUp" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
     <style>
        .ui-datepicker-trigger 
        { 
                position: relative;
                top: -1px;
                right: -6px;
                height: 36px;
        }
        .d-flex{
            display: flex;
        }
        .justify-content-center{
            justify-content: center;
        }
        table td,
        table tr{
            border: none !important;
        }
        .singupForm{
            padding: 15px;
            border: 2px solid lightgray;
            border-radius: 3px;
            margin-top: 20px;
            background-color: #fbfbfb;
        }
    </style>
     <div>
        <a href="LogIn.aspx">LogIn</a>
    </div>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container d-flex justify-content-center" >
            
                <div class="col-lg-6 col-md-6 singupForm">
                     <table class="auto-style1 table ">
                    <h3 align="center">Registration Form</h3>
                    <br />
                    <br />



                    <tr>
                        <td> 
                            <label>First Name :</label>     
                            </td>
                        <td>
                            <div class="from-group">
                                <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" required="required"></asp:TextBox>
                            </div>
                            
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <label>Middle Name :</label> 
                        </td>
                        <td>
                             <div class="from-group">
                            <asp:TextBox ID="txtMidName" CssClass="form-control" runat="server"></asp:TextBox>
                                 </div>
                        </td>

                    </tr>
                    <tr>
                        <td><label>Last Name :</label> </td>
                      
                        <td>
                            <asp:TextBox ID="txtLstName" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td> <label>DOB :</label> </td>
                        <td>
                           <div style="display: flex;">
                            <asp:TextBox ID="txtDate" runat="server"  CssClass="form-control" ReadOnly="true" required="required"></asp:TextBox>
                        </div>

                        </td>

                    </tr>
                    <tr>
                        <td><label>Address</label></td>
                        <td>
                            <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><label>City</label></td>
                        <td>
                            <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><label>State</label></td>
                        <td>
                            <asp:TextBox ID="txtState" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><label>Pin Code</label></td>
                        <td>
                            <asp:TextBox ID="txtPinCode" CssClass="form-control" runat="server" Width="150px" MaxLength="6" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;" required="required"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><label>Mobile No.</label></td>
                        <td>
                            <asp:TextBox ID="txtMoNo" CssClass="form-control" runat="server" Width="150px" MaxLength="10" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;" required="required"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><label>Email</label></td>
                        <td>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email" required="required"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><label>Pan No.</label></td>
                        <td>
                            <asp:TextBox ID="txtPanNumber" CssClass="form-control" runat="server" required="required" MaxLength="10" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><label>Pan Doc</label></td>
                        <td>
                            <div>
                                <asp:FileUpload ID="FilePan" runat="server" CssClass="form-control" />
                                <%--<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUploadClick" />--%>
                                <asp:Label ID="lblFileName" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td><label>Aadhar No.</label></td>
                        <td>
                            <asp:TextBox ID="txtAadhar" runat="server" CssClass="form-control" required="required" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td><label>Aadhar front Img</label></td>
                        <td>
                            <div>
                                <asp:FileUpload ID="FileAadFront" CssClass="form-control" runat="server" />
                                <%--<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUploadClick" />--%>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td><label>Aadhar back Img</label></td>
                        <td>
                            <div>
                                <asp:FileUpload ID="FileAadBack" CssClass="form-control" runat="server" />
                                <%--<asp:Button ID="Button2" runat="server" Text="Upload" OnClick="btnUploadClick" />--%>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td><label>Gender</label></td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Select Gender" Value="select" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>

                        </td>
                        </tr>

                    <tr>
                        <td>

                        </td>
                        <td>
                            <asp:Button ID="Button1" CssClass="btn btn-primary" style="width: 80%;" runat="server" Text="Sign Up" OnClick="Button1_Click1" />
                        </td>
                    </tr>
                </table>
                </div>
               
            
        </div>
    </form>

   
    

  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
<link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        $("[id*=txtDate]").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: 'Images/calender.jpg'
        });
    });

</script>
   
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
