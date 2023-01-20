<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.Views.Home.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <input />
    <form id="form1" runat="server">
        <div>
            <h1>WebForm1</h1>
            <p>Grafano0</p>
            <p>
                <img src="http://localhost:3000/d/0NyGQlhVk/new-dashboard?orgId=1&from=1673674646994&to=1673696246994"/>
            </p>
            <p>Trazendo dados do banco de dados</p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="BusinessEntityID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="BusinessEntityID" HeaderText="BusinessEntityID" ReadOnly="True" SortExpression="BusinessEntityID" />
                    <asp:BoundField DataField="PersonType" HeaderText="PersonType" SortExpression="PersonType" />
                    <asp:CheckBoxField DataField="NameStyle" HeaderText="NameStyle" SortExpression="NameStyle" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" SortExpression="MiddleName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="Suffix" HeaderText="Suffix" SortExpression="Suffix" />
                    <asp:BoundField DataField="EmailPromotion" HeaderText="EmailPromotion" SortExpression="EmailPromotion" />
                    <asp:BoundField DataField="AdditionalContactInfo" HeaderText="AdditionalContactInfo" SortExpression="AdditionalContactInfo" />
                    <asp:BoundField DataField="Demographics" HeaderText="Demographics" SortExpression="Demographics" />
                    <asp:BoundField DataField="rowguid" HeaderText="rowguid" SortExpression="rowguid" />
                    <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" />
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AdventureWorks2019ConnectionString %>" SelectCommand="SELECT * FROM Person.Person"></asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
