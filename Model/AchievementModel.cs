using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class AchievementModel
    {
        public int AchievementID { get; set; }
        public Nullable<int> MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> AwardId { get; set; }
        public string AwardName { get; set; }
        public Nullable<System.DateTime> AchieveDate { get; set; }
    }
}
