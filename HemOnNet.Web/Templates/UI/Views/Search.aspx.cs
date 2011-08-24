using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using HemOnNet.Core.WebControls;

namespace N2.Templates.UI.Views
{
    public partial class Search : Web.UI.TemplatePage<N2.Templates.Items.AbstractSearch>
    {
        protected override void OnLoad(EventArgs e)
        {
            if (IsPostBack)
                Response.Redirect(string.Format("{0}?q={1}", CurrentPage.Url, txtSearchText.Value));

            //ctrlSDS.PageLink = PageReference.StartPage;

            if (!string.IsNullOrEmpty(Request.QueryString["q"]))
                DoSearch();
        }

        protected override void OnInit(EventArgs e)
        {
            rptResult.ItemDataBound += new RepeaterItemEventHandler(rptResult_ItemDataBound);

            base.OnInit(e);
        }

        void rptResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ContentItem pd = e.Item.DataItem as ContentItem;
            if (pd == null)
                return;
            DynamicControl ctrlPath = e.Item.FindControl("ctrlPath") as DynamicControl;
            A hypResult = e.Item.FindControl("hypResult") as A;
            Literal ltrResult = e.Item.FindControl("ltrResult") as Literal;

            hypResult.Text = pd.Title;
            hypResult.NavigateUrl = pd.Url;
            if(pd.GetDetail("Text") == null)
                return;
            string intro = pd.GetDetail("Text").ToString();
            if (!string.IsNullOrEmpty(intro))
            {
                intro = System.Text.RegularExpressions.Regex.Replace(intro, @"<[^>]*>", String.Empty);
                if (intro.Length > 175)
                    ltrResult.Text = intro.Substring(0, intro.LastIndexOf(" ", 175)) + "..." ?? string.Empty;
            }

        }

        protected override void Render(HtmlTextWriter writer)
        {
            txtSearchText.Value = Server.UrlDecode(Request.QueryString["q"]);

            base.Render(writer);
        }

        private ICollection<ContentItem> hits = new List<ContentItem>();

        protected ICollection<ContentItem> Hits
        {
            get { return hits; }
            set { hits = value; }
        }



        private void DoSearch()
        {
            rptResult.DataSource = CurrentPage.Search(Server.UrlDecode(Request.QueryString["q"]));
            rptResult.DataBind();
        }
    }
}