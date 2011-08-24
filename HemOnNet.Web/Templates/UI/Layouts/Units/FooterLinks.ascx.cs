using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HemOnNet.Core.WebControls;
using N2.Templates.Items;
using N2;

namespace N2.Templates.UI.Layouts.Units
{
    public partial class FooterLinks : Web.UI.TemplateUserControl<ContentItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StartPage startPage = Find.ClosestStartPage;
            if (startPage != null)
                LoadLinks(startPage);
        }

        private void LoadLinks(StartPage page)
        {
            if(page.FooterLink == null)
                return;
            rptQuickLinks.DataSource = page.FooterLink.GetChildren();
            rptQuickLinks.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            rptQuickLinks.ItemDataBound += rptQuickLinks_ItemDataBound;
            base.OnInit(e);
        }

        void rptQuickLinks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ContentItem contentItem = e.Item.DataItem as ContentItem;
            if (contentItem == null || !contentItem.IsPage)
                return;

            A hypQuickLink = e.Item.FindControl("hypQuickLink") as A;

            hypQuickLink.Text = contentItem.Title;
            hypQuickLink.NavigateUrl = contentItem.Url;
        }
    }
}