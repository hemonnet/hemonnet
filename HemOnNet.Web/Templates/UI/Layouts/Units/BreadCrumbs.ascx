<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BreadCrumbs.ascx.cs" Inherits="N2.Templates.UI.Layouts.Units.BreadCrumbs" %>
<asp:Repeater ID="rptBreadCrumbs" runat="server">
    <HeaderTemplate>
        <nav class="breadcrumbs black-text">
    
         <b>Du är här:</b>
        <ul class="horizontal-list">
    </HeaderTemplate>
    <ItemTemplate>
        <li><HON:A ID="hypLink" runat="server" /></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
        </nav>  
        
    </FooterTemplate>
</asp:Repeater>