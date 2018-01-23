using System;
using System.Collections.Generic;
using System.Linq;
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
                this.txt_result.Text = $"Results for {address}";
            }
            catch(Exception exception)
            {
                this.txt_result.Text = exception.ToString();
            }
        }
    }
}