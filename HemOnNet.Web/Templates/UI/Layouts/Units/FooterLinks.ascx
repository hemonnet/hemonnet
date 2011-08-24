<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterLinks.ascx.cs" Inherits="N2.Templates.UI.Layouts.Units.FooterLinks" %>

<div class="line text-align-right">
    <asp:Repeater runat="server" ID="rptQuickLinks">
        <HeaderTemplate>
            
            <ul class="horizontal-list black-text-links">
        </HeaderTemplate>

        <ItemTemplate>
            <li><HON:A runat="server" ID="hypQuickLink" /></li>
        </ItemTemplate>

        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>