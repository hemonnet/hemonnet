using N2.Integrity;
using N2.Templates.Items;

namespace N2.Templates.TabPanel
{
    [Definition]
    [AllowedZones(Zones.Content)]
    public class TabsItem : TextItem
    {
        public override string TemplateUrl
        {
            get { return "~/Templates/TabPanel/TabsInterface.ascx"; }
        }

        public override string IconUrl
        {
            get { return "~/Templates/UI/Img/tab.png"; }
        }
    }
}