<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PdfToImg.aspx.cs" Inherits="CoreWebFormAppAspx.PdfToImg.PdfToImg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 152px">
    <style>
        h1 {
            color: green;
        }

    </style>

    <form id="form1" runat="server">
        <div>
            <h3>Please select Pdf file.</h3>
        </div>

        <div>
            <asp:FileUpload ID="myFile" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUploadClick" />
            <asp:Label ID="lblFileName" runat="server"></asp:Label>
        </div>


    </form>
</body>

</html>
