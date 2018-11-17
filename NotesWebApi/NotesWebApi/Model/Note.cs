using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotesWebApi.Model
{
    public class Note
    {
        public Guid Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime Created { get; set; }

        public Note()
        {
            Created = DateTime.Now;
                
        }

    }
}
