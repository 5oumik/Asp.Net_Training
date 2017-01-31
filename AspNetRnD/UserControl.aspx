<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserControl.aspx.cs" Inherits="AspNetRnD.UseControl" %>

<%@ Register Assembly="CustomCalendar" Namespace="CustomCalendar" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:CustomCalendar ID="CustomCalendar" runat="server" ImageButtonImageUrl="Images/Calendar.jpg"></cc1:CustomCalendar>
        <asp:Button ID="Button1" runat="server" Text="Show Date" OnClick="Button1_Click" />
        <%--<cuc:CalendarUserControl SelectedDate="01/01/2017" runat="server" ID="CalendarUserControl" />
        <asp:Button ID="Button1" runat="server" Text="Print Date" OnClick="Button1_Click" />--%>

    </div>
        
    </form>
</body>
</html>
