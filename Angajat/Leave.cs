using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Clasa Leave: reprezinta un istoric al concediilor.

namespace Angajat
{
    public class Leave
    {
        public DateTime startingDate;
        public int duration;
        public string employee;
        
        public LeaveType vacation ;
        public Leave(DateTime startingDate,int duration, LeaveType vacation)
        {
            this.startingDate = startingDate;
            this.duration = duration;
            this.vacation = vacation;
        }//Constructor in care trimteti campurile: startingDate, duration, leaveType
    }
}
