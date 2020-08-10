<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chart.aspx.cs" Inherits="Wanderlust.Chart" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Chart ID="Chart1" runat="server" DataSourceID="Hotel">
            <series>
                <asp:Series ChartArea="ChartArea1" ChartType="Bar" Name="Hotels" XValueMember="Name" YValueMembers="Column">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <asp:SqlDataSource ID="Hotel" runat="server" ConnectionString="Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-Wanderlust04-20191026014229.mdf;Initial Catalog=aspnet-Wanderlust04-20191026014229;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [HotelName], count([HotelId]) FROM [Hotel] group by [HotelName];"></asp:SqlDataSource>
    </form>
</body>
</html>
