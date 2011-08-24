using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HemOnNet.Core.WebControls;
using N2.Templates.Web.UI.WebControls;
using N2;
using N2.Collections;
using N2.Web;

namespace N2.Templates.UI.Layouts.Units
{
    public partial class BreadCrumbs : Web.UI.TemplateUserControl<ContentItem>
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeControls();
            }
            base.OnLoad(e);
        }

        protected override void OnInit(EventArgs e)
        {

            rptBreadCrumbs.ItemDataBound += new RepeaterItemEventHandler(rptBreadCrumbs_ItemDataBound);
        }

        void rptBreadCrumbs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ContentItem contentItem = e.Item.DataItem as ContentItem;
            if (contentItem == null || !contentItem.IsPage)
                return;

            A hypLink = e.Item.FindControl("hypLink") as A;

            hypLink.Text = contentItem.Title;
            hypLink.NavigateUrl = contentItem.Url;
        }

        #region Initialize

        private void InitializeControls()
        {
            GenerateBreabCrumbs();
        }

        #endregion

        #region Helper Methods

        

        /// <summary>
        /// Creates the bread crumb link string from the start page of the site to the supplied page
        /// </summary>
        /// <param name="page">The last page in the bread crumb string.</param>
        /// <returns>A bread crumb string with anchors to parent pages.</returns>
        private void GenerateBreabCrumbs()
        {

            
            ArrayList al = new ArrayList();

            foreach (ContentItem page in Find.EnumerateParents(Find.CurrentPage, Find.ClosestLanguageRoot, true))
            {
                IBreadcrumbAppearance appearance = page as IBreadcrumbAppearance;
                bool visible = appearance == null || appearance.VisibleInBreadcrumb;
                if (visible && page.IsPage)
                {
                    al.Add(page);
                }
            }
            
            
           
            // Generate the start page link 
            al.Reverse();
            
            // Insert the startpage link and return
            //return breadCrumbsText.Insert(0, startPageLink).ToString();
            rptBreadCrumbs.DataSource = al;
            rptBreadCrumbs.DataBind();
        }

        


       

        #endregion

        
    }
}