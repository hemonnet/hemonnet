<%@ Page Title="" Language="C#" MasterPageFile="../Layouts/Default.Master" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="N2.Templates.UI.Views.Start" %>
<asp:Content ContentPlaceHolderID="MainContentRegion" runat="server">
    <div class="main-intro line">
	    <div class="page-main-image-container">
		    <div class="page-main-image grey-plate">
			    <n2:DroppableZone ID="dzContentZone" ZoneName="StartPageSlide" runat="server" />
		    </div>
	    </div>
    </div>
    
    <div class="start-page-content">
						
		<section class="tab-navigation">
			<ul class="tabs line upper-case">
				<li class="current"><a href="/">Kök</a></li>
				<li><a href="/">Badrum</a></li>
			</ul>
			
			<div class="tab-content">
				<div class="tab-content-area current">
					<section class="push-content line">
                        <asp:Repeater ID="rptKitchen" runat="server">
                            <ItemTemplate>
                                <div class="push">
							        <HON:A ID="hypKitchen" runat="server">
								        <h3>
									        <HON:Img ID="imgKitchen" runat="server" />
									        <HON:DynamicControl ID="ctrlSpan" runat="server" TagName="span" CssClass="foggyblue"></HON:DynamicControl>
								        </h3>
							        </HON:A>
						        </div>
                            </ItemTemplate>
                        </asp:Repeater>
					</section>
				</div>
				<div class="tab-content-area">
					<section class="push-content line">
                        <asp:Repeater ID="rptBathroom" runat="server">
                            <ItemTemplate>
                                <div class="push">
							        <HON:A ID="hypKitchen" runat="server">
								        <h3>
									        <HON:Img ID="imgKitchen" runat="server" />
									        <HON:DynamicControl ID="ctrlSpan" runat="server" TagName="span" CssClass="beige"></HON:DynamicControl>
								        </h3>
							        </HON:A>
						        </div>
                            </ItemTemplate>
                        </asp:Repeater>
					</section>
				</div>
			</div>
		</section>
	</div>		
</asp:Content>
