﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Presidente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDataSource1.XPath = "Presidentes/Presidente[@ID='"+HttpContext.Current.Request.Url.AbsoluteUri.ToString().Split('=')[1]+"']";
        }
    }
}