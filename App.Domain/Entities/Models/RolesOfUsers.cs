using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Models
{
    public class RolesOfUsers
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public UserModel User { get; set; }
        public Guid RoleId { get; set; }
        [JsonIgnore]
        public Roles Role { get; set; }
    }
}
