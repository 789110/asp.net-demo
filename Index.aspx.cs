using iPayy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iPayyDemo__ASP.NET_
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter.Add(CryptoUtils.MERCHANT_KEY_PARAM, "TSo-Pr8LkLy0E497TTyt8Q");
            parameter.Add(CryptoUtils.APPLICATION_KEY_PARAM, "yChjKjgSRy09oZGRapOrgQ");
            parameter.Add(CryptoUtils.CURRENCY_PARAM, "INR");
            parameter.Add(CryptoUtils.ITEM_CODE_PARAM, "1");
            parameter.Add(CryptoUtils.ITEM_NAME_PARAM, ".Net Demo");
            parameter.Add(CryptoUtils.ITEM_PRICE_PARAM, "1");
            string requestId = new Random().Next(10000,99999).ToString();
            Session["requestId"] = requestId;
            parameter.Add(CryptoUtils.REQUEST_TOKEN_PARAM, requestId);
            string url = Request.Url.Scheme + "://" + Request.Url.Host + ":" + Request.Url.Port + Page.ResolveUrl("~/Payment.aspx");
            parameter.Add(CryptoUtils.REDIRECT_URL_PARAM, url);
            try
            {
                string gh = CryptoUtils.encrypt(parameter);
                Response.Redirect("http://api.ipayy.com/v001/c/oc/dopayment?gh=" + gh, true);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}