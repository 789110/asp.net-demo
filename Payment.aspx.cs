using iPayy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iPayyDemo__ASP.NET_
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string gh = Request.QueryString["gh"];
            string status = "Fail";
            Dictionary<string, string> p = null;
            try
            {
                p = CryptoUtils.decrypt(gh);
                string temp = null;
                if (p.TryGetValue("ts", out temp) && temp.Equals("S"))
                {
                    if (p.TryGetValue(CryptoUtils.REQUEST_TOKEN_PARAM, out temp) && temp.Equals(Session["requestId"]))
                    {
                        status = "Success";
                    }
                    else
                    {
                        status = "Fraud";
                    }
                }
            }
            catch (Exception ex)
            {
                p = new Dictionary<string, string>();
                p.Add("ts", "F");
                p.Add("em", ex.Message);
            }
            finally
            {
                paymentStatus.Text = status;
                if (p != null)
                {
                    extraInfo.Text = "";
                    foreach (KeyValuePair<string, string> entry in p)
                    {
                        extraInfo.Text += entry.Key + " = " + entry.Value + "<br />";
                    }
                }
            }
        }
    }
}