using WebApi.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApi.Core.Models
{

    [Table("Test")]
    public class Test : IEntity
    {

        [Key]
        public int Id { get; set; } = 1;



        public Test()
        {

        }

    }
}
