<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CoreWebFormAppAspx._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style= "font-size:x-large" align="center">Crud Operation</div>
    <table class="nav-justified">
        <tr>
            <td style="width: 264px">&nbsp;</td>
            <td style="width: 164px">Employee ID</td>
            <td>
                <asp:TextBox ID="txtEmpId" runat="server" Font-Size="Medium" Width="274px"></asp:TextBox>
            &nbsp;
                <asp:Button ID="Btn_Get" runat="server" BackColor="#F29540" BorderColor="#FFCC00" Font-Bold="True" Font-Size="Medium" ForeColor="Black" OnClick="Get_Click" style="margin-left: 31" Text="Get" Width="94px" />
            </td>
        </tr>
        <tr>
            <td style="width: 264px; height: 40px;"></td>
            <td style="width: 164px; height: 40px;">Employee Name</td>
            <td style="height: 40px">
                <asp:TextBox ID="txtEmpName" runat="server" Font-Size="Medium" Width="274px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 264px">&nbsp;</td>
            <td style="width: 164px">Designation</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Jr. software developer</asp:ListItem>
                    <asp:ListItem>technical treinee</asp:ListItem>
                    <asp:ListItem>sr. software developer</asp:ListItem>
                    <asp:ListItem>QA</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 264px; height: 40px"></td>
            <td style="height: 40px; width: 164px">Contact</td>
            <td style="height: 40px">
                <asp:TextBox ID="txtContact" runat="server" Font-Size="Medium" Width="274px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 264px; height: 20px"></td>
            <td style="height: 20px; width: 164px">&nbsp;</td>
            <td style="height: 20px">
                <asp:Button ID="Btn_Insert" runat="server" BackColor="#F29540" BorderColor="#FFCC00" Font-Bold="True" Font-Size="Medium" ForeColor="Black" OnClick="Insert_Click" Text="Insert" Width="94px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Btn_Upadate" runat="server" BackColor="#F29540" BorderColor="#FFCC00" Font-Bold="True" Font-Size="Medium" ForeColor="Black" OnClick="Update_Click" style="margin-left: 31" Text="Update " Width="94px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Btn_Delete" runat="server" BackColor="#F29540" BorderColor="#FFCC00" Font-Bold="True" Font-Size="Medium" ForeColor="Black" OnClick="Delete_Click" OnClientClick="return confirm('Are you sure to delete?');" style="margin-left: 31" Text="Delete" Width="94px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Btn_Search" runat="server" BackColor="#F29540" BorderColor="#FFCC00" Font-Bold="True" Font-Size="Medium" ForeColor="Black" OnClick="Search_Click" style="margin-left: 31" Text="Search" Width="94px" />
            </td>
        </tr>
       <%-- <tr>
            <td style="width: 264px; height: 20px">&nbsp;</td>
            <td style="height: 20px; width: 164px">&nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>--%>
        <tr>
            <td style="width: 264px; height: 20px">&nbsp;
            </td>
            <td style="height: 20px; width: 164px">&nbsp;</td>
            <td style="height: 20px">
                <asp:GridView ID="GridView1" runat="server" Width="533px">
                </asp:GridView>
            </td>
        </tr>
        </table>
             <Div>
                <asp:Calendar ID="datepicker" runat="server" visible="false" OnSelectionChanged="datepicker_SelectionChanged1"></asp:Calendar>
            </Div>
                <asp:TextBox ID="txtdtp" runat="server"></asp:TextBox>
                 <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">GetDate</asp:LinkButton>

</asp:Content>
