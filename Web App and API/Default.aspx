<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_App_and_API._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>AirQuality - Web APP &amp; API C#</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
                <asp:Label ID="Label1" runat="server" Text="Address"></asp:Label>
                <br />
                <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btn_send" runat="server" Text="Send" OnClick="btn_send_Click" />
                <br />
                <br />
                <asp:TextBox ID="txt_result" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>

</asp:Content>
