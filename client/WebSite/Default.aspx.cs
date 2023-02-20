using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http.Headers;
using System.Net.Http;
using HtmlAgilityPack;
using System.Net;
using System.Drawing;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Xml;

public partial class _Default : Page
{
    public string url;

    protected void Page_Load(object sender, EventArgs e)
    {
        Button6.Visible = false;
        Button5.Visible = false;
        Label6.Visible = false;
    }
 
   
    protected void Button1_Click1(object sender, System.EventArgs e)
    { 
      ListBox1.Items.Clear();
      string Name = "0", Id = "0", Amount = "0", Price = "0", Description = "0";
      Name =  Id =  Amount = Price=  Description = "0";
      if (TextBox1.Text != "") { Name = TextBox1.Text; };
      if (TextBox2.Text != "") { Id = TextBox2.Text; };
      if (TextBox3.Text != "") { Amount = TextBox3.Text; };
      if (TextBox4.Text != "") { Price = TextBox4.Text; };
      if (TextBox5.Text != "") { Description = TextBox5.Text; };
     
       HtmlWeb web = new HtmlWeb();
       ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
       url = "http://localhost:50406/Service1.svc/get/" + Id + "/" + Name + "/" + Amount + "/" + Price + "/" + Description;
       XmlTextReader reader = new XmlTextReader(url);
       int counter = 0;
       string din = null;

       while (reader.Read())
       {
         
           if (String.IsNullOrWhiteSpace(reader.Value) == false ) { din = din + reader.Value + "_____"; counter++; };
           
          if(counter==5) { ListBox1.Items.Add(din); din=null; counter=0; }; 
        }
      
    

    }
    protected void Button2_Click1(object sender, System.EventArgs e)
    {
        ListBox1.Items.Clear();
        string Name = "0", Id = "0", Amount = "0", Price = "0", Description = "0";
        Name = Id = Amount = Price = Description = "0";
        if (TextBox1.Text != "") { Name = TextBox1.Text; };
        if (TextBox2.Text != "") { Id = TextBox2.Text; };
        if (TextBox3.Text != "") { Amount = TextBox3.Text; };
        if (TextBox4.Text != "") { Price = TextBox4.Text; };
        if (TextBox5.Text != "") { Description = TextBox5.Text; };
        url = "http://localhost:50406/Service1.svc/add/" + Id + "/" + Name + "/" + Amount + "/" + Price + "/" + Description;

    
        using (var client = new WebClient())
        {
            var responseString = client.DownloadString(url);
        }


        ListBox1.Items.Add("Добавление успешно"); 
    }
    protected void Button3_Click1(object sender, System.EventArgs e)
    {
  
        ListBox1.Items.Clear();
        Button6.Visible = true;
        Button5.Visible = true;
        Label6.Visible = true;
      
    }
    protected void Button4_Click1(object sender, System.EventArgs e)
    {
        ListBox1.Items.Clear();

        string Name = "0", Id = "0", Amount = "0", Price = "0", Description = "0";
        Name = Id = Amount = Price = Description = "0";
        if (TextBox1.Text != "") { Name = TextBox1.Text; };
        if (TextBox2.Text != "") { Id = TextBox2.Text; };
        if (TextBox3.Text != "") { Amount = TextBox3.Text; };
        if (TextBox4.Text != "") { Price = TextBox4.Text; };
        if (TextBox5.Text != "") { Description = TextBox5.Text; };

        
        url = "http://localhost:50406/Service1.svc/edit/" + Id + "/" + Name + "/" + Amount + "/" + Price + "/" + Description;

        using (var client = new WebClient())
        {
            var responseString = client.DownloadString(url);
        }


        ListBox1.Items.Add("Изменение успешно"); 
    }
    protected void Button5_Click(object sender, System.EventArgs e)
    {
        string Name = "0", Id = "0", Amount = "0", Price = "0", Description = "0";
        Name = Id = Amount = Price = Description = "0";
        if (TextBox1.Text != "") { Name = TextBox1.Text; };
        if (TextBox2.Text != "") { Id = TextBox2.Text; };
        if (TextBox3.Text != "") { Amount = TextBox3.Text; };
        if (TextBox4.Text != "") { Price = TextBox4.Text; };
        if (TextBox5.Text != "") { Description = TextBox5.Text; };

        url = "http://localhost:50406/Service1.svc/delete/" + Id + "/" + Name + "/" + Amount + "/" + Price + "/" + Description;

        using (var client = new WebClient())
        {
            var responseString = client.DownloadString(url);
        }

        ListBox1.Items.Add("Удаление успешно"); 
    }
    protected void Button6_Click(object sender, System.EventArgs e)
    {
        Button6.Visible = false;
        Button5.Visible = false;
        Label6.Visible = false;
    }
}

   