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
        
        public readonly List<Claims> claimList = new List<Claims>();
        public Queue<int> _claimQueue = new Queue<int>();
        //CREATE

        public bool AddClaimToList(Claims claim)
        {
            int sizeOfListBefore = claimList.Count();
            claimList.Add(claim);
            int sizeOfListAfter = claimList.Count();
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
            if (sizeOfQueueAfter > sizeOfQueueBefore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Read

        public List<Claims> ReturnAllClaims()
        {
            return claimList;
        }

        public Queue<int> ReturnQueue()
        {
            return _claimQueue;
        }

        //Delete

        public bool RemoveClaimFromListByID(int listItem)
        {
            
            foreach (var claim in claimList)
            {
                if(claim.ClaimID == listItem)
                {
                    return DeleteClaim(claim);
                }
            }
            return false;
        }

        public bool DeleteClaim(Claims claim)
        {
            return claimList.Remove(claim);
        }

        public bool RemoveFromQueue()
        {
            int sizeBefore = _claimQueue.Count();
            _claimQueue.Dequeue();
            int sizeAfter = _claimQueue.Count();

            if (sizeAfter < sizeBefore)
            {
                return true;
            }
            return false;
        }

        public int CreateNewClaimID()
        {

            if(claimList.Count > 0)
            {
                var maxID = (claimList.Max(x => x.ClaimID)) + 1;//Thanks, Google!
                return maxID;
            }
            else
            {
                return 1;
            }
            


        }

    }
}
