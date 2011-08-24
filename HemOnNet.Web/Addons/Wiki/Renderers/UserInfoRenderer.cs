﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N2.Addons.Wiki.Renderers
{
    public class UserInfoRenderer : IRenderer
    {
        #region IControlRenderer Members

        public Control AddTo(Control container, ViewContext context)
        {
            Literal l = new Literal();
            if (context.Fragment.Length <= 3)
                l.Text = context.Article.SavedBy;
            else if (context.Fragment.Length >= 5)
                l.Text = context.Article.Updated.ToString();
            else
                l.Text = context.Article.SavedBy + ", " + context.Article.Updated.ToString();
            container.Controls.Add(l);
            return l;
        }

        #endregion
    }
}
