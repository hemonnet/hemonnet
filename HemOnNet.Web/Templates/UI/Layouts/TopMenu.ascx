<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopMenu.ascx.cs" Inherits="N2.Templates.UI.Layouts.TopMenu" %>

<asp:Repeater ID="rptMenu" runat="server">
    <HeaderTemplate><ul class="site-nav">
        <li><a href="/" >Start</a></li>
    </HeaderTemplate>
    <ItemTemplate>
        <HON:DynamicControl ID="ctrlLi" runat="server" TagName="li" Visible="false">
            <HON:A ID="hypPage" runat="server"></HON:A>
        </HON:DynamicControl>
    </ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
</asp:Repeater>