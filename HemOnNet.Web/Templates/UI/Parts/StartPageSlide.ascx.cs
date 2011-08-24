using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using N2.Templates.Items;

namespace N2.Templates.UI.Parts
{
    public partial class StartPageSlide : Web.UI.TemplateUserControl<ContentItem, StartPageSlideItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentItem.Image))
            {
                Visible = false;
                return;
            }
                
            imgSlide.ImageUrl = CurrentItem.Image;
            imgSlide.MaxWidth = 932;
        }
    }
}