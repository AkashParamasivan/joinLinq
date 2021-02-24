using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace joinLinq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IList<Books> BookList = new List<Books>()
            {
              new Books{Bid=101,Bname="Ponniyin selvan",Author="Kalki"},
              new Books{Bid=102,Bname="spiderman Comics",Author="Stanlee"},
              new Books{Bid=103,Bname="Harry porter",Author="J.K.Rowling"},
              new Books{Bid=104,Bname="Thirukural",Author="valluvar"},
              new Books{Bid=105,Bname="Ramayana",Author="Valmiki"},


            };

           

            IList<Sales> SaleList = new List<Sales>()
            {
              new Sales{Sid=101,Bname="Ponniyin selvan",sDate="22/09/2000",Price=1000},
              new Sales{Sid=102,Bname="spiderman Comics",sDate="12/08/1978",Price=800},
              new Sales{Sid=103,Bname="Harry porter",sDate="23/06/1998",Price=1500},
              new Sales{Sid=104,Bname="Thirukural",sDate="21/09/1949",Price=400},
              new Sales{Sid=105,Bname="Ramayana",sDate="24/04/1980",Price=1200}

            };

            var JoinResult = from b in BookList
                            join s in SaleList
                            on b.Bid equals s.Sid
                            select new {b,s};

            foreach (var obj1 in JoinResult)
            {
                listBox1.Items.Add("Books:"+obj1.b.Bid+" "+obj1.b.Author+" "+obj1.b.Bname
                    +"  Sales:"+obj1.s.Sid+" "+obj1.s.Bname+" "+obj1.s.sDate+" "+obj1.s.Price);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Get Xml data
            XElement xSongElement = XElement.Load("D:\\c#\\joinLinq\\SongsData.xml");

            //Linq 
            IEnumerable<XElement> SongsData = xSongElement.Elements();

            //Display using loop
            foreach(var s in SongsData)
            {
                comboBox1.Items.Add(s.Element("sName").Value);
                comboBox2.Items.Add(s.Element("Composer").Value);
            }
        }
    }
}
