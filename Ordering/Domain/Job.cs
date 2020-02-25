using System;

namespace Ordering.Domain
{
    public class Job : Entity
    {
        public int OrderId { get; private set; }
        public string JobNumber { get; private set; }
        public JobStatus JobStatus { get; private set; }
        private int _jobStatusId;

        public Job()
        {
            JobNumber = $"Job_{Guid.NewGuid()}";
            UpdateStatusTo(JobStatus.Draft);
        }

        private void UpdateStatusTo(JobStatus status)
        {
            _jobStatusId = status.Id;
            JobStatus = status;
        }
    }
}
