using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public class IISHandler1 : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            String conStr = ConfigurationManager.ConnectionStrings["PubsConnectionString1"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand comm = new SqlCommand("SELECT au_fname, au_lname FROM authors",conn);
            comm.Connection.Open();
            SqlDataReader sdr = comm.ExecuteReader();
            String messageout = "<?xml version=\"1.0\"?>\n<results>";
            String num = context.Request.QueryString["n"];
            int numA = -1;
            int i = 0;
            if (num != null)
            {
                if (!int.TryParse(num, out numA))
                {
                    numA = -1;
                }
            }
            while (sdr.Read())
            {
                if (i >= numA && numA > 0)
                {
                    break;
                }
                messageout += "<author>" + sdr.GetSqlString(0).ToString() + " " + sdr.GetSqlString(1).ToString() + "</author>";
                i++;
            }
            sdr.Close();
            messageout += "\n</results>";
            context.Response.ContentType = "text/xml";
            context.Response.Write(messageout);

        }

        #endregion
    }
}
