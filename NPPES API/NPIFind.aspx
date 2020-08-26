<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NPIFind.aspx.cs" Inherits="NPPES_API.NPIFind" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-top:10px">
        <asp:Label ID="Label2" runat="server" Text="Organization:"></asp:Label>&nbsp;
       <%-- <asp:Label ID="lblNameMatch" runat="server" Text="BARNES, DAWN K"></asp:Label>&nbsp;&nbsp;--%>
        <asp:TextBox ID="txtOrgMatch" runat="server"></asp:TextBox>
        <asp:Label ID="lblOrgMessage" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Name (Last/First):"></asp:Label>&nbsp;
        <asp:TextBox ID="txtLNameMatch" runat="server"></asp:TextBox>&nbsp;
        <asp:TextBox ID="txtFNameMatch" runat="server"></asp:TextBox>
        <asp:Label ID="lblNameMessage" runat="server" Text=""></asp:Label>
        
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Taxonomies:"></asp:Label>&nbsp;
        <%--<asp:Label ID="lblTaxonomiesMatch" runat="server" Text="363L00000X - NURSE COORDINATOR"></asp:Label>&nbsp;&nbsp;--%>
        <asp:TextBox ID="txtTaxonomiesMatch" runat="server" Width="177px"></asp:TextBox>
        <asp:Label ID="lblTaxonomiesMessage" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Find NPI Data" OnClick="btnSearch_Click1" />&nbsp;&nbsp;
        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSearch" ErrorMessage="Please enter NPI Number" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Registry Organization:"></asp:Label>&nbsp;
        <asp:Label ID="lblOrgName" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Registry Last Name:"></asp:Label>&nbsp;
        <asp:Label ID="lblLName" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Registry First Name:"></asp:Label>&nbsp;
        <asp:Label ID="lblFName" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Taxonomies Code:"></asp:Label>&nbsp;
        <asp:Label ID="lblTaxonomies" runat="server" Text=""></asp:Label>  
    </div>
    </form>
</body>
</html>
