using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppDomain.Models
{
    public class BaseClass
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
