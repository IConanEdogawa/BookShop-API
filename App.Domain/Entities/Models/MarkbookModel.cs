using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Models
{
    public class MarkbookModel
    {
        public Guid Id { get; set; }
        public string TitleId { get; set; }
        public string Page { get; set; }

    }
}
