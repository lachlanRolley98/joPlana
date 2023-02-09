using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace joPlana

//https://stackoverflow.com/questions/8334527/save-listt-to-xml-file look at the last one with 14 likes, looks like pre good way to do it

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {


            dayOverview a = new dayOverview();
            dayOverview b = new dayOverview();
            dayOverview c = new dayOverview();
            dayOverview d = new dayOverview();
            dayOverview e2 = new dayOverview();

            a.fillDay("hi0", "bye0", 1, 2, 3, 4, 5);
            b.fillDay("hi1", "bye1", 1 ,2, 3,4 ,5);
            c.fillDay("hi2", "bye2", 1, 2, 3, 4, 5);
            d.fillDay("hi3", "bye3", 1, 2, 3, 4, 5);
            e2.fillDay("hi4", "bye4", 1, 2, 3, 4, 5);

            List<dayOverview> list = new List<dayOverview>();
            list.Add(a);
            list.Add(b);
            list.Add(c);
            list.Add(d);    
            list.Add(e2);


            XmlSerializer serializer = new XmlSerializer(typeof(List<dayOverview>));

            TextWriter filestream = new StreamWriter("allDays.xml");

            serializer.Serialize(filestream, list);

            filestream.Close();

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlTextWriter writer = new XmlTextWriter("allDays.xml", System.Text.Encoding.UTF8);
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            List<dayOverview> list = new List<dayOverview>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<dayOverview>));

            using (FileStream fileStream = new FileStream("allDays.xml", FileMode.Open))
            {
                list = (List<dayOverview>)serializer.Deserialize(fileStream);
            }

            //var a = list[3].plan;
            //lstNames.Items.Add(a);

            for (int i = 0; i < 100; i++){
                dayOverview a = new dayOverview();
                a.fillDay("hiloop", "byeloop", i+9, i+9, i+9, i+9, i+9);
                list.Add(a);
            }          
            FileStream fileStream1 = new FileStream("allDays.xml", FileMode.Open);


            serializer.Serialize(fileStream1, list);

            fileStream1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<dayOverview> list = new List<dayOverview>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<dayOverview>));

            using (FileStream fileStream = new FileStream("allDays.xml", FileMode.Open))
            {
                list = (List<dayOverview>)serializer.Deserialize(fileStream);
            }

            var a = list[87].g1;
            lstNames.Items.Add(chocolate());
        }



        //works
        public int chocolate()
        {
            return 69;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}