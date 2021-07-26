using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CognizatChallengeServer
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Attempt> Attempts { get; set; }
    }
}
