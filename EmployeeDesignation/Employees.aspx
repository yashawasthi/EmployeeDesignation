<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeeDesignation.Employees" %>

<!DOCTYPE html>
<html>
<head>
    <title>Employees</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: flex; justify-content: space-between; gap: 3px; flex-direction: column; width: 50%">
            <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name"></asp:TextBox>
            <br />
<%--            <asp:Calendar ID="textDOB" runat="server"></asp:Calendar>--%>
            <input type="date" id="textDOB" runat="server" />
            <br />
            <asp:TextBox ID="txtGender" runat="server" placeholder="Gender"></asp:TextBox>
            <br />
            <asp:DropDownList ID="ddlDesignations" runat="server" DataTextField="DesignationName" DataValueField="DesignationID"></asp:DropDownList>
            <br />
<%--            <asp:TextBox ID="txtDesignationID" runat="server" placeholder="DesignationID"></asp:TextBox>
            <br />--%>
            <div style="display: flex; justify-content: space-between; gap: 3px;">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Style="width: 100%;" />
                <asp:Button ID="btnclear" runat="server" Text="Clear" OnClick="btnClear_Click" Style="width: 100%;" />
                <asp:Button ID="btnsaveAndContinue" runat="server" Text="Save and Continue" OnClick="btnSaveAndContinue_Click" Style="width: 100%;" />
            </div>
        </div>
        <div style="margin-top:20px;">
            <asp:GridView ID="Employee" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="DOB" HeaderText="DOB" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="DesignationID" HeaderText="DesignationID" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="updateEmployee" Text="Update" runat="server" CommandArgument='<%# Eval("EmployeeID") %>' OnClick="updateEmployee_Click" />
                            <asp:LinkButton ID="deleteEmployee" Text="Delete" runat="server" CommandArgument='<%# Eval("EmployeeID") %>' OnClick="deleteEmployee_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </form>
</body>
</html>
