using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joPlana
{
    [Serializable()]
    public class weMoRePlan
    {

        //ok game plan, we will make these each week and save in there own xml
        //has a date so alls swell
        //date will be a monday similar to the monday we search for 
        //if type is review, it will be the review of the week that starts on the monday
        //if its a plan it will be the monday of the week the plan is for
        
        public DateTime date;
        public string recap = " ";
        public string plan = " ";
        public int g1 = -1;
        public int g2 = -1;
        public int g3 = -1;
        public int g4 = -1;
        public int g5 = -1;
        public int g6 = -1;
        public int weekrating = -1;



        public void fillweMo(string recapIN, string planIN, int g1IN, int g2IN, int g3IN, int g4IN, int g5IN, int g6IN, int g7IN)
        {
            date = DateTime.Now;
            recap = recapIN;
            plan = planIN;
            g1 = g1IN;
            g2 = g2IN;
            g3 = g3IN;
            g4 = g4IN;
            g5 = g5IN;
            g6 = g6IN;
            weekrating = g7IN;
        }


    }
}
