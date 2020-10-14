using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

public partial class website : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void SendSMS()
    {

        try
        {
            // Msg to administrator
            string MsgContent = "Enquiry for website from " + TxtName.Text + ", Contact: " + TxtMobile.Text;

            string strUrl = string.Empty;
            string MobNos = "9656737009";
            strUrl = "http://198.24.149.4/API/pushsms.aspx?loginID=UNIWAREINDIA&password=Uniware@1024&mobile=" + MobNos + " &text=" + MsgContent + "&senderid=UNIWRE &route_id=2&Unicode=0";

            WebRequest request = HttpWebRequest.Create(strUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            response.Close();
            s.Close();
            readStream.Close();

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Your enquiry submitted successfully..!!');", true);

        }
        catch
        {
        }



        try
        {
            //Msg to customer
            string MsgCustomer = "Thank you " + TxtName.Text + " for your enquiry with UNIWARE TECHNOLOGIES (www.uniwareweb.com). You will be contacted soon by our customer care executive";

            string strUrlCust = string.Empty;
            string MobNosCust = TxtMobile.Text;
            strUrlCust = "http://198.24.149.4/API/pushsms.aspx?loginID=UNIWAREINDIA&password=Uniware@1024&mobile=" + MobNosCust + " &text=" + MsgCustomer + "&senderid=UNIWRE &route_id=2&Unicode=0";

            WebRequest requestCust = HttpWebRequest.Create(strUrlCust);
            HttpWebResponse responseCust = (HttpWebResponse)requestCust.GetResponse();
            Stream sCust = (Stream)responseCust.GetResponseStream();
            StreamReader readStreamCust = new StreamReader(sCust);
            string dataStringCust = readStreamCust.ReadToEnd();
            responseCust.Close();
            sCust.Close();
            readStreamCust.Close();
        }
        catch
        {
        }

        TxtName.Text = "";
        TxtMobile.Text = "";

    }


    protected void CmdSubmit_Click(object sender, EventArgs e)
    {
        if (TxtMobile.Text.Length < 10)
        {
            return;
        }

        SendSMS();
    }
}