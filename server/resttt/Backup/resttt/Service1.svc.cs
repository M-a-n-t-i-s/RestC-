using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace resttt
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1
    {
        // Чтобы использовать протокол HTTP GET, добавьте атрибут [WebGet]. (По умолчанию ResponseFormat имеет значение WebMessageFormat.Json.)
        // Чтобы создать операцию, возвращающую XML,
        //     добавьте [WebGet(ResponseFormat=WebMessageFormat.Xml)]
        //     и включите следующую строку в текст операции:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        //[WebGet(UriTemplate = "/get{marka}/{model}")]
        [WebGet(UriTemplate = "/get/{model}/{marka}/{type}/{kol}/{data}")]
        public List<string> GetListOfAuto(string model, string marka,string type,string kol, string data  )
        {
            List<string> cl = new List<string>();
            string cs = "Server=dbs; Database=Учебная; User ID=test; Password=test;";
           // string type = "", kol = "", data = "";
            if (model == "0") model = "";
            if (marka == "0") marka = "";
            if (type == "0") type = "";
            if (kol == "0") kol = "";
            if (data == "0") data = "";

            string selstr = "SELECT *";


            selstr += " FROM АвтоКоролев";
            if (marka != "" || model != "" || type != "" || kol != "" || data != "")
            {
                selstr += " WHERE";
                int itt = 0;
                if (marka != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Марка=" + "'" + marka + "'";
                    itt = 1;
                }

                if (model != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Модель=" + "'" + model + "'";
                    itt = 1;

                }
                if (type != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " ТипАвто=" + "'" + type + "'";
                    itt = 1;

                }
                if (kol != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Количество=" + "'" + kol + "'";
                    itt = 1;

                }
                if (data != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Дата=" + "'" + data + "'";
                    itt = 1;

                }
            }







            DataTable dd = new DataTable();


            using (SqlDataAdapter sda = new SqlDataAdapter(selstr, new SqlConnection(cs)))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cl.Add(dr[0].ToString() + dr[1].ToString() + dr[2].ToString() + dr[3].ToString() + "        " + dr[4].ToString());
                };

                //   dd = dt;
            }

            return cl;
            
        }

        [WebGet(UriTemplate = "/add/{model}/{marka}/{type}/{kol}/{data}")]
        public int AddListOfAuto(string marka, string model, string type, string kol, string data)
        {
            string cs = "Server=dbs; Database=Учебная; User ID=test; Password=test;";
            string command = "INSERT INTO АвтоКоролев SELECT '" + model + "','"
                + marka + "','" + type + "'," + Convert.ToInt32(kol) + ", '"
                + Convert.ToDateTime(data) + "' ";
            SqlConnection scon = new SqlConnection(cs);
            scon.Open();
            SqlCommand updcmd = new SqlCommand(command, scon);
            updcmd.ExecuteNonQuery();
            scon.Close();
            return 0;

        }



        [WebGet(UriTemplate = "/edit/{modelKEY}/{marka}/{type}/{kol}/{data}")]
        public int EditListOfAuto(string modelKEY, string marka, string type, string kol, string data)
        {
            string cs = "Server=dbs; Database=Учебная; User ID=test; Password=test;";
            string selstr = "UPDATE АвтоКоролев ";

            if (marka != "" || type != "" || kol != "" || data != "")
            {
                selstr += " Set";
                int itt = 0;
                if (marka != "")
                {
                    if (itt == 1) { selstr += " , "; };
                    selstr += " Марка=" + "'" + marka + "'";
                    itt = 1;
                }


                if (type != "")
                {
                    if (itt == 1) { selstr += " , "; };
                    selstr += " ТипАвто=" + "'" + type + "'";
                    itt = 1;

                }
                if (kol != "")
                {
                    if (itt == 1) { selstr += " , "; };
                    selstr += " Количество=" + "'" + kol + "'";
                    itt = 1;

                }
                if (data != "")
                {
                    if (itt == 1) { selstr += " , "; };
                    selstr += " Дата=" + "'" + data + "'";
                    itt = 1;

                }
            }
            selstr += " WHERE Модель = '" + modelKEY + "'";

            SqlConnection scon = new SqlConnection(cs);
            scon.Open();
            SqlCommand updcmd = new SqlCommand(selstr, scon);
            updcmd.ExecuteNonQuery();
            scon.Close();
            return 0;

        }








        [WebGet(UriTemplate = "/delete/{model}/{marka}/{type}/{kol}/{data}")]
        public int DeleteListOfAuto(string marka, string model, string type, string kol, string data)
        {
            string cs = "Server=dbs; Database=Учебная; User ID=test; Password=test;";






            string selstr = "Delete FROM АвтоКоролев";
            if (marka != "" || model != "" || type != "" || kol != "" || data != "")
            {
                selstr += " WHERE";
                int itt = 0;
                if (marka != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Марка=" + "'" + marka + "'";
                    itt = 1;
                }

                if (model != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Модель=" + "'" + model + "'";
                    itt = 1;

                }
                if (type != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " ТипАвто=" + "'" + type + "'";
                    itt = 1;

                }
                if (kol != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Количество=" + "'" + Convert.ToInt32(kol) + "'";
                    itt = 1;

                }
                if (data != "")
                {
                    if (itt == 1) { selstr += " and "; };
                    selstr += " Дата=" + "'" + Convert.ToDateTime(data) + "'";
                    itt = 1;

                }
            }



            SqlConnection scon = new SqlConnection(cs);
            scon.Open();
            SqlCommand updcmd = new SqlCommand(selstr, scon);
            updcmd.ExecuteNonQuery();
            scon.Close();
            return 0;

        }
        // Добавьте здесь дополнительные операции и отметьте их атрибутом [OperationContract]
    }
}
