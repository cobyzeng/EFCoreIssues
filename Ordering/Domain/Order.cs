using System;
using System.Collections.Generic;

namespace Ordering.Domain
{
    public class Order : Entity
    {
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        private readonly List<Job> _jobs;
        public IReadOnlyCollection<Job> Jobs => _jobs;

        public Order()
        {
            _jobs = new List<Job>();
        }

        public void AddJob(Job job)
        {
            var actionValidationResult = CanAddJob();
            if (!actionValidationResult)
            {
                throw new Exception("Some Reason");
            }

            _jobs.Add(job);
        }

        public bool CanAddJob()
        {
            return true;
        }
    }
}
