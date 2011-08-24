<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubMenu.ascx.cs" Inherits="N2.Templates.UI.Layouts.SubMenu" %>
<h3><asp:Literal runat="server" ID="ltrMenuHeader"></asp:Literal></h3>
<asp:Repeater ID="rptSubMenu" runat="server">
    <HeaderTemplate>
        <nav class="sidebar-navigation">
        <ul>
    </HeaderTemplate>
    
    <ItemTemplate>
        <HON:DynamicControl ID="ctrlListItem" runat="server" Visible="false" TagName="li">
		    <HON:A ID="hypPage" runat="server"></HON:A>
	    </HON:DynamicControl>
    </ItemTemplate>
    
    <FooterTemplate>
        </ul>
        </nav>
    </FooterTemplate>
</asp:Repeater>
