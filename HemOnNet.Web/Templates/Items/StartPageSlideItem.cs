using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N2.Details;
using N2.Integrity;
using N2.Persistence.Serialization;

namespace N2.Templates.Items
{
    [PartDefinition("StartPageSlide", Name = "StartPageSlide",
        IconUrl = "~/Templates/UI/Img/text_align_left.png")]
    [AllowedZones(Zones.StartPageSlide)]
    [WithEditableTitle]
    public class StartPageSlideItem : AbstractItem
    {
        protected override string TemplateName
        {
            get { return "StartPageSlide"; }
        }

        [FileAttachment, EditableFileUpload("Image", 90, CssClass = "main")]
        public virtual string Image
        {
            get { return (string)(GetDetail("Image") ?? string.Empty); }
            set { SetDetail("Image", value, string.Empty); }
        }

        [EditableFreeTextArea("Text", 100)]
        public virtual string Text
        {
            get { return (string)(GetDetail("Text") ?? string.Empty); }
            set { SetDetail("Text", value, string.Empty); }
        }
    }
}
