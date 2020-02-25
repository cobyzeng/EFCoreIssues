using System;
using System.Collections.Generic;
using System.Linq;
using Ordering.SeedWork;

namespace Ordering.Domain
{
    public class JobStatus : Enumeration
    {
        public static readonly JobStatus Unassigned =
            new JobStatus(1, nameof(Unassigned).ToLowerInvariant(), "Unassigned");

        public static readonly JobStatus Assigned = new JobStatus(2, nameof(Assigned).ToLowerInvariant(), "Assigned");

        public static readonly JobStatus
            Completed = new JobStatus(3, nameof(Completed).ToLowerInvariant(), "Completed");

        public static readonly JobStatus Draft = new JobStatus(4, nameof(Draft).ToLowerInvariant(), "Draft");

        public string DisplayName { get; private set; }

        public JobStatus()
        {
        }

        public JobStatus(int id, string name, string displayName) : base(id, name)
        {
            DisplayName = displayName;
        }

        public static IEnumerable<JobStatus> List() => new[]
        {
            Unassigned,
            Assigned,
            Completed,
            Draft
        };

        public static JobStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
            if (state == null)
                throw new InvalidOperationException(
                    $"Possible values for {typeof(JobStatus).Name}: {string.Join(",", List().Select(s => s.Name))}");
            return state;
        }

        public static JobStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
            if (state == null)
                throw new InvalidOperationException(
                    $"Possible values for {typeof(JobStatus).Name}: {string.Join(",", List().Select(s => s.Name))}");
            return state;
        }
    }
}
