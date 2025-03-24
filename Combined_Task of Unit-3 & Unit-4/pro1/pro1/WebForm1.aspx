<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="pro1.WebForm1" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>EmpName&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </h2>
            <h2>DateOfBirth&nbsp;
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
            </h2>
            <h2>Department&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>It</asp:ListItem>
                    <asp:ListItem>Hr</asp:ListItem>
                    <asp:ListItem>Accounting</asp:ListItem>
                </asp:DropDownList>
            </h2>
            <h2>ProfileImage<asp:FileUpload ID="FileUpload1" runat="server" />
            </h2>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="submit" />
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="ProfileImage">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="104px" ImageUrl='<%# Eval("ProfileImage","image\\{0}") %>' Width="137px" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
