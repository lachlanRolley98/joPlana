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

       
        //put somthing in xml so its initialised
        private void button1_Click_2(object sender, EventArgs e)
        {


            dayOverview a = new dayOverview();
            

            a.fillDay("aa", "bye0", 1, 2, 3, 4, 5, 6, 7);
            

            List<dayOverview> list = new List<dayOverview>();
            list.Add(a);
           


            XmlSerializer serializer = new XmlSerializer(typeof(List<dayOverview>));

            TextWriter filestream = new StreamWriter("allDays.xml");

            serializer.Serialize(filestream, list);

            filestream.Close();
            filestream.Close();


        }












        private void label2_Click(object sender, EventArgs e)
        {

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
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

       
        
        
        private void submitDayNow_Click(object sender, EventArgs e)
        {
            List<dayOverview> list = new List<dayOverview>();

            //grab all the data from xml
            XmlSerializer serializer = new XmlSerializer(typeof(List<dayOverview>));
            using (FileStream fileStream = new FileStream("allDays.xml", FileMode.Open))
            {               
                    list = (List<dayOverview>)serializer.Deserialize(fileStream); 
                    fileStream.Close();
            }

            //grab data from app and append to list
            int colour = 0;
            if (checkBox1.Checked) { colour = 5; }
            else if (checkBox2.Checked) { colour = 4; }
            else if (checkBox3.Checked) { colour = 3; }
            else if (checkBox4.Checked) { colour = 2; }
            else  { colour = 1; }
            dayOverview curr = new dayOverview();
            curr.fillDay(recapText.Text, planText.Text, trackBar1.Value, trackBar2.Value, trackBar3.Value, trackBar4.Value, trackBar5.Value, trackBar6.Value, colour);
            list.Add(curr);

            //save list in xml
            using (FileStream fileStream = new FileStream("allDays.xml", FileMode.Open))
            {
                serializer.Serialize(fileStream, list);
                fileStream.Close();
            }

            //cleanup text boxes and sliders
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;

            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            trackBar4.Value = 0;
            trackBar5.Value = 0;
            trackBar6.Value = 0;

            recapText.Text = "";
            planText.Text = "";
        }

        private void submitDayDate_Click(object sender, EventArgs e)
        {
            List<dayOverview> list = new List<dayOverview>();

            //grab all the data from xml
            XmlSerializer serializer = new XmlSerializer(typeof(List<dayOverview>));
            using (FileStream fileStream = new FileStream("allDays.xml", FileMode.Open))
            {
                list = (List<dayOverview>)serializer.Deserialize(fileStream);
                fileStream.Close();
            }

            //grab data from app and append to list
            //grab data from app and append to list
            int colour = 0;
            if (checkBox1.Checked) { colour = 5; }
            else if (checkBox2.Checked) { colour = 4; }
            else if (checkBox3.Checked) { colour = 3; }
            else if (checkBox4.Checked) { colour = 2; }
            else { colour = 1; }
            dayOverview curr = new dayOverview();
            curr.fillDay(recapText.Text, planText.Text, trackBar1.Value, trackBar2.Value, trackBar3.Value, trackBar4.Value, trackBar5.Value, trackBar6.Value, colour);
            curr.date = monthCalendar1.SelectionRange.Start;
            list.Add(curr);

            //save list in xml
            using (FileStream fileStream = new FileStream("allDays.xml", FileMode.Open))
            {
                serializer.Serialize(fileStream, list);
                fileStream.Close();
            }

            //cleanup text boxes and sliders
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;

            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            trackBar4.Value = 0;
            trackBar5.Value = 0;
            trackBar6.Value = 0;

            recapText.Text = "";
            planText.Text = "";
        }

        private void viewDayButton_Click(object sender, EventArgs e)
        {

            DateTime specificDay = monthCalendar1.SelectionRange.Start;

            List<dayOverview> list = new List<dayOverview>();
            //grab all the data from xml
            XmlSerializer serializer = new XmlSerializer(typeof(List<dayOverview>));
            using (FileStream fileStream = new FileStream("allDays.xml", FileMode.Open))
            {
                list = (List<dayOverview>)serializer.Deserialize(fileStream);
                fileStream.Close();
            }

            dayOverview yeet = new dayOverview();
            foreach (var day in list)
            {
                if(day.date.Date == specificDay.Date)
                {
                    yeet = day;
                }
            }



            var m = new Form2();
            m.Show();

        }

       
    }
}