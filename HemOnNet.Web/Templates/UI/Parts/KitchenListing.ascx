<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KitchenListing.ascx.cs" Inherits="N2.Templates.UI.Parts.KitchenListing" %>
<section class="push-list push-list-images push-list-small line">
    <asp:Repeater runat="server" ID="rptPressImageList">
        <ItemTemplate>
            <asp:PlaceHolder ID="ctrlLineStart" runat="server" Visible="false">
                <div class="line">
            </asp:PlaceHolder>
            <div class="push">
                <HON:A id="hypLink" runat="server">
                    <h3><asp:Literal ID="ltrImageHead" runat="server" /></h3>
                    <div class="push-image grey-plate">
                        <HON:Img ID="imgPress" runat="server" MaxWidth="189" AllowStretching="false"  />
                    </div>
                    <div class="push-image-bottom"></div>
                </HON:A>
            </div>
            <asp:PlaceHolder ID="ctrlLineEnd" runat="server" Visible="false">
                </div>
            </asp:PlaceHolder>
        </ItemTemplate>
    </asp:Repeater>
</section>