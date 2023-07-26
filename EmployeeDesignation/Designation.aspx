<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Designation.aspx.cs" Inherits="EmployeeDesignation.Designation" %>

<!DOCTYPE html>
<html>
<head>
    <title>Designation</title>
</head>
<body>
    <form runat="server">
        <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <div style="margin-top:20px;">
            <asp:GridView ID="Designations" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="DesignationName" HeaderText="Designation Name" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="updateDesignation" Text="Update" runat="server" CommandArgument='<%# Eval("DesignationID") %>' OnClick="updateDesignation_Click" />
                            <asp:LinkButton ID="deleteDesignation" Text="Delete" runat="server" CommandArgument='<%# Eval("DesignationID") %>' OnClick="deleteDesignation_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
