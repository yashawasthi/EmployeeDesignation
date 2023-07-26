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
            <h3>Date OF Birth</h3>
            <asp:Calendar ID="textDOB" runat="server"></asp:Calendar>
            <br />
            <asp:TextBox ID="txtGender" runat="server" placeholder="Gender"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtDesignationID" runat="server" placeholder="DesignationID"></asp:TextBox>
            <br />
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





















<%--<body>
    <form runat="server" style="display: flex; justify-content: space-between; gap: 3px; flex-direction:column; width:50%">
        <div  style="display: flex; justify-content: space-between; gap: 3px; flex-direction:column; width:50%">
            <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name"></asp:TextBox>
        <br />
        <h3>Date OF Birth</h3>
        <asp:Calendar ID="textDOB" runat="server" ></asp:Calendar>
        <br />
        <asp:TextBox ID="txtGender" runat="server" placeholder="Gender"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtDesignationID" runat="server" placeholder="DesignationID"></asp:TextBox>
        <br />
        <div style="display:flex;justify-content:space-between;gap:3px;">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" style="width:100%;" />
                    <asp:Button ID="btnclear" runat="server" Text="Clear" OnClick="btnClear_Click" style="width:100%;"/>
                    <asp:Button ID="btnsaveAndContinue" runat="server" Text="Save and Continue" OnClick="btnSaveAndContinue_Click" style="width:100%;"/>
        </div>
        </div>


        <table style="border:3px solid black;">
        <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>DOB</th>
            <th>Gender</th>
            <th>Designation</th>
            <th>Actions</th>
        </tr>
        <%@ Import Namespace="System.Data.SqlClient" %>
        <% string connectionString = "Data Source=VINAYAK\\SQLEXPRESS;Initial Catalog=HealthCare;Integrated Security=True;"; %>
        <% string query = "SELECT EmployeeID,FirstName, LastName, DOB, Gender, DesignationID FROM Employees"; %>
        <% using (SqlConnection connection = new SqlConnection(connectionString)) %>
        <% { %>
        <% SqlCommand command = new SqlCommand(query, connection); %>
        <% connection.Open(); %>
        <% using (SqlDataReader reader = command.ExecuteReader()) %>
        <% { %>
        <% while (reader.Read()) %>
        <% { %>
        <tr>
            <td><%= reader["FirstName"] %></td>
            <td><%= reader["LastName"] %></td>
            <td><%= reader["DOB"] %></td>
            <td><%= reader["Gender"] %></td>
            <td><%= reader["DesignationID"] %></td>
            <td style="display:flex;justify-content:space-evenly;flex-direction:row">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CommandName="UpdateEmployee" CommandArgument='<%# Eval("EmployeeID") %>' style="background-color:forestgreen;color:whitesmoke;width:100%;cursor:pointer" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" style="background-color:red;color:whitesmoke;width:100%;cursor:pointer"/>
            </td>
        </tr>
        <% } %>
        <% } %>
        <% } %>
    </table>
    </form>
</body>--%>
