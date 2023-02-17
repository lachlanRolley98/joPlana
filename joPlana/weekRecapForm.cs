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
using System.Globalization;

namespace joPlana
{
    public partial class weekRecapForm : Form
    {

        int avg1;
        int avg2;
        int avg3;
        int avg4;
        int avg5;
        int avg6;
        DateTime startDate;

        
        public weekRecapForm()
        {
            InitializeComponent();
        }

        

        private void weekRecapForm_Load(object sender, EventArgs e)
        {
            
        }
        //ok in this setup, we get given a day selected from form1
        //open all the days in xml and save every day that has the same week and year
        //can then use this new list to fill in each week textbox or say nothing recorded
        //also grab the week recap if it is avaliable    ( Same XML    )
        //also grab last week plan from that same xml    ( Same XML    )   NOTE CHECK IF FILE EXISTS AND IF NOT CREATE IT FISRT - ALSO IMPLIMENT THIS IN FORM 1
        public void setup(object sender, EventArgs e, DateTime fullDateTime)
        {
            if(fullDateTime.DayOfWeek != DayOfWeek.Monday)
            {
                textBox16.Text = "MUST SELECT THE MONDAY YOU WANT YOUR WEEK TO START WITH";
                return;
            }
            
            startDate = fullDateTime;
            List<dayOverview> list = new List<dayOverview>();
            

            //grab all the data from xml, note use of file.Open instead of create
            XmlSerializer serializer = new XmlSerializer(typeof(List<dayOverview>));
            using (FileStream fileStream = new FileStream("allDays.xml", FileMode.Open))
            {
                list = (List<dayOverview>)serializer.Deserialize(fileStream);
                fileStream.Close();
            }
            //ok here we have all the days in list
            //loop through the list and add that day to daysInWeek

            //To find out the days in the week the user must click on a monday on the calender.
            //we can then simply check if the day in the list is the same month, year
            //we also gota use Days in month to see how many days in month and see if we are gona go over then month  // int daysindec = DateTime.DaysInMonth(2008, 12);
            //if monday + 7 is greater than days in month, use remander in month+1
            //so maybe set a bool overflow and get the extra days in next month in another loop

            //figure out how many days are in the selected month
            int daysinMonth = DateTime.DaysInMonth(fullDateTime.Year, fullDateTime.Month);
            bool overflow = false;
            int overflowSize = 0;
            if(fullDateTime.Day + 6 > daysinMonth)
            { 
                overflow = true;
                overflowSize = fullDateTime.Day + 6 - daysinMonth;
            }

            //loop through days and put is info in the form
            foreach (var m in list)
            {
                //this finds all the days within a 7 day span of the monday we selected in form 1. If doesnt however grab days that overflow into the next month
                if(m.date.Month == fullDateTime.Month && m.date.Year == fullDateTime.Year && m.date.Day <= fullDateTime.Day+6 && m.date.Day >= fullDateTime.Day)
                {
                    putDayInForm(m, fullDateTime, overflow);
                }
                //also grab days in next month// TBH ALSO GOTA CHECK IF FLOWING OVER TO DIFF YEAR BUT CAN ADD THAT LATER
                if (overflow && m.date.Month == fullDateTime.Month + 1 && m.date.Year == fullDateTime.Year && m.date.Day <= overflowSize)
                {
                    putDayInForm(m, fullDateTime, overflow);
                }
            }

            //at this point we will have inserted all the days data in the list.
            //some days will be empty as we did not record them, they will just be blank

            //fill in the averages
            colourAvgs();


            //everything is filled besides last weeks plan and current recap
            //this is where we fill all that in if its old, To actually write the review, we gota click the button
            List<weMoRePlan> listWeek = new List<weMoRePlan>();
            //grab all the data from xml
            XmlSerializer serializer2 = new XmlSerializer(typeof(List<weMoRePlan>));
            using (FileStream fileStream = new FileStream("allWeekMonths.xml", FileMode.Open))
            {
                listWeek = (List<weMoRePlan>)serializer2.Deserialize(fileStream);
                fileStream.Close();
            }
            //ok here we have weMo in a list
            //check if there is a plan for next week
            
            foreach(var m in listWeek)
            {
                //the review and next week plan will have the same date as the selected day of the week
                //the plan for the current week we are looking for will be 7 days earler so gota look back then
                
                
                //find current recap if exists and chuck in
                if(fullDateTime.DayOfYear == m.date.DayOfYear && m.type == "week")
                {
                    //cool we got a recap, chuck it in
                    textBox16.Text = m.recap;
                    if (m.weekrating == 0) { textBox16.BackColor = Color.Red; }
                    else if (m.weekrating == 1) { textBox16.BackColor = Color.Orange;}
                    else if (m.weekrating == 2) { textBox16.BackColor = Color.Yellow;}
                    else if (m.weekrating == 3) { textBox16.BackColor = Color.Lime;}
                    else { textBox16.BackColor = Color.Cyan;}
                }
                //find current plan for next week
                if (fullDateTime.DayOfYear == m.date.DayOfYear && m.type == "week")
                {
                    //cool we got a plan, chuck it in
                    textBox17.Text = m.plan;                 
                }
                //find last week plan
                if (fullDateTime.DayOfYear - 7 == m.date.DayOfYear && m.type == "week")
                {
                    //cool we got a plan, chuck it in
                    textBox15.Text = m.plan;
                }
            }
            

        }

        public void putDayInForm(dayOverview day, DateTime fullDateTime, bool overflow)
        {
            //here we should be given a day in the selected week. 
            //use .dayofyear +1 +2 +3....
            

                //Monday
                if (day.date.DayOfYear == fullDateTime.DayOfYear)
                {
                    textBox1.Text = day.recap;
                    textBox14.Text = day.dream;
                    //colour in goals boxes
                    if (day.g1 == 0) { panel1.BackColor = Color.Red; }
                    else if (day.g1 == 1) { panel1.BackColor = Color.Orange; avg1 = avg1 + 1; }
                    else if (day.g1 == 2) { panel1.BackColor = Color.Yellow; avg1 = avg1 + 2; }
                    else if (day.g1 == 3) { panel1.BackColor = Color.Lime; avg1 = avg1 + 3; }
                    else { panel1.BackColor = Color.Cyan; avg1 = avg1 + 4; }
                    if (day.g2 == 0) { panel16.BackColor = Color.Red; }
                    else if (day.g2 == 1) { panel16.BackColor = Color.Orange; avg2 = avg2 + 1; }
                    else if (day.g2 == 2) { panel16.BackColor = Color.Yellow; avg2 = avg2 + 2; }
                    else if (day.g2 == 3) { panel16.BackColor = Color.Lime; avg2 = avg2 + 3; }
                    else { panel16.BackColor = Color.Cyan; avg2 = avg2 + 4; }
                    if (day.g3 == 0) { panel24.BackColor = Color.Red; }
                    else if (day.g3 == 1) { panel24.BackColor = Color.Orange; avg3 = avg3 + 1; }
                    else if (day.g3 == 2) { panel24.BackColor = Color.Yellow; avg3 = avg3 + 2; }
                    else if (day.g3 == 3) { panel24.BackColor = Color.Lime; avg3 = avg3 + 3; }
                    else { panel24.BackColor = Color.Cyan; avg3 = avg3 + 4; }
                    if (day.g4 == 0) { panel32.BackColor = Color.Red; }
                    else if (day.g4 == 1) { panel32.BackColor = Color.Orange; avg4 = avg4 + 1; }
                    else if (day.g4 == 2) { panel32.BackColor = Color.Yellow; avg4 = avg4 + 2; }
                    else if (day.g4 == 3) { panel32.BackColor = Color.Lime; avg4 = avg4 + 3; }
                    else { panel32.BackColor = Color.Cyan; avg4 = avg4 + 4; }
                    if (day.g5 == 0) { panel40.BackColor = Color.Red; }
                    else if (day.g5 == 1) { panel40.BackColor = Color.Orange; avg5 = avg5 + 1; }
                    else if (day.g5 == 2) { panel40.BackColor = Color.Yellow; avg5 = avg5 + 2; }
                    else if (day.g5 == 3) { panel40.BackColor = Color.Lime; avg5 = avg5 + 3; }
                    else { panel40.BackColor = Color.Cyan; avg5 = avg5 + 4; }
                    if (day.g6 == 0) { panel48.BackColor = Color.Red; }
                    else if (day.g6 == 1) { panel48.BackColor = Color.Orange; avg6 = avg6 + 1; }
                    else if (day.g6 == 2) { panel48.BackColor = Color.Yellow; avg6 = avg6 + 2; }
                    else if (day.g6 == 3) { panel48.BackColor = Color.Lime; avg6 = avg6 + 3; }
                    else { panel48.BackColor = Color.Cyan; avg6 = avg6 + 4; }

                    //colour in recap box
                    if (day.dayRating == 0) { textBox1.BackColor = Color.Red; }
                    else if (day.dayRating == 1) { textBox1.BackColor = Color.Orange;}
                    else if (day.dayRating == 2) { textBox1.BackColor = Color.Yellow;}
                    else if (day.dayRating == 3) { textBox1.BackColor = Color.Lime;}
                    else { textBox1.BackColor = Color.Cyan; }
            }
                //Tuesday
                if (day.date.DayOfYear  == fullDateTime.DayOfYear + 1)
                {
                    textBox2.Text = day.recap;
                    textBox13.Text = day.dream;
                    if (day.g1 == 0) { panel2.BackColor = Color.Red; }
                    else if (day.g1 == 1) { panel2.BackColor = Color.Orange; avg1 = avg1 + 1; }
                    else if (day.g1 == 2) { panel2.BackColor = Color.Yellow; avg1 = avg1 + 2; }
                    else if (day.g1 == 3) { panel2.BackColor = Color.Lime; avg1 = avg1 + 3; }
                    else { panel2.BackColor = Color.Cyan; avg1 = avg1 + 4; }
                    if (day.g2 == 0) { panel15.BackColor = Color.Red; }
                    else if (day.g2 == 1) { panel15.BackColor = Color.Orange; avg2 = avg2 + 1; }
                    else if (day.g2 == 2) { panel15.BackColor = Color.Yellow; avg2 = avg2 + 2; }
                    else if (day.g2 == 3) { panel15.BackColor = Color.Lime; avg2 = avg2 + 3; }
                    else { panel15.BackColor = Color.Cyan; avg2 = avg2 + 4; }
                    if (day.g3 == 0) { panel23.BackColor = Color.Red; }
                    else if (day.g3 == 1) { panel23.BackColor = Color.Orange; avg3 = avg3 + 1; }
                    else if (day.g3 == 2) { panel23.BackColor = Color.Yellow; avg3 = avg3 + 2; }
                    else if (day.g3 == 3) { panel23.BackColor = Color.Lime; avg3 = avg3 + 3; }
                    else { panel23.BackColor = Color.Cyan; avg3 = avg3 + 4; }
                    if (day.g4 == 0) { panel31.BackColor = Color.Red; }
                    else if (day.g4 == 1) { panel31.BackColor = Color.Orange; avg4 = avg4 + 1; }
                    else if (day.g4 == 2) { panel31.BackColor = Color.Yellow; avg4 = avg4 + 2; }
                    else if (day.g4 == 3) { panel31.BackColor = Color.Lime; avg4 = avg4 + 3; }
                    else { panel31.BackColor = Color.Cyan; avg4 = avg4 + 4; }
                    if (day.g5 == 0) { panel39.BackColor = Color.Red; }
                    else if (day.g5 == 1) { panel39.BackColor = Color.Orange; avg5 = avg5 + 1; }
                    else if (day.g5 == 2) { panel39.BackColor = Color.Yellow; avg5 = avg5 + 2; }
                    else if (day.g5 == 3) { panel39.BackColor = Color.Lime; avg5 = avg5 + 3; }
                    else { panel39.BackColor = Color.Cyan; avg5 = avg5 + 4; }
                    if (day.g6 == 0) { panel47.BackColor = Color.Red; }
                    else if (day.g6 == 1) { panel47.BackColor = Color.Orange; avg6 = avg6 + 1; }
                    else if (day.g6 == 2) { panel47.BackColor = Color.Yellow; avg6 = avg6 + 2; }
                    else if (day.g6 == 3) { panel47.BackColor = Color.Lime; avg6 = avg6 + 3; }
                    else { panel47.BackColor = Color.Cyan; avg6 = avg6 + 4; }

                    //colour in recap box
                    if (day.dayRating == 0) { textBox2.BackColor = Color.Red; }
                    else if (day.dayRating == 1) { textBox2.BackColor = Color.Orange;}
                    else if (day.dayRating == 2) { textBox2.BackColor = Color.Yellow;}
                    else if (day.dayRating == 3) { textBox2.BackColor = Color.Lime;}
                    else { textBox2.BackColor = Color.Cyan;}
            }
                //Wednesday
                if (day.date.DayOfYear  == fullDateTime.DayOfYear + 2)
                {
                    textBox3.Text = day.recap;
                    textBox12.Text = day.dream;
                    if (day.g1 == 0) { panel3.BackColor = Color.Red; }
                    else if (day.g1 == 1) { panel3.BackColor = Color.Orange; avg1 = avg1 + 1; }
                    else if (day.g1 == 2) { panel3.BackColor = Color.Yellow; avg1 = avg1 + 2; }
                    else if (day.g1 == 3) { panel3.BackColor = Color.Lime; avg1 = avg1 + 3; }
                    else { panel3.BackColor = Color.Cyan; avg1 = avg1 + 4; }
                    if (day.g2 == 0) { panel14.BackColor = Color.Red; }
                    else if (day.g2 == 1) { panel14.BackColor = Color.Orange; avg2 = avg2 + 1; }
                    else if (day.g2 == 2) { panel14.BackColor = Color.Yellow; avg2 = avg2 + 2; }
                    else if (day.g2 == 3) { panel14.BackColor = Color.Lime; avg2 = avg2 + 3; }
                    else { panel14.BackColor = Color.Cyan; avg2 = avg2 + 4; }
                    if (day.g3 == 0) { panel22.BackColor = Color.Red; }
                    else if (day.g3 == 1) { panel22.BackColor = Color.Orange; avg3 = avg3 + 1; }
                    else if (day.g3 == 2) { panel22.BackColor = Color.Yellow; avg3 = avg3 + 2; }
                    else if (day.g3 == 3) { panel22.BackColor = Color.Lime; avg3 = avg3 + 3; }
                    else { panel22.BackColor = Color.Cyan; avg3 = avg3 + 4; }
                    if (day.g4 == 0) { panel30.BackColor = Color.Red; }
                    else if (day.g4 == 1) { panel30.BackColor = Color.Orange; avg4 = avg4 + 1; }
                    else if (day.g4 == 2) { panel30.BackColor = Color.Yellow; avg4 = avg4 + 2; }
                    else if (day.g4 == 3) { panel30.BackColor = Color.Lime; avg4 = avg4 + 3; }
                    else { panel30.BackColor = Color.Cyan; avg4 = avg4 + 4; }
                    if (day.g5 == 0) { panel38.BackColor = Color.Red; }
                    else if (day.g5 == 1) { panel38.BackColor = Color.Orange; avg5 = avg5 + 1; }
                    else if (day.g5 == 2) { panel38.BackColor = Color.Yellow; avg5 = avg5 + 2; }
                    else if (day.g5 == 3) { panel38.BackColor = Color.Lime; avg5 = avg5 + 3; }
                    else { panel38.BackColor = Color.Cyan; avg5 = avg5 + 4; }
                    if (day.g6 == 0) { panel46.BackColor = Color.Red; }
                    else if (day.g6 == 1) { panel46.BackColor = Color.Orange; avg6 = avg6 + 1; }
                    else if (day.g6 == 2) { panel46.BackColor = Color.Yellow; avg6 = avg6 + 2; }
                    else if (day.g6 == 3) { panel46.BackColor = Color.Lime; avg6 = avg6 + 3; }
                    else { panel46.BackColor = Color.Cyan; avg6 = avg6 + 4; }

                    //colour in recap box
                    if (day.dayRating == 0) { textBox3.BackColor = Color.Red; }
                    else if (day.dayRating == 1) { textBox3.BackColor = Color.Orange;}
                    else if (day.dayRating == 2) { textBox3.BackColor = Color.Yellow;}
                    else if (day.dayRating == 3) { textBox3.BackColor = Color.Lime;}
                    else { textBox3.BackColor = Color.Cyan; }
            }
                //Thursday
                if (day.date.DayOfYear  == fullDateTime.DayOfYear + 3)
                {
                    textBox4.Text = day.recap;
                    textBox11.Text = day.dream;
                    if (day.g1 == 0) { panel4.BackColor = Color.Red; }
                    else if (day.g1 == 1) { panel4.BackColor = Color.Orange; avg1 = avg1 + 1; }
                    else if (day.g1 == 2) { panel4.BackColor = Color.Yellow; avg1 = avg1 + 2; }
                    else if (day.g1 == 3) { panel4.BackColor = Color.Lime; avg1 = avg1 + 3; }
                    else { panel4.BackColor = Color.Cyan; avg1 = avg1 + 4; }
                    if (day.g2 == 0) { panel13.BackColor = Color.Red; }
                    else if (day.g2 == 1) { panel13.BackColor = Color.Orange; avg2 = avg2 + 1; }
                    else if (day.g2 == 2) { panel13.BackColor = Color.Yellow; avg2 = avg2 + 2; }
                    else if (day.g2 == 3) { panel13.BackColor = Color.Lime; avg2 = avg2 + 3; }
                    else { panel13.BackColor = Color.Cyan; avg2 = avg2 + 4; }
                    if (day.g3 == 0) { panel21.BackColor = Color.Red; }
                    else if (day.g3 == 1) { panel21.BackColor = Color.Orange; avg3 = avg3 + 1; }
                    else if (day.g3 == 2) { panel21.BackColor = Color.Yellow; avg3 = avg3 + 2; }
                    else if (day.g3 == 3) { panel21.BackColor = Color.Lime; avg3 = avg3 + 3; }
                    else { panel21.BackColor = Color.Cyan; avg3 = avg3 + 4; }
                    if (day.g4 == 0) { panel29.BackColor = Color.Red; }
                    else if (day.g4 == 1) { panel29.BackColor = Color.Orange; avg4 = avg4 + 1; }
                    else if (day.g4 == 2) { panel29.BackColor = Color.Yellow; avg4 = avg4 + 2; }
                    else if (day.g4 == 3) { panel29.BackColor = Color.Lime; avg4 = avg4 + 3; }
                    else { panel29.BackColor = Color.Cyan; avg4 = avg4 + 4; }
                    if (day.g5 == 0) { panel37.BackColor = Color.Red; }
                    else if (day.g5 == 1) { panel37.BackColor = Color.Orange; avg5 = avg5 + 1; }
                    else if (day.g5 == 2) { panel37.BackColor = Color.Yellow; avg5 = avg5 + 2; }
                    else if (day.g5 == 3) { panel37.BackColor = Color.Lime; avg5 = avg5 + 3; }
                    else { panel37.BackColor = Color.Cyan; avg5 = avg5 + 4; }
                    if (day.g6 == 0) { panel45.BackColor = Color.Red; }
                    else if (day.g6 == 1) { panel45.BackColor = Color.Orange; avg6 = avg6 + 1; }
                    else if (day.g6 == 2) { panel45.BackColor = Color.Yellow; avg6 = avg6 + 2; }
                    else if (day.g6 == 3) { panel45.BackColor = Color.Lime; avg6 = avg6 + 3; }
                    else { panel45.BackColor = Color.Cyan; avg6 = avg6 + 4; }

                    //colour in recap box
                    if (day.dayRating == 0) { textBox4.BackColor = Color.Red; }
                    else if (day.dayRating == 1) { textBox4.BackColor = Color.Orange;}
                    else if (day.dayRating == 2) { textBox4.BackColor = Color.Yellow;}
                    else if (day.dayRating == 3) { textBox4.BackColor = Color.Lime;}
                    else { textBox4.BackColor = Color.Cyan;}
            }
                //Friday
                if (day.date.DayOfYear == fullDateTime.DayOfYear + 4)
            {
                    textBox5.Text = day.recap;
                    textBox10.Text = day.dream;
                    if (day.g1 == 0) { panel5.BackColor = Color.Red; }
                    else if (day.g1 == 1) { panel5.BackColor = Color.Orange; avg1 = avg1 + 1; }
                    else if (day.g1 == 2) { panel5.BackColor = Color.Yellow; avg1 = avg1 + 2; }
                    else if (day.g1 == 3) { panel5.BackColor = Color.Lime; avg1 = avg1 + 3; }
                    else { panel5.BackColor = Color.Cyan; avg1 = avg1 + 4; }
                    if (day.g2 == 0) { panel12.BackColor = Color.Red; }
                    else if (day.g2 == 1) { panel12.BackColor = Color.Orange; avg2 = avg2 + 1; }
                    else if (day.g2 == 2) { panel12.BackColor = Color.Yellow; avg2 = avg2 + 2; }
                    else if (day.g2 == 3) { panel12.BackColor = Color.Lime; avg2 = avg2 + 3; }
                    else { panel12.BackColor = Color.Cyan; avg2 = avg2 + 4; }
                    if (day.g3 == 0) { panel20.BackColor = Color.Red; }
                    else if (day.g3 == 1) { panel20.BackColor = Color.Orange; avg3 = avg3 + 1; }
                    else if (day.g3 == 2) { panel20.BackColor = Color.Yellow; avg3 = avg3 + 2; }
                    else if (day.g3 == 3) { panel20.BackColor = Color.Lime; avg3 = avg3 + 3; }
                    else { panel20.BackColor = Color.Cyan; avg3 = avg3 + 4; }
                    if (day.g4 == 0) { panel28.BackColor = Color.Red; }
                    else if (day.g4 == 1) { panel28.BackColor = Color.Orange; avg4 = avg4 + 1; }
                    else if (day.g4 == 2) { panel28.BackColor = Color.Yellow; avg4 = avg4 + 2; }
                    else if (day.g4 == 3) { panel28.BackColor = Color.Lime; avg4 = avg4 + 3; }
                    else { panel28.BackColor = Color.Cyan; avg4 = avg4 + 4; }
                    if (day.g5 == 0) { panel36.BackColor = Color.Red; }
                    else if (day.g5 == 1) { panel36.BackColor = Color.Orange; avg5 = avg5 + 1; }
                    else if (day.g5 == 2) { panel36.BackColor = Color.Yellow; avg5 = avg5 + 2; }
                    else if (day.g5 == 3) { panel36.BackColor = Color.Lime; avg5 = avg5 + 3; }
                    else { panel36.BackColor = Color.Cyan; avg5 = avg5 + 4; }
                    if (day.g6 == 0) { panel44.BackColor = Color.Red; }
                    else if (day.g6 == 1) { panel44.BackColor = Color.Orange; avg6 = avg6 + 1; }
                    else if (day.g6 == 2) { panel44.BackColor = Color.Yellow; avg6 = avg6 + 2; }
                    else if (day.g6 == 3) { panel44.BackColor = Color.Lime; avg6 = avg6 + 3; }
                    else { panel44.BackColor = Color.Cyan; avg6 = avg6 + 4; }

                    //colour in recap box
                    if (day.dayRating == 0) { textBox5.BackColor = Color.Red; }
                    else if (day.dayRating == 1) { textBox5.BackColor = Color.Orange;}
                    else if (day.dayRating == 2) { textBox5.BackColor = Color.Yellow;}
                    else if (day.dayRating == 3) { textBox5.BackColor = Color.Lime;}
                    else { textBox5.BackColor = Color.Cyan;}
            }
                //Saturday
                if (day.date.DayOfYear == fullDateTime.DayOfYear + 5)
                {
                    textBox6.Text = day.recap;
                    textBox9.Text = day.dream;
                    if (day.g1 == 0) { panel6.BackColor = Color.Red; }
                    else if (day.g1 == 1) { panel6.BackColor = Color.Orange; avg1 = avg1 + 1; }
                    else if (day.g1 == 2) { panel6.BackColor = Color.Yellow; avg1 = avg1 + 2; }
                    else if (day.g1 == 3) { panel6.BackColor = Color.Lime; avg1 = avg1 + 3; }
                    else { panel6.BackColor = Color.Cyan; avg1 = avg1 + 4; }
                    if (day.g2 == 0) { panel11.BackColor = Color.Red; }
                    else if (day.g2 == 1) { panel11.BackColor = Color.Orange; avg2 = avg2 + 1; }
                    else if (day.g2 == 2) { panel11.BackColor = Color.Yellow; avg2 = avg2 + 2; }
                    else if (day.g2 == 3) { panel11.BackColor = Color.Lime; avg2 = avg2 + 3; }
                    else { panel11.BackColor = Color.Cyan; avg2 = avg2 + 4; }
                    if (day.g3 == 0) { panel19.BackColor = Color.Red; }
                    else if (day.g3 == 1) { panel19.BackColor = Color.Orange; avg3 = avg3 + 1; }
                    else if (day.g3 == 2) { panel19.BackColor = Color.Yellow; avg3 = avg3 + 2; }
                    else if (day.g3 == 3) { panel19.BackColor = Color.Lime; avg3 = avg3 + 3; }
                    else { panel19.BackColor = Color.Cyan; avg3 = avg3 + 4; }
                    if (day.g4 == 0) { panel27.BackColor = Color.Red; }
                    else if (day.g4 == 1) { panel27.BackColor = Color.Orange; avg4 = avg4 + 1; }
                    else if (day.g4 == 2) { panel27.BackColor = Color.Yellow; avg4 = avg4 + 2; }
                    else if (day.g4 == 3) { panel27.BackColor = Color.Lime; avg4 = avg4 + 3; }
                    else { panel27.BackColor = Color.Cyan; avg4 = avg4 + 4; }
                    if (day.g5 == 0) { panel35.BackColor = Color.Red; }
                    else if (day.g5 == 1) { panel35.BackColor = Color.Orange; avg5 = avg5 + 1; }
                    else if (day.g5 == 2) { panel35.BackColor = Color.Yellow; avg5 = avg5 + 2; }
                    else if (day.g5 == 3) { panel35.BackColor = Color.Lime; avg5 = avg5 + 3; }
                    else { panel35.BackColor = Color.Cyan; avg5 = avg5 + 4; }
                    if (day.g6 == 0) { panel43.BackColor = Color.Red; }
                    else if (day.g6 == 1) { panel43.BackColor = Color.Orange; avg6 = avg6 + 1; }
                    else if (day.g6 == 2) { panel43.BackColor = Color.Yellow; avg6 = avg6 + 2; }
                    else if (day.g6 == 3) { panel43.BackColor = Color.Lime; avg6 = avg6 + 3; }
                    else { panel43.BackColor = Color.Cyan; avg6 = avg6 + 4; }

                    //colour in recap box
                    if (day.dayRating == 0) { textBox6.BackColor = Color.Red; }
                    else if (day.dayRating == 1) { textBox6.BackColor = Color.Orange;}
                    else if (day.dayRating == 2) { textBox6.BackColor = Color.Yellow;}
                    else if (day.dayRating == 3) { textBox6.BackColor = Color.Lime;}
                    else { textBox6.BackColor = Color.Cyan;}
            }
                //Sunday
                if (day.date.DayOfYear== fullDateTime.DayOfYear + 6)
            {
                    textBox7.Text = day.recap;
                    textBox8.Text = day.dream;
                    if (day.g1 == 0) { panel7.BackColor = Color.Red; }
                    else if (day.g1 == 1) { panel7.BackColor = Color.Orange; avg1 = avg1 + 1; }
                    else if (day.g1 == 2) { panel7.BackColor = Color.Yellow; avg1 = avg1 + 2; }
                    else if (day.g1 == 3) { panel7.BackColor = Color.Lime; avg1 = avg1 + 3; }
                    else { panel7.BackColor = Color.Cyan; avg1 = avg1 + 4; }
                    if (day.g2 == 0) { panel10.BackColor = Color.Red; }
                    else if (day.g2 == 1) { panel10.BackColor = Color.Orange; avg2 = avg2 + 1; }
                    else if (day.g2 == 2) { panel10.BackColor = Color.Yellow; avg2 = avg2 + 2; }
                    else if (day.g2 == 3) { panel10.BackColor = Color.Lime; avg2 = avg2 + 3; }
                    else { panel10.BackColor = Color.Cyan; avg2 = avg2 + 4; }
                    if (day.g3 == 0) { panel18.BackColor = Color.Red; }
                    else if (day.g3 == 1) { panel18.BackColor = Color.Orange; avg3 = avg3 + 1; }
                    else if (day.g3 == 2) { panel18.BackColor = Color.Yellow; avg3 = avg3 + 2; }
                    else if (day.g3 == 3) { panel18.BackColor = Color.Lime; avg3 = avg3 + 3; }
                    else { panel18.BackColor = Color.Cyan; avg3 = avg3 + 4; }
                    if (day.g4 == 0) { panel26.BackColor = Color.Red; }
                    else if (day.g4 == 1) { panel26.BackColor = Color.Orange; avg4 = avg4 + 1; }
                    else if (day.g4 == 2) { panel26.BackColor = Color.Yellow; avg4 = avg4 + 2; }
                    else if (day.g4 == 3) { panel26.BackColor = Color.Lime; avg4 = avg4 + 3; }
                    else { panel26.BackColor = Color.Cyan; avg4 = avg4 + 4; }
                    if (day.g5 == 0) { panel34.BackColor = Color.Red; }
                    else if (day.g5 == 1) { panel34.BackColor = Color.Orange; avg5 = avg5 + 1; }
                    else if (day.g5 == 2) { panel34.BackColor = Color.Yellow; avg5 = avg5 + 2; }
                    else if (day.g5 == 3) { panel34.BackColor = Color.Lime; avg5 = avg5 + 3; }
                    else { panel34.BackColor = Color.Cyan; avg5 = avg5 + 4; }
                    if (day.g6 == 0) { panel42.BackColor = Color.Red; }
                    else if (day.g6 == 1) { panel42.BackColor = Color.Orange; avg6 = avg6 + 1; }
                    else if (day.g6 == 2) { panel42.BackColor = Color.Yellow; avg6 = avg6 + 2; }
                    else if (day.g6 == 3) { panel42.BackColor = Color.Lime; avg6 = avg6 + 3; }
                    else { panel42.BackColor = Color.Cyan; avg6 = avg6 + 4; }

                    //colour in recap box
                    if (day.dayRating == 0) { textBox7.BackColor = Color.Red; }
                    else if (day.dayRating == 1) { textBox7.BackColor = Color.Orange;}
                    else if (day.dayRating == 2) { textBox7.BackColor = Color.Yellow;}
                    else if (day.dayRating == 3) { textBox7.BackColor = Color.Lime;}
                    else { textBox7.BackColor = Color.Cyan;}
            }
            
        }


        public void colourAvgs()
        {

            int t1 = avg1 / 7; //8
            int a1 = avg2 / 7; //9
            int b1 = avg3 / 7; //17
            int c1 = avg4 / 7; //25
            int d1 = avg5 / 7; //33
            int e1 = avg6 / 7; //41

            //got range 0 - 4

            if (t1 == 0) { panel8.BackColor = Color.Red;}
            else if (t1 == 1) { panel8.BackColor = Color.Orange;}
            else if (t1 == 2) { panel8.BackColor = Color.Yellow;}
            else if (t1 == 3) { panel8.BackColor = Color.Lime;}
            else { panel8.BackColor = Color.Cyan;}

            if (a1 == 0) { panel9.BackColor = Color.Red; }
            else if (a1 == 1) { panel9.BackColor = Color.Orange; }
            else if (a1 == 2) { panel9.BackColor = Color.Yellow; }
            else if (a1 == 3) { panel9.BackColor = Color.Lime; }
            else { panel9.BackColor = Color.Cyan; }

            if (b1 == 0) { panel17.BackColor = Color.Red; }
            else if (b1 == 1) { panel17.BackColor = Color.Orange; }
            else if (b1 == 2) { panel17.BackColor = Color.Yellow; }
            else if (b1 == 3) { panel17.BackColor = Color.Lime; }
            else { panel17.BackColor = Color.Cyan; }

            if (c1 == 0) { panel25.BackColor = Color.Red; }
            else if (c1 == 1) { panel25.BackColor = Color.Orange; }
            else if (c1 == 2) { panel25.BackColor = Color.Yellow; }
            else if (c1 == 3) { panel25.BackColor = Color.Lime; }
            else { panel25.BackColor = Color.Cyan; }

            if (d1 == 0) { panel33.BackColor = Color.Red; }
            else if (d1 == 1) { panel33.BackColor = Color.Orange; }
            else if (d1 == 2) { panel33.BackColor = Color.Yellow; }
            else if (d1 == 3) { panel33.BackColor = Color.Lime; }
            else { panel33.BackColor = Color.Cyan; }

            if (e1 == 0) { panel41.BackColor = Color.Red; }
            else if (e1 == 1) { panel41.BackColor = Color.Orange; }
            else if (e1 == 2) { panel41.BackColor = Color.Yellow; }
            else if (e1 == 3) { panel41.BackColor = Color.Lime; }
            else { panel41.BackColor = Color.Cyan; }

        }

        
        //this is where we wana submit our recap and next week plan
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
            int weekavg = (avg1 + avg2 + avg3 + avg4 + avg5 + avg6) / 6;
            add.fillweMo(textBox16.Text, textBox17.Text, avg1 / 7, avg2 / 7, avg3 / 7, avg4 / 7, avg5 / 7, avg6 / 7, weekavg, "week");
            add.date = startDate;
            
            listWeek.Add(add);

            XmlSerializer serializer = new XmlSerializer(typeof(List<dayOverview>));
            using (FileStream fileStream = new FileStream("allWeekMonths.xml", FileMode.Create))
            {
                serializer2.Serialize(fileStream, listWeek);
                fileStream.Close();
            }

            textBox16.Text = "Recorded";
            textBox17.Text = "Recorded";


        }
    }
       
}
