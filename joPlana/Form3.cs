using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace joPlana
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void submitDream_Click(object sender, EventArgs e)
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
            DateTime specificDay = monthCalendar1.SelectionRange.Start;
            String dream = textBox1.Text;

            //find which day in list we wana add dream too then insert into correct day in list
            bool dayFound = false;
            foreach (var day in list)
            {
                if (day.date.Date == specificDay.Date)
                {
                    //we have found the day
                    day.dream = dream;
                    dayFound = true;
                    textBox2.Text = "Dream Recorded";
                }
            }

            //if we cant find the day, just reply please create day before submitting dream (ctrl c dream first)
            if (!dayFound)
            {
                textBox2.Text = "please create day before submitting dream";
            }

            //save list in xml
            using (FileStream fileStream = new FileStream("allDays.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, list);
                fileStream.Close();
            }
        }
    }
}
