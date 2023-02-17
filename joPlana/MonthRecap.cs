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
    public partial class MonthRecap : Form
    {

        DateTime dateHolder;
        int avg1;
        int avg2;
        int avg3;
        int avg4;
        int avg5;
        int avg6;

        
        public MonthRecap()
        {
            InitializeComponent();
        }

        private void MonthRecap_Load(object sender, EventArgs e)
        {
            
        }


        //ok in this bad boy, grab the date and find its month
        //grab every review with that month in a list
        //sort the list
        //put in respective boxes 
        //do a save month recap and plan aswell
        public void setup(object sender, EventArgs e, DateTime fullDateTime)
        {
            dateHolder = fullDateTime;
            List<weMoRePlan> list = new List<weMoRePlan>();

            //grab all the data from xml, note use of file.Open instead of create
            XmlSerializer serializer = new XmlSerializer(typeof(List<weMoRePlan>));
            using (FileStream fileStream = new FileStream("allWeekMonths.xml", FileMode.Open))
            {
                list = (List<weMoRePlan>)serializer.Deserialize(fileStream);
                fileStream.Close();
            }

            //ok here we got all the week and month recaps in the list


            List<weMoRePlan> listWeeks = new List<weMoRePlan>();
            List<weMoRePlan> listMonths = new List<weMoRePlan>();

            //now we wana run through the list and grab all the weeks that correlate to our specific week

            foreach (var m in list)
            {
                if(m.date.Month == fullDateTime.Month && m.type == "week"){listWeeks.Add(m);}
                if( m.type == "month"){listMonths.Add(m); }

            }
            
            //aight here we got all the week and month recaps in there respective lists
            //now we wana fill in each box with the week recap
            if(listWeeks.Count > 0)
            {
                textBox1.Text = listWeeks[0].recap;
                if (listWeeks[0].g1 == 0) { panel1.BackColor = Color.Red; }
                else if (listWeeks[0].g1 == 1) { panel1.BackColor = Color.Orange; avg1 = avg1 + 1; }
                else if (listWeeks[0].g1 == 2) { panel1.BackColor = Color.Yellow; avg1 = avg1 + 2; }
                else if (listWeeks[0].g1 == 3) { panel1.BackColor = Color.Lime; avg1 = avg1 + 3; }
                else { panel1.BackColor = Color.Cyan; avg1 = avg1 + 4; }
                if (listWeeks[0].g2 == 0) { panel16.BackColor = Color.Red; }
                else if (listWeeks[0].g2 == 1) { panel16.BackColor = Color.Orange; avg2 = avg2 + 1; }
                else if (listWeeks[0].g2 == 2) { panel16.BackColor = Color.Yellow; avg2 = avg2 + 2; }
                else if (listWeeks[0].g2 == 3) { panel16.BackColor = Color.Lime; avg2 = avg2 + 3; }
                else { panel16.BackColor = Color.Cyan; avg2 = avg2 + 4; }
                if (listWeeks[0].g3 == 0) { panel24.BackColor = Color.Red; }
                else if (listWeeks[0].g3 == 1) { panel24.BackColor = Color.Orange; avg3 = avg3 + 1; }
                else if (listWeeks[0].g3 == 2) { panel24.BackColor = Color.Yellow; avg3 = avg3 + 2; }
                else if (listWeeks[0].g3 == 3) { panel24.BackColor = Color.Lime; avg3 = avg3 + 3; }
                else { panel24.BackColor = Color.Cyan; avg3 = avg3 + 4; }
                if (listWeeks[0].g4 == 0) { panel32.BackColor = Color.Red; }
                else if (listWeeks[0].g4 == 1) { panel32.BackColor = Color.Orange; avg4 = avg4 + 1; }
                else if (listWeeks[0].g4 == 2) { panel32.BackColor = Color.Yellow; avg4 = avg4 + 2; }
                else if (listWeeks[0].g4 == 3) { panel32.BackColor = Color.Lime; avg4 = avg4 + 3; }
                else { panel32.BackColor = Color.Cyan; avg4 = avg4 + 4; }
                if (listWeeks[0].g5 == 0) { panel40.BackColor = Color.Red; }
                else if (listWeeks[0].g5 == 1) { panel40.BackColor = Color.Orange; avg5 = avg5 + 1; }
                else if (listWeeks[0].g5 == 2) { panel40.BackColor = Color.Yellow; avg5 = avg5 + 2; }
                else if (listWeeks[0].g5 == 3) { panel40.BackColor = Color.Lime; avg5 = avg5 + 3; }
                else { panel40.BackColor = Color.Cyan; avg5 = avg5 + 4; }
                if (listWeeks[0].g6 == 0) { panel48.BackColor = Color.Red; }
                else if (listWeeks[0].g6 == 1) { panel48.BackColor = Color.Orange; avg6 = avg6 + 1; }
                else if (listWeeks[0].g6 == 2) { panel48.BackColor = Color.Yellow; avg6 = avg6 + 2; }
                else if (listWeeks[0].g6 == 3) { panel48.BackColor = Color.Lime; avg6 = avg6 + 3; }
                else { panel48.BackColor = Color.Cyan; avg6 = avg6 + 4; }

                //colour in recap box
                if (listWeeks[0].weekrating == 0) { textBox1.BackColor = Color.Red; }
                else if (listWeeks[0].weekrating == 1) { textBox1.BackColor = Color.Orange; }
                else if (listWeeks[0].weekrating == 2) { textBox1.BackColor = Color.Yellow; }
                else if (listWeeks[0].weekrating == 3) { textBox1.BackColor = Color.Lime; }
                else { textBox1.BackColor = Color.Cyan; }
            }
            if (listWeeks.Count > 1)
            {
                textBox2.Text = listWeeks[1].recap;
                if (listWeeks[1].g1 == 0) { panel2.BackColor = Color.Red; }
                else if (listWeeks[1].g1 == 1) { panel2.BackColor = Color.Orange; avg1 = avg1 + 1; }
                else if (listWeeks[1].g1 == 2) { panel2.BackColor = Color.Yellow; avg1 = avg1 + 2; }
                else if (listWeeks[1].g1 == 3) { panel2.BackColor = Color.Lime; avg1 = avg1 + 3; }
                else { panel2.BackColor = Color.Cyan; avg1 = avg1 + 4; }
                if (listWeeks[1].g2 == 0) { panel15.BackColor = Color.Red; }
                else if (listWeeks[1].g2 == 1) { panel15.BackColor = Color.Orange; avg2 = avg2 + 1; }
                else if (listWeeks[1].g2 == 2) { panel15.BackColor = Color.Yellow; avg2 = avg2 + 2; }
                else if (listWeeks[1].g2 == 3) { panel15.BackColor = Color.Lime; avg2 = avg2 + 3; }
                else { panel15.BackColor = Color.Cyan; avg2 = avg2 + 4; }
                if (listWeeks[1].g3 == 0) { panel23.BackColor = Color.Red; }
                else if (listWeeks[1].g3 == 1) { panel23.BackColor = Color.Orange; avg3 = avg3 + 1; }
                else if (listWeeks[1].g3 == 2) { panel23.BackColor = Color.Yellow; avg3 = avg3 + 2; }
                else if (listWeeks[1].g3 == 3) { panel23.BackColor = Color.Lime; avg3 = avg3 + 3; }
                else { panel23.BackColor = Color.Cyan; avg3 = avg3 + 4; }
                if (listWeeks[1].g4 == 0) { panel31.BackColor = Color.Red; }
                else if (listWeeks[1].g4 == 1) { panel31.BackColor = Color.Orange; avg4 = avg4 + 1; }
                else if (listWeeks[1].g4 == 2) { panel31.BackColor = Color.Yellow; avg4 = avg4 + 2; }
                else if (listWeeks[1].g4 == 3) { panel31.BackColor = Color.Lime; avg4 = avg4 + 3; }
                else { panel31.BackColor = Color.Cyan; avg4 = avg4 + 4; }
                if (listWeeks[1].g5 == 0) { panel39.BackColor = Color.Red; }
                else if (listWeeks[1].g5 == 1) { panel39.BackColor = Color.Orange; avg5 = avg5 + 1; }
                else if (listWeeks[1].g5 == 2) { panel39.BackColor = Color.Yellow; avg5 = avg5 + 2; }
                else if (listWeeks[1].g5 == 3) { panel39.BackColor = Color.Lime; avg5 = avg5 + 3; }
                else { panel39.BackColor = Color.Cyan; avg5 = avg5 + 4; }
                if (listWeeks[1].g6 == 0) { panel47.BackColor = Color.Red; }
                else if (listWeeks[1].g6 == 1) { panel47.BackColor = Color.Orange; avg6 = avg6 + 1; }
                else if (listWeeks[1].g6 == 2) { panel47.BackColor = Color.Yellow; avg6 = avg6 + 2; }
                else if (listWeeks[1].g6 == 3) { panel47.BackColor = Color.Lime; avg6 = avg6 + 3; }
                else { panel47.BackColor = Color.Cyan; avg6 = avg6 + 4; }

                //colour in recap box
                if (listWeeks[1].weekrating == 0) { textBox2.BackColor = Color.Red; }
                else if (listWeeks[1].weekrating == 1) { textBox2.BackColor = Color.Orange; }
                else if (listWeeks[1].weekrating == 2) { textBox2.BackColor = Color.Yellow; }
                else if (listWeeks[1].weekrating == 3) { textBox2.BackColor = Color.Lime; }
                else { textBox2.BackColor = Color.Cyan; }

            }
            if (listWeeks.Count > 2)
            {
                textBox3.Text = listWeeks[2].recap;
                if (listWeeks[2].g1 == 0) { panel3.BackColor = Color.Red; }
                else if (listWeeks[2].g1 == 1) { panel3.BackColor = Color.Orange; avg1 = avg1 + 1; }
                else if (listWeeks[2].g1 == 2) { panel3.BackColor = Color.Yellow; avg1 = avg1 + 2; }
                else if (listWeeks[2].g1 == 3) { panel3.BackColor = Color.Lime; avg1 = avg1 + 3; }
                else { panel3.BackColor = Color.Cyan; avg1 = avg1 + 4; }
                if (listWeeks[2].g2 == 0) { panel14.BackColor = Color.Red; }
                else if (listWeeks[2].g2 == 1) { panel14.BackColor = Color.Orange; avg2 = avg2 + 1; }
                else if (listWeeks[2].g2 == 2) { panel14.BackColor = Color.Yellow; avg2 = avg2 + 2; }
                else if (listWeeks[2].g2 == 3) { panel14.BackColor = Color.Lime; avg2 = avg2 + 3; }
                else { panel14.BackColor = Color.Cyan; avg2 = avg2 + 4; }
                if (listWeeks[2].g3 == 0) { panel22.BackColor = Color.Red; }
                else if (listWeeks[2].g3 == 1) { panel22.BackColor = Color.Orange; avg3 = avg3 + 1; }
                else if (listWeeks[2].g3 == 2) { panel22.BackColor = Color.Yellow; avg3 = avg3 + 2; }
                else if (listWeeks[2].g3 == 3) { panel22.BackColor = Color.Lime; avg3 = avg3 + 3; }
                else { panel22.BackColor = Color.Cyan; avg3 = avg3 + 4; }
                if (listWeeks[2].g4 == 0) { panel30.BackColor = Color.Red; }
                else if (listWeeks[2].g4 == 1) { panel30.BackColor = Color.Orange; avg4 = avg4 + 1; }
                else if (listWeeks[2].g4 == 2) { panel30.BackColor = Color.Yellow; avg4 = avg4 + 2; }
                else if (listWeeks[2].g4 == 3) { panel30.BackColor = Color.Lime; avg4 = avg4 + 3; }
                else { panel30.BackColor = Color.Cyan; avg4 = avg4 + 4; }
                if (listWeeks[2].g5 == 0) { panel38.BackColor = Color.Red; }
                else if (listWeeks[2].g5 == 1) { panel38.BackColor = Color.Orange; avg5 = avg5 + 1; }
                else if (listWeeks[2].g5 == 2) { panel38.BackColor = Color.Yellow; avg5 = avg5 + 2; }
                else if (listWeeks[2].g5 == 3) { panel38.BackColor = Color.Lime; avg5 = avg5 + 3; }
                else { panel38.BackColor = Color.Cyan; avg5 = avg5 + 4; }
                if (listWeeks[2].g6 == 0) { panel46.BackColor = Color.Red; }
                else if (listWeeks[2].g6 == 1) { panel46.BackColor = Color.Orange; avg6 = avg6 + 1; }
                else if (listWeeks[2].g6 == 2) { panel46.BackColor = Color.Yellow; avg6 = avg6 + 2; }
                else if (listWeeks[2].g6 == 3) { panel46.BackColor = Color.Lime; avg6 = avg6 + 3; }
                else { panel46.BackColor = Color.Cyan; avg6 = avg6 + 4; }

                //colour in recap box
                if (listWeeks[2].weekrating == 0) { textBox3.BackColor = Color.Red; }
                else if (listWeeks[2].weekrating == 1) { textBox3.BackColor = Color.Orange; }
                else if (listWeeks[2].weekrating == 2) { textBox3.BackColor = Color.Yellow; }
                else if (listWeeks[2].weekrating == 3) { textBox3.BackColor = Color.Lime; }
                else { textBox3.BackColor = Color.Cyan; }

            }
            if (listWeeks.Count > 3)
            {
                if (listWeeks[3].g1 == 0) { panel4.BackColor = Color.Red; }
                else if (listWeeks[3].g1 == 1) { panel4.BackColor = Color.Orange; avg1 = avg1 + 1; }
                else if (listWeeks[3].g1 == 2) { panel4.BackColor = Color.Yellow; avg1 = avg1 + 2; }
                else if (listWeeks[3].g1 == 3) { panel4.BackColor = Color.Lime; avg1 = avg1 + 3; }
                else { panel4.BackColor = Color.Cyan; avg1 = avg1 + 4; }
                if (listWeeks[3].g2 == 0) { panel13.BackColor = Color.Red; }
                else if (listWeeks[3].g2 == 1) { panel13.BackColor = Color.Orange; avg2 = avg2 + 1; }
                else if (listWeeks[3].g2 == 2) { panel13.BackColor = Color.Yellow; avg2 = avg2 + 2; }
                else if (listWeeks[3].g2 == 3) { panel13.BackColor = Color.Lime; avg2 = avg2 + 3; }
                else { panel13.BackColor = Color.Cyan; avg2 = avg2 + 4; }
                if (listWeeks[3].g3 == 0) { panel21.BackColor = Color.Red; }
                else if (listWeeks[3].g3 == 1) { panel21.BackColor = Color.Orange; avg3 = avg3 + 1; }
                else if (listWeeks[3].g3 == 2) { panel21.BackColor = Color.Yellow; avg3 = avg3 + 2; }
                else if (listWeeks[3].g3 == 3) { panel21.BackColor = Color.Lime; avg3 = avg3 + 3; }
                else { panel21.BackColor = Color.Cyan; avg3 = avg3 + 4; }
                if (listWeeks[3].g4 == 0) { panel29.BackColor = Color.Red; }
                else if (listWeeks[3].g4 == 1) { panel29.BackColor = Color.Orange; avg4 = avg4 + 1; }
                else if (listWeeks[3].g4 == 2) { panel29.BackColor = Color.Yellow; avg4 = avg4 + 2; }
                else if (listWeeks[3].g4 == 3) { panel29.BackColor = Color.Lime; avg4 = avg4 + 3; }
                else { panel29.BackColor = Color.Cyan; avg4 = avg4 + 4; }
                if (listWeeks[3].g5 == 0) { panel37.BackColor = Color.Red; }
                else if (listWeeks[3].g5 == 1) { panel37.BackColor = Color.Orange; avg5 = avg5 + 1; }
                else if (listWeeks[3].g5 == 2) { panel37.BackColor = Color.Yellow; avg5 = avg5 + 2; }
                else if (listWeeks[3].g5 == 3) { panel37.BackColor = Color.Lime; avg5 = avg5 + 3; }
                else { panel37.BackColor = Color.Cyan; avg5 = avg5 + 4; }
                if (listWeeks[3].g6 == 0) { panel45.BackColor = Color.Red; }
                else if (listWeeks[3].g6 == 1) { panel45.BackColor = Color.Orange; avg6 = avg6 + 1; }
                else if (listWeeks[3].g6 == 2) { panel45.BackColor = Color.Yellow; avg6 = avg6 + 2; }
                else if (listWeeks[3].g6 == 3) { panel45.BackColor = Color.Lime; avg6 = avg6 + 3; }
                else { panel45.BackColor = Color.Cyan; avg6 = avg6 + 4; }

                //colour in recap box
                if (listWeeks[3].weekrating == 0) { textBox4.BackColor = Color.Red; }
                else if (listWeeks[3].weekrating == 1) { textBox4.BackColor = Color.Orange; }
                else if (listWeeks[3].weekrating == 2) { textBox4.BackColor = Color.Yellow; }
                else if (listWeeks[3].weekrating == 3) { textBox4.BackColor = Color.Lime; }
                else { textBox4.BackColor = Color.Cyan; }
            }


            //ok here we have filled in all the text boxes and coloured them, plus coloured the miniboxes
            //now colour the averages
            colourAvgs();

            //now all the main stuff is filled in, gota get last months plan for this month, the plan for next month and this month recap

            foreach(var m in listMonths)
            {
                if(m.date.Month == fullDateTime.Month - 1 && m.type == "month")
                {
                    textBox5.Text = m.plan;
                }
                if (m.date.Month == fullDateTime.Month && m.type == "month")
                {
                    textBox6.Text = m.recap;
                    textBox7.Text = m.plan;
                    if(m.weekrating == 0) { textBox6.BackColor = Color.Red; }
                    else if(m.weekrating == 1) { textBox6.BackColor = Color.Orange; }
                    else if(m.weekrating == 2) { textBox6.BackColor = Color.Yellow; }
                    else if(m.weekrating ==3) { textBox6.BackColor = Color.Lime; }
                    else { textBox6.BackColor = Color.Cyan; }
                }
            }

            //aight should have everything filled in now

        }

        public void colourAvgs()
        {

            int t1 = avg1 / 4; //8
            int a1 = avg2 / 4; //9
            int b1 = avg3 / 4; //17
            int c1 = avg4 / 4; //25
            int d1 = avg5 / 4; //33
            int e1 = avg6 / 4; //41

            //got range 0 - 4

            if (t1 == 0) { panel10.BackColor = Color.Red; }
            else if (t1 == 1) { panel10.BackColor = Color.Orange; }
            else if (t1 == 2) { panel10.BackColor = Color.Yellow; }
            else if (t1 == 3) { panel10.BackColor = Color.Lime; }
            else { panel10.BackColor = Color.Cyan; }

            if (a1 == 0) { panel9.BackColor = Color.Red; }
            else if (a1 == 1) { panel9.BackColor = Color.Orange; }
            else if (a1 == 2) { panel9.BackColor = Color.Yellow; }
            else if (a1 == 3) { panel9.BackColor = Color.Lime; }
            else { panel9.BackColor = Color.Cyan; }

            if (b1 == 0) { panel8.BackColor = Color.Red; }
            else if (b1 == 1) { panel8.BackColor = Color.Orange; }
            else if (b1 == 2) { panel8.BackColor = Color.Yellow; }
            else if (b1 == 3) { panel8.BackColor = Color.Lime; }
            else { panel8.BackColor = Color.Cyan; }

            if (c1 == 0) { panel7.BackColor = Color.Red; }
            else if (c1 == 1) { panel7.BackColor = Color.Orange; }
            else if (c1 == 2) { panel7.BackColor = Color.Yellow; }
            else if (c1 == 3) { panel7.BackColor = Color.Lime; }
            else { panel7.BackColor = Color.Cyan; }

            if (d1 == 0) { panel6.BackColor = Color.Red; }
            else if (d1 == 1) { panel6.BackColor = Color.Orange; }
            else if (d1 == 2) { panel6.BackColor = Color.Yellow; }
            else if (d1 == 3) { panel6.BackColor = Color.Lime; }
            else { panel6.BackColor = Color.Cyan; }

            if (e1 == 0) { panel5.BackColor = Color.Red; }
            else if (e1 == 1) { panel5.BackColor = Color.Orange; }
            else if (e1 == 2) { panel5.BackColor = Color.Yellow; }
            else if (e1 == 3) { panel5.BackColor = Color.Lime; }
            else { panel5.BackColor = Color.Cyan; }

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<weMoRePlan> listWeek = new List<weMoRePlan>();
            //grab all the data from xml
            XmlSerializer serializer2 = new XmlSerializer(typeof(List<weMoRePlan>));
            using (FileStream fileStream = new FileStream("allWeekMonths.xml", FileMode.Open))
            {
                listWeek = (List<weMoRePlan>)serializer2.Deserialize(fileStream);
                fileStream.Close();
            }

            //we got the data, create new weMoRePlan then add to list then serialise list

            weMoRePlan add = new weMoRePlan();
            int monthavg = (avg1 + avg2 + avg3 + avg4 + avg5 + avg6) / 6;
            add.fillweMo(textBox6.Text, textBox7.Text, avg1 / 4, avg2 / 4, avg3 / 4, avg4 / 4, avg5 / 4, avg6 / 4, monthavg, "month");
            add.date = dateHolder;

            listWeek.Add(add);

            XmlSerializer serializer = new XmlSerializer(typeof(List<dayOverview>));
            using (FileStream fileStream = new FileStream("allWeekMonths.xml", FileMode.Create))
            {
                serializer2.Serialize(fileStream, listWeek);
                fileStream.Close();
            }

            textBox6.Text = "Recorded";
            textBox7.Text = "Recorded";

        }
    }

    
    
}
