<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="pro5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Title&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </h2>
              <h2>Author&nbsp;
                  <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </h2>
              <h2>Price&nbsp;&nbsp;&nbsp;
                  <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </h2>
            <p>
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="insert" />
            </p>
            <p>&nbsp;</p>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Write" />
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Read" />
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </p>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
    </form>
</body>
</html>
