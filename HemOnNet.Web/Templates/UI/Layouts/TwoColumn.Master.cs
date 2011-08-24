using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using N2.Templates.Items;
using N2;
using Find = N2.Templates.Find;

namespace N2.Templates.UI.Layouts
{
    public partial class TwoColumn : Templates.Web.UI.TemplateMasterPage<ContentItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentPage != null)
            {
                ltrHeader.Text = CurrentPage.Title;
                StartPage start = Find.StartPage;
                if (start != null)
                    ctrlSubMenu.StartPage = start;
            }
        }
    }
}
