using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ToDo.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ToDoUser class
    public class ToDoUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String LastName { get; set; }

        public virtual ICollection<UserTask> UserTasks { get; set; }

    }
}
