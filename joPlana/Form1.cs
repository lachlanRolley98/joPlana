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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
                lstNames.Items.Add(txtName.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"D:\myProjects\joPlanaData\days.txt";
            FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None);

            Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.\n");
            // Add some information to the file.
            fs.Write(info, 0, info.Length);
            fs.Close();
            //using (FileStream fs = File.Create(path)) ;

            using (StreamWriter w = File.AppendText(@"D:\myProjects\joPlanaData\days.txt"))
            {
                w.WriteLine("sup bro");
                w.WriteLine("itsa mee");
                w.WriteLine("mario");
            }

            using (StreamReader sr = File.OpenText(@"D:\myProjects\joPlanaData\days.txt"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
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


            XmlSerializer serialiser = new XmlSerializer(typeof(List<dayOverview>));

            TextWriter filestream = new StreamWriter("allDays.xml");

            serialiser.Serialize(filestream, list);

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
                list = (List<dayOverview>) serializer.Deserialize(fileStream);
            }

            var a = list[3].plan;
            lstNames.Items.Add(a);
        }
    }
}