using Challenge2_Claims_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Claims_REPO
{
    public class ClaimsRepo
    {
        Queue<int> _claimQueue = new Queue<int>();
        private readonly List<Claims> _claims = new List<Claims>();

        //CREATE

        public bool AddClaimToList(Claims claim)
        {
            int sizeOfListBefore = _claims.Count();
            _claims.Add(claim);
            int sizeOfListAfter = _claims.Count();
            if(sizeOfListAfter > sizeOfListBefore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddClaimToQueue(Claims claim)
        {
            int sizeOfQueueBefore = _claimQueue.Count();
            _claimQueue.Enqueue(claim.ClaimID);
            int sizeOfQueueAfter = _claimQueue.Count();
            if(sizeOfQueueAfter > sizeOfQueueBefore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Read
        public List<Claims> GetClaimsInQueue() 
        {
            List<Claims> claimList = new List<Claims>();

            int[] qArray = _claimQueue.ToArray();
            for (int idx = 0; idx < qArray.Length; idx++)
            {
                claimList.Add(_claims.Find(claim => claim.ClaimID == qArray[idx]));
            }
            
            return claimList;
            

        }


    }
}
