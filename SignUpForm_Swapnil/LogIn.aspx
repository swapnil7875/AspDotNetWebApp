<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="SignUpForm_Swapnil.LogIn" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        
    </style>

    <script src="Scripts/jquery-3.4.1.min.js"></script>

    

    <script type="text/javascript">
        $(document).ready(function () {
            //$("#divpassd").hide();
            //$("#divgenPass").hide();

            $("#btnEmailSubmit").click(function (e) {
                //$("#divmail").hide();
                //$("#divpassd").show();
                document.getElementById('hdnEmailID').value = txtEmail.value; 
            });
            $("p").hover(function () {
                $(this).css("color", "green");
            }, function () {
                $(this).css("color", "red");
            });

        });
       
       
    </script>
    <style type="text/css">
        .singup {
    width: fit-content;
}
        #form1{
            display: flex;
            justify-content: center;
        }
        .form-group{
            display: flex;
            flex-direction: column;
        }
        input {
    margin-bottom: 10PX;
    padding: 5px 10px;
    margin-top: 5px;
    border: 2px solid midnightblue;
    height: 24px;
    border-radius: 6px;
    width: 300px;
}
        .btn {
    padding: 10px 20px;
    background-color: midnightblue;
    color: white;
    width: fit-content;
    border: none;
    border-radius: 6px;
    box-shadow: 0px 1px 2px 0px rgb(0 0 0 / 60%);
    height: fit-content !important;
}
        .errMsg{
            color: red;
        }
    </style>
    
    
</head>
<body>
    <form id="form1" runat="server"  >
        <asp:HiddenField ID="hdnEmailID" runat="server" value="" />
        <div class="singup" >
            <div id ="divmail" runat="server">
                <h3>Log In</h3>
                <div class="form-group">
                    <asp:Label runat="server" Text="Label">Email:</asp:Label>
                    <asp:TextBox HiddenFieldID="EmailId" ID="txtEmail" placeholder="your@mail.com" runat="server" TextMode="Email" required="required"></asp:TextBox>
                     <span id="ep" Class="errMsg"  runat="server"><p>Your registration is incomplete..! <a href="SIgnUp.aspx">  Click </a>  to register</p></span>
                    <asp:Button ID="btnEmailSubmit" runat="server" CssClass="btn" Text="Submit" OnClick="Button1_Click"  />
                   
                </div>
            </div>


            <div id ="divpassd" class="form-group" runat="server">
                <h3>Password</h3>
                <asp:Label runat="server" Text="Label">password:</asp:Label>
                <asp:TextBox ID="txtPass"  TextMode="Password"  runat="server"></asp:TextBox>
                <span id="Span1" Class="errMsg"  runat="server">Password is incorect</span>
                <asp:Button ID="btnpass" runat="server" CssClass="btn" Text="Log In" OnClick="btnpass_Click"  />
            </div>


            <div id="divgenPass" runat="server">
                <div><h3>Generate password</h3></div>
                <div class="form-group">
                     <asp:Label ID="Cpass" runat="server" Text="Label">Password:</asp:Label>
                <asp:TextBox ID="txtpass1" MaxLength="8" runat="server" required="required" ></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Label">Confirm password:</asp:Label>
                <asp:TextBox ID="txtpassConf" MaxLength="8" runat="server" required="required"></asp:TextBox>
                    <span id="Span2" Class="errMsg"  runat="server">Password is mismatch</span>
                </div>         
                
                <asp:Button ID="btnGenPass" runat="server" Text="Submit" CssClass="btn" OnClick="btnGenPass_Click" autopostback="false" />

            </div>
        </div>


    </form>
   
</body>
</html>
