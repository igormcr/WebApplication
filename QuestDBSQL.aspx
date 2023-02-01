<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestDBSQL.aspx.cs" Inherits="WebApplication2.QuestDBSQL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
 <h1>TesteQuestDB Link SQL</h1>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Datetime" HeaderText="Datetime" SortExpression="Datetime"></asp:BoundField>
            <asp:BoundField DataField="PeriodStart" HeaderText="PeriodStart" SortExpression="PeriodStart"></asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="Flow" HeaderText="Flow" SortExpression="Flow"></asp:BoundField>
            <asp:BoundField DataField="FlowSetpoint" HeaderText="FlowSetpoint" SortExpression="FlowSetpoint"></asp:BoundField>
            <asp:BoundField DataField="Pressure" HeaderText="Pressure" SortExpression="Pressure"></asp:BoundField>
            <asp:BoundField DataField="PressureSetpoint" HeaderText="PressureSetpoint" SortExpression="PressureSetpoint"></asp:BoundField>
            <asp:BoundField DataField="OverloadValue" HeaderText="OverloadValue" SortExpression="OverloadValue"></asp:BoundField>
            <asp:BoundField DataField="OperationStatus" HeaderText="OperationStatus" SortExpression="OperationStatus"></asp:BoundField>
            <asp:BoundField DataField="OperationType" HeaderText="OperationType" SortExpression="OperationType"></asp:BoundField>
            <asp:BoundField DataField="OperationMode" HeaderText="OperationMode" SortExpression="OperationMode"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:masterConnectionString %>" SelectCommand="SELECT * FROM OPENQUERY(QUESTDB,'SELECT * FROM [questdb-query-1675076348034.csv] LIMIT 50000')"></asp:SqlDataSource>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
