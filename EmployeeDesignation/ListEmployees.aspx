<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListEmployees.aspx.cs" Inherits="EmployeeDesignation.ListEmployees" %>

<!DOCTYPE html>
<html>
<head>
    <title>List Employees</title>
</head>
<body>
    <h1>List of Employees</h1>
    <table>
        <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>DOB</th>
            <th>Gender</th>
            <th>Designation</th>
        </tr>
        <%@ Import Namespace="System.Data.SqlClient" %>
        <% string connectionString = "Data Source=VINAYAK\\SQLEXPRESS;Initial Catalog=HealthCare;Integrated Security=True;"; %>
        <% string query = "SELECT FirstName, LastName, DOB, Gender, DesignationID FROM Employees"; %>
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
            <td style="text-align:right;"><%= reader["Gender"] %></td>
            <td style="text-align:right;"><%= reader["DesignationID"] %></td>
        </tr>
        <% } %>
        <% } %>
        <% } %>
    </table>
</body>
</html>
