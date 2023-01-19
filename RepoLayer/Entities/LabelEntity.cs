using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepoLayer.Entities
{
    public  class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long LabelId { get; set; }
        public string LabelName { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }


        public virtual UserEntity User { get; set; }
        [ForeignKey("Notes")]
        public long NoteID { get; set; }

        public virtual NoteEntity Notes { get; set; }
    }
}
