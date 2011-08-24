

using N2.Templates.Web.UI;

namespace N2.Templates.UI.Views
{
    public partial class Slide : TemplatePage<N2.Templates.Items.Slide>
    {
        protected override void OnLoad(System.EventArgs e)
        {
            ltrHeader.Text = CurrentPage.Title;
            hypImage.NavigateUrl = CurrentPage.Image;
            imgSlide.ImageUrl = CurrentPage.Image;
            base.OnLoad(e);
        }
    }
}
