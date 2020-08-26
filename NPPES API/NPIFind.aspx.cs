using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

/*
==============================================================================================
    Description:        This application is used to enter npi numbers to match data
    Created Date:       8/17/2020
    Created By:         Wendy Frazier
    NPI Data Link:      https://npiregistry.cms.hhs.gov/
    Sample NPI Numbers: 1972956928, 1962550244, 1144594474, 1548887300, 1750353736, 1003180795
                        1730535485, 1750911947, 1851695753, 1669713442, 1699203000, 1598085607
                        1336555101, 1659814366, 1275718736, 1467985721, 1922377670, 1891258539
==============================================================================================
*/

namespace NPPES_API
{
    public partial class NPIFind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        [System.Web.Services.WebMethod]
        public void getResult()
        {
            StringBuilder sb = new StringBuilder();

            byte[] buf = new byte[8192];

            string number = txtSearch.Text;

            string url = "https://npiregistry.cms.hhs.gov/api/?version=2.0&number=" + number;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream resStream = response.GetResponseStream();

            lblTaxonomies.Text = "";
            lblOrgMessage.Text = "";
            lblFName.Text = "";
            lblLName.Text = "";
            lblOrgName.Text = "";
            lblNameMessage.Text = "";
            string tempString = null;
            int count = 0;
            //read the data and print it
            do
            {
                count = resStream.Read(buf, 0, buf.Length);
                if (count != 0)
                {
                    tempString = Encoding.ASCII.GetString(buf, 0, count);

                    sb.Append(tempString);
                }
                else
                {

                    string error = "";
                    
                    error = "There is an error with the NPI entered. Please correct!";

                    Session["error"] = error;
                }
            }
            while (count > 0);
            
            if (sb.ToString().Contains("Errors"))
            {
                lblResult.Text = Session["error"].ToString();
            }
            else
            {
                JObject results = JObject.Parse(sb.ToString());

                foreach (var result in results["results"])
                {

                    string tx = sb.ToString();
                    var data = JObject.Parse(tx);
                    JArray taxonomies = (JArray)data["results"][0]["taxonomies"];


                    foreach (JToken taxonomiesResult in taxonomies)
                    {
                        lblTaxonomiesMessage.Text = ""; // Clear message for each taxonomies
                        string taxonomiesCode = (string)taxonomiesResult["code"];
                        //string taxonomiesDesc = (string)taxonomiesResult["desc"];

                    lblTaxonomies.Text = taxonomiesCode.ToString();

                    lblResult.Text = "";

                    if (txtTaxonomiesMatch.Text.Trim() != lblTaxonomies.Text.Trim() && lblTaxonomiesMessage.Text == "")
                    {
                        lblTaxonomiesMessage.Text = "No Taxonomies on file. ";
                    }
                    else
                    {
                        //exit loop if data matches
                        break;
                    }
                    };

                    JToken org = result["basic"]["name"];
                    JToken lname = result["basic"]["last_name"];
                    if (lname == null)
                    {
                        lname = result["basic"]["authorized_official_last_name"];
                    }
                    JToken fname = result["basic"]["first_name"];
                    if (fname == null)
                    {
                        fname = result["basic"]["authorized_official_first_name"];
                    }

                    lblOrgName.Text = org.ToString();
                    lblFName.Text = fname.ToString();
                    lblLName.Text = lname.ToString();
                    string fullname = lname.ToString().Trim() + ' ' + fname.ToString().Trim();
                    lblResult.Text = "";

                    if ((txtLNameMatch.Text.Trim().ToUpper() + ' ' + txtFNameMatch.Text.Trim().ToUpper() != fullname) || txtLNameMatch.Text.ToUpper() != lname.ToString().Trim() || txtFNameMatch.Text.ToUpper() != fname.ToString().Trim())
                    {
                        lblNameMessage.Text = "Name does not match registry result: " + lblFName.Text + ' ' + lblLName.Text;
                    }
                    if (txtOrgMatch.Text.Trim().ToUpper() != org.ToString().Trim())
                    {
                        lblOrgMessage.Text = "Organization does not match registry result: " + org.ToString().Trim();
                    }
                }
            }
            
            if (lblTaxonomies.Text == "" && lblOrgName.Text == "")
            {
                lblResult.Text = "No results were found in registry!";
                lblTaxonomiesMessage.Text = "";
                lblNameMessage.Text = "";
            }
        }

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            getResult();
        }
    }
}