using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DonationModel
    {
        public int DonationID { get; set; }
        public int DonationTypeID { get; set; }
        public string DonationTypeName { get; set; }
        public Nullable<int> DonorID { get; set; }
        public string DonorName { get; set; }
        public Nullable<int> MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Remarks { get; set; }
        public string DonationFrom { get; set; }
        public string DonationDescription { get; set; }
    }
}
