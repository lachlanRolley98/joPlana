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

        public DateTime date;
        public string recap = "";
        public string plan = "";
        public int g1;
        public int g2;
        public int g3;
        public int g4;
        public int g5;
        public int g6;
        public int dayRating;

        public void fillDay(string recapIN, string planIN, int g1IN, int g2IN, int g3IN, int g4IN, int g5IN, int g6IN, int g7IN)
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
            dayRating = g7IN;  
        }
        

        public void PooPants()
        {
            
        }

    }

    
}
