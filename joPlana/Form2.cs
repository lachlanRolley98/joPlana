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
            }
        }



        //https://www.vbforums.com/showthread.php?779279-Draw-Red-Rectangle-on-Windows-Form
    }
}
