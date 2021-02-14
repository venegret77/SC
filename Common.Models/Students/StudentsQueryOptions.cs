using System.Collections.Generic;

namespace Common.Models.Students
{
    public sealed class StudentsQueryOptions
    {
        public int? Skip { get; set; }

        public int? Take { get; set; }

        public long? GenderId { get; set; }

        public string Name { get; set; }

        public string Identifer { get; set; }

        public List<long> GroupIds { get; set; }
    }
}
