using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace joPlana
{
    //ok so this is day, i want day to hold 
    [Serializable()]
    public class dayOverview
    {

        DateTime date;
        public string recap = "";
        public string plan = "";
        int g1;
        int g2;
        int g3;
        int g4;
        int g5;

        public void fillDay(string recapIN, string planIN, int g1IN, int g2IN, int g3IN, int g4IN, int g5IN)
        {
            date = DateTime.Now;
            recap = recapIN;
            plan = planIN;
            g1 = g1IN;
            g2 = g2IN;
            g3 = g3IN;
            g4 = g4IN;
            g5 = g5IN;        
        }
        

        public void PooPants()
        {
            
        }

    }

    
}
