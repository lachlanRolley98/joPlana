using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace joPlana
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            

            
        }
        public void fillForm2Recap(object sender, EventArgs e, List<dayOverview> apple)
        {
            
           
            if (apple.Count > 0)
            {
                textBox1.Text = apple[0].plan;
                textBox2.Text = apple[0].recap;
                textBox3.Text = apple[0].dream;
               
                if (apple[0].g1 == 0) { panel1.BackColor = Color.Red;}
                else if (apple[0].g1 == 1) { panel2.BackColor = Color.Orange;}
                else if (apple[0].g1 == 2) { panel3.BackColor = Color.Yellow;}
                else if (apple[0].g1 == 3) { panel4.BackColor = Color.Lime;}
                else { panel5.BackColor = Color.Cyan; }
                if (apple[0].g2 == 0) { panel6.BackColor = Color.Red; }
                else if (apple[0].g2 == 1) { panel7.BackColor = Color.Orange; }
                else if (apple[0].g2 == 2) { panel8.BackColor = Color.Yellow; }
                else if (apple[0].g2 == 3) { panel9.BackColor = Color.Lime; }
                else { panel10.BackColor = Color.Cyan; }
                if (apple[0].g3 == 0) { panel11.BackColor = Color.Red; }
                else if (apple[0].g3 == 1) { panel12.BackColor = Color.Orange; }
                else if (apple[0].g3 == 2) { panel13.BackColor = Color.Yellow; }
                else if (apple[0].g3 == 3) { panel14.BackColor = Color.Lime; }
                else { panel15.BackColor = Color.Cyan; }
                if (apple[0].g4 == 0) { panel16.BackColor = Color.Red; }
                else if (apple[0].g4 == 1) { panel17.BackColor = Color.Orange; }
                else if (apple[0].g4 == 2) { panel18.BackColor = Color.Yellow; }
                else if (apple[0].g4 == 3) { panel19.BackColor = Color.Lime; }
                else { panel20.BackColor = Color.Cyan; }
                if (apple[0].g5 == 0) { panel21.BackColor = Color.Red; }
                else if (apple[0].g5 == 1) { panel22.BackColor = Color.Orange; }
                else if (apple[0].g5 == 2) { panel23.BackColor = Color.Yellow; }
                else if (apple[0].g5 == 3) { panel24.BackColor = Color.Lime; }
                else { panel25.BackColor = Color.Cyan; }
                if (apple[0].g6 == 0) { panel26.BackColor = Color.Red; }
                else if (apple[0].g6 == 1) { panel27.BackColor = Color.Orange; }
                else if (apple[0].g6 == 2) { panel28.BackColor = Color.Yellow; }
                else if (apple[0].g6 == 3) { panel29.BackColor = Color.Lime; }
                else { panel30.BackColor = Color.Cyan; }
                if (apple[0].dayRating == 0) { panel31.BackColor = Color.Red; }
                else if (apple[0].dayRating == 1) { panel31.BackColor = Color.Orange; }
                else if (apple[0].dayRating == 2) { panel31.BackColor = Color.Yellow; }
                else if (apple[0].dayRating == 3) { panel31.BackColor = Color.Lime; }
                else { panel31.BackColor = Color.Cyan; }
            }
            else
            {
                textBox2.Text = "No Records";
            }
            //panel1.Hide();
            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        //https://www.vbforums.com/showthread.php?779279-Draw-Red-Rectangle-on-Windows-Form
    }
}
