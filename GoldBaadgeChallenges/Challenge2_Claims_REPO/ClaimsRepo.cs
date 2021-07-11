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
        
        public List<Claims> ReturnAllClaims()
        {
            return _claims;
        }

        public Queue<int> ReturnQueue()
        {
            return _claimQueue;
        }

        //Delete
        public int RemoveFromQueue()
        {
            int sizeBefore = _claimQueue.Count();
            int removedItem = _claimQueue.Dequeue();
            int sizeAfter = _claimQueue.Count();

            if((sizeAfter > sizeBefore) && (removedItem > 0))
            {
                return removedItem;
            }
            return 0;
        }

        public bool RemoveFromList(int listItem)
        {
            int sizeBefore = _claims.Count();
            foreach (var claim in _claims)
            {
                if(claim.ClaimID == listItem)
                {
                    _claims.Remove(claim);
                }
            }
            int sizeAfter = _claims.Count();
            if(sizeAfter < sizeBefore)
            {
                return true;
            }
            return false;
        }


    }
}
