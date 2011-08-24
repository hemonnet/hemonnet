using System;
using HemOnNet.Core.WebControls;
using N2;
using N2.Collections;

namespace N2.Templates.UI.Layouts
{
    public partial class SubMenu : Web.UI.TemplateUserControl<ContentItem>
    {
        public ContentItem StartPage { get; set; }

        public int StartLevel { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            InitMenu();
            base.OnLoad(e);
        }

        protected override void OnInit(EventArgs e)
        {
            rptSubMenu.ItemDataBound += (rptSubMenu_ItemDataBound);
            base.OnInit(e);
        }

        void rptSubMenu_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            ContentItem contentItem = e.Item.DataItem as ContentItem;
            if(contentItem == null || !contentItem.IsPage)
                return;

            DynamicControl ctrlListItem = e.Item.FindControl("ctrlListItem") as DynamicControl;
            A hypPage = e.Item.FindControl("hypPage") as A;

            if (contentItem == CurrentItem)
                ctrlListItem.CssClass = "selected";

            ctrlListItem.Visible = true;
            hypPage.Text = contentItem.Title;
            hypPage.NavigateUrl = contentItem.Url;

        }

        private void InitMenu()
        {
            ContentItem branchRoot = Find.AncestorAtLevel(StartLevel, Find.EnumerateParents(CurrentPage, StartPage), CurrentPage);

            if (branchRoot.GetChildren(new NavigationFilter()).Count > 0)
            {
                ltrMenuHeader.Text = branchRoot.Title;
                rptSubMenu.DataSource = branchRoot.GetChildren(new NavigationFilter());
                rptSubMenu.DataBind();
            }
            else
                Visible = false;
        }
    }
}