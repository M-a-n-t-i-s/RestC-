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
        string cs =@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        // Чтобы использовать протокол HTTP GET, добавьте атрибут [WebGet]. (По умолчанию ResponseFormat имеет значение WebMessageFormat.Json.)
        // Чтобы создать операцию, возвращающую XML,
        //     добавьте [WebGet(ResponseFormat=WebMessageFormat.Xml)]
        //     и включите следующую строку в текст операции:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

        [WebGet(UriTemplate = "/get/{Id}/{Name}/{Amount}/{Price}/{Description}")]
        public List<Tuple<string,string,string,string,string>> GetListOfClothers(string Id, string Name, string Amount,string Price, string Description  )
        {
            List<Tuple<string, string, string, string, string>> clothers = new List<Tuple<string, string, string, string, string>>();
             
            if (Id == "0") Id = "";
            if (Name == "0") Name = "";
            if (Amount == "0") Amount = "";
            if (Price == "0") Price = "";
            if (Description == "0") Description = "";

           string selStr = "SELECT *";
            
            
            selStr += " FROM Shop";
            if (Id != "" || Name != "" || Amount != "" || Price != "" || Description != "")
            {
                selStr += " WHERE";
                int flag = 0;
                if (Id != "")
                {
                    if (flag == 1) { selStr += " and "; };
                    selStr += " Id=" + "'" + Id + "'";
                    flag = 1;
                }
               
                if (Name != "")
                {
                    if (flag == 1) { selStr += " and "; };
                    selStr += " Name=" + "'" + Name + "'";
                    flag = 1;

                }
                if (Amount != "")
                {
                    if (flag == 1) { selStr += " and "; };
                    selStr += " Amount=" + "'" + Amount + "'";
                    flag = 1;

                }
                if (Price != "")
                {
                    if (flag == 1) { selStr += " and "; };
                    selStr += " Price=" + "'" + Price + "'";
                    flag = 1;

                }
                if (Description != "")
                {
                    if (flag == 1) { selStr += " and "; };
                    selStr += " Description=" + "'" + Description + "'";
                    flag = 1;

                }
            }
            


            DataTable dd = new DataTable();


            using (SqlDataAdapter sda = new SqlDataAdapter(selStr, new SqlConnection(cs)))
            {
                DataTable table = new DataTable();
                sda.Fill(table);
                foreach (DataRow dr in table.Rows)
                {
                    clothers.Add(new Tuple<string,string,string,string,string> (dr[0].ToString() , dr[1].ToString() , dr[2].ToString() , dr[3].ToString() ,  dr[4].ToString()));
                };


            }

            return clothers;
            
        }

        [WebGet(UriTemplate = "/add/{Id}/{Name}/{Amount}/{Price}/{Description}")]
        public int AddListOfClothers(string Id, string Name, string Amount, string Price, string Description)
        {

            string command = "INSERT INTO Shop SELECT '" + Convert.ToInt32(Id) + "','"
                + Name + "','" + Convert.ToInt32(Amount) + "'," + Convert.ToInt32(Price) + ", '"
                + Description + "' ";
            SqlConnection scon = new SqlConnection(cs);
            scon.Open();
            SqlCommand updcmd = new SqlCommand(command, scon);
            updcmd.ExecuteNonQuery();
            scon.Close();
            return 0;

        }



        [WebGet(UriTemplate = "/edit/{Id}/{Name}/{Amount}/{Price}/{Description}")]
        public int EditListOfClothers(string Id, string Name, string Amount, string Price, string Description)
        {     
            string selStr = "UPDATE Shop ";

            if (Name != "" || Amount != "" || Price != "" || Description != "")
            {
                selStr += " Set";
                int itt = 0;
                if (Name != "")
                {
                    if (itt == 1) { selStr += " , "; };
                    selStr += " Name=" + "'" + Name + "'";
                    itt = 1;
                }

                if (Amount != "")
                {
                    if (itt == 1) { selStr += " , "; };
                    selStr += " Amount=" + "'" + Amount + "'";
                    itt = 1;

                }
                if (Price != "")
                {
                    if (itt == 1) { selStr += " , "; };
                    selStr += " Price=" + "'" + Price + "'";
                    itt = 1;

                }
                if (Description != "")
                {
                    if (itt == 1) { selStr += " , "; };
                    selStr += " Description=" + "'" + Description + "'";
                    itt = 1;

                }
            }
            selStr += " WHERE Id = '" + Id + "'";

            SqlConnection scon = new SqlConnection(cs);
            scon.Open();
            SqlCommand updcmd = new SqlCommand(selStr, scon);
            updcmd.ExecuteNonQuery();
            scon.Close();
            return 0;

        }


        [WebGet(UriTemplate = "/delete/{Id}/{Name}/{Amount}/{Price}/{Description}")]
        public int DeleteListOfClothers(string Id, string Name, string Amount, string Price, string Description)
        {


            string selStr = "Delete FROM Shop";
            if (Id != "" || Name != "" || Amount != "" || Price != "" || Description != "")
            {
                selStr += " WHERE";
                int flag = 0;
                if (Id != "")
                {
                    if (flag == 1) { selStr += " and "; };
                    selStr += " Id=" + "'" + Convert.ToInt32(Id) + "'";
                    flag = 1;
                }

                if (Name != "")
                {
                    if (flag == 1) { selStr += " and "; };
                    selStr += " Name=" + "'" + Name + "'";
                    flag = 1;

                }
                if (Amount != "")
                {
                    if (flag == 1) { selStr += " and "; };
                    selStr += " Amount =" + "'" + Convert.ToInt32(Amount) + "'";
                    flag = 1;

                }
                if (Price != "")
                {
                    if (flag == 1) { selStr += " and "; };
                    selStr += " Price=" + "'" + Convert.ToInt32(Price) + "'";
                    flag = 1;

                }
                if (Description != "")
                {
                    if (flag == 1) { selStr += " and "; };
                    selStr += " Description=" + "'" + Description + "'";
                    flag = 1;

                }
            }



            SqlConnection scon = new SqlConnection(cs);
            scon.Open();
            SqlCommand updcmd = new SqlCommand(selStr, scon);
            updcmd.ExecuteNonQuery();
            scon.Close();
            return 0;

        }
        // Добавьте здесь дополнительные операции и отметьте их атрибутом [OperationContract]
    }
}
