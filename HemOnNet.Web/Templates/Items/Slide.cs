using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using N2.Definitions;
using N2.Persistence.Serialization;
using N2.Templates.Services;
using N2;
using N2.Details;
using N2.Web;
using N2.Web.UI.WebControls;

namespace N2.Templates.Items
{
    /// <summary>
    /// A page containing textual information.
    /// </summary>
    [PageDefinition("Slide page",
        Description = "A simple slide page. Den visar en bildspels-bild.",
        SortOrder = 25)]
    [ConventionTemplate("Slide")]
    public class Slide : AbstractContentPage, IStructuralPage, ISyndicatable
    {
        [FileAttachment, EditableFileUpload("Image", 90, ContainerName = Tabs.Content, CssClass = "main")]
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

        [EditableTextBox("HomePage", 110)]
        public virtual string HomePage
        {
            get { return (string)base.GetDetail("HomePage"); }
            set { base.SetDetail("HomePage", value); }
        }

        public string Summary
        {
            get { return ExtractFirstSentences(Text, 250); }
        }

        private static string ExtractFirstSentences(string text, int maxLength)
        {
            text = Regex.Replace(text, "<!*[^<>]*>", string.Empty, RegexOptions.Compiled | RegexOptions.Multiline);
            int separatorIndex = 0;
            for (int i = 0; i < text.Length && i < maxLength; i++)
            {
                switch (text[i])
                {
                    case '.':
                    case '!':
                    case '?':
                        separatorIndex = i;
                        break;
                    default:
                        break;
                }
            }
            return text.Substring(0, separatorIndex + 1);
        }
    }
}
