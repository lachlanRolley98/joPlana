using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace joPlana

//https://stackoverflow.com/questions/8334527/save-listt-to-xml-file look at the last one with 14 likes, looks like pre good way to do it
// https://stackoverflow.com/questions/25480445/updating-xml-nodes-from-an-object-list-in-c-sharp  -- if we wana make the search function O(n) instead of n^2, use disctionary explained here

{
    public partial class Form1 : Form
    {
        //globals to be passed into other forms
        



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
            //make sure the fileds are filled in
            if (string.IsNullOrEmpty(recapText.Text))
            {
                recapText.Text = "Must write stuff here.";
                return;
            }
            if (string.IsNullOrEmpty(planText.Text))
            {
                planText.Text = "Must write stuff here.";
                return;
            }

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
            if (checkBox1.Checked) { colour = 4; }
            else if (checkBox2.Checked) { colour = 3; }
            else if (checkBox3.Checked) { colour = 2; }
            else if (checkBox4.Checked) { colour = 1; }
            else  { colour = 0; }

            //check if the day has already been submitted, if it has, rewrite over all the data so no duplicate
            DateTime timeNow = DateTime.Now;
            bool duplicate = false;
            foreach (var day in list)
            {
                if(day.date.Date == timeNow.Date) 
                { 
                    duplicate = true;                    
                    day.recap = recapText.Text;
                    day.plan = planText.Text;
                    day.g1 = trackBar1.Value;
                    day.g2 = trackBar2.Value;
                    day.g3 = trackBar3.Value;
                    day.g4 = trackBar4.Value;
                    day.g5 = trackBar5.Value;
                    day.g6 = trackBar6.Value;
                    day.dayRating = colour;
                    
                }
            }


            //if doesnt already exist,put all app data into day class and add day too list
            if (!duplicate)
            {
                dayOverview curr = new dayOverview();
                curr.fillDay(recapText.Text, planText.Text, trackBar1.Value, trackBar2.Value, trackBar3.Value, trackBar4.Value, trackBar5.Value, trackBar6.Value, colour);
                list.Add(curr);
            }


            //save list in xml
            using (FileStream fileStream = new FileStream("allDays.xml", FileMode.Create))
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
            //make sure the fileds are filled in
            if (string.IsNullOrEmpty(recapText.Text)){
                recapText.Text = "Must write stuff here.";
                return;
            }
            if (string.IsNullOrEmpty(planText.Text))
            {
                planText.Text = "Must write stuff here.";
                return;
            }

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

            //check if duplicate and update day if it is
            DateTime timeNow = monthCalendar1.SelectionRange.Start;
            bool duplicate = false;
            foreach (var day in list)
            {
                if(day.date.Date == timeNow.Date) 
                { 
                    duplicate = true;                    
                    day.recap = recapText.Text;
                    day.plan = planText.Text;
                    day.g1 = trackBar1.Value;
                    day.g2 = trackBar2.Value;
                    day.g3 = trackBar3.Value;
                    day.g4 = trackBar4.Value;
                    day.g5 = trackBar5.Value;
                    day.g6 = trackBar6.Value;
                    day.dayRating = colour;
                    break;
                }
            }

            if (!duplicate)
            {
                dayOverview curr = new dayOverview();
                curr.fillDay(recapText.Text, planText.Text, trackBar1.Value, trackBar2.Value, trackBar3.Value, trackBar4.Value, trackBar5.Value, trackBar6.Value, colour);
                curr.date = monthCalendar1.SelectionRange.Start;
                list.Add(curr);
            }
            

            //save list in xml
            using (FileStream fileStream = new FileStream("allDays.xml", FileMode.Create))
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
            List<dayOverview> bufferDayOverViewList = new List<dayOverview>();

            //grab all the data from xml
            XmlSerializer serializer = new XmlSerializer(typeof(List<dayOverview>));
            using (FileStream fileStream = new FileStream("allDays.xml", FileMode.Open))
            {
                list = (List<dayOverview>)serializer.Deserialize(fileStream);
                fileStream.Close();
            }

            
            bool recordFound = false;
            foreach (var day in list)
            {
                if(day.date.Date == specificDay.Date)
                {
                    
                    recordFound = true;
                    bufferDayOverViewList.Add(day);
                }
            }

            var m = new Form2();
            m.Show();
            m.fillForm2Recap(sender, e, bufferDayOverViewList);






        }

        private void submitDreams_Click(object sender, EventArgs e)
        {
            var m = new Form3();
            m.Show();
            
        }

        private void viewWeekButton_Click(object sender, EventArgs e)
        {
            var m = new weekRecapForm();
            m.Show();
        }
    }
}