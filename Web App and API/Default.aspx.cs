﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_App_and_API
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            string address;

            try
            {
                address = this.txt_address.Text;
                var httpWR = (HttpWebRequest)WebRequest.Create("http://localhost:51344/api/Address");
                httpWR.ContentType = "application/json";
                httpWR.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWR.GetRequestStream()))
                {
                    string json = $"{{Content:\"{address}\"}}";
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResp = (HttpWebResponse)httpWR.GetResponse();
                using(var streamReader = new StreamReader(httpResp.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    this.txt_result.Text = $"Results for {address} : {result}";
                }
            }
            catch(Exception exception)
            {
                this.txt_result.Text = exception.ToString();
            }
        }
    }
}