<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="pro4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Custname<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </h2>
            <h2>Email<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </h2>
            <h2>Adress<asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
            </h2>
            <h2>City<asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Rajkot</asp:ListItem>
                <asp:ListItem>Gondal</asp:ListItem>
                <asp:ListItem>Mumbai</asp:ListItem>
                </asp:DropDownList>
            </h2>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
