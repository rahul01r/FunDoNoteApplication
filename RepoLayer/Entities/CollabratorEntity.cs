using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepoLayer.Entities
{
    public class CollabratorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long CollabId { get; set; }
        public string Email { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }

       
        public virtual UserEntity User { get; set; }
        [ForeignKey("Notes")]
        public long NoteID { get; set; }
        
        public virtual NoteEntity Notes { get; set; }
    }
}
