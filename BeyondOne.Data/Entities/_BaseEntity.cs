using System;

namespace BeyondOne.Data.Entities
{
    public class _BaseEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
