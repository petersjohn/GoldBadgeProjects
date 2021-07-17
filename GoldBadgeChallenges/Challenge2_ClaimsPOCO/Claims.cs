using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Claims_POCO
{
    public class Claims
    {
        public Claims() { }

        public Claims(int claimID, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime dateOfAccident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
            
        }

        public int ClaimID { get; set; }//revisit this
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }

        public decimal ClaimAmount { get; set; }
        public DateTime DateOfAccident { get; set; }

        public DateTime DateOfClaim { get; set; }

        public bool IsValid
        {
            get
            {
                int daysSinceIncident = (DateOfClaim.Date - DateOfAccident.Date).Days;
                if(daysSinceIncident > 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }



        
    }
    public enum ClaimType
    {
        Car,
        Home,
        Theft
    }
}
