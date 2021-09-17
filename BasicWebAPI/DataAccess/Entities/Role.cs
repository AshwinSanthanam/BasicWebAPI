using System;

namespace BasicWebApi.DataAccess.Entities
{
    public class Role
    {
        public long Id { get; set; }
        public long Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
    }
}
