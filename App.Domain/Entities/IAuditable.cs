using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public interface IAuditable
    {
        [DataType(DataType.DateTime)]
        public DateTimeOffset CreatedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset UpdatedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset? DeletedDate { get; set; }

        public bool IsDeleted { get; set; }

    }
}
