using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Areas.Identity.Data
{
    public class UserTask
    {

        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual ToDoUser User { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int Hour { get; set; }
    }
}
