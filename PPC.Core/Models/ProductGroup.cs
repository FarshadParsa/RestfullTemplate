using PPC.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPC.Core.Models
{
    [Table("ProductGroup")]
    public class ProductGroup
    {

        #region properties
        [Key]
        [Column("ProductGroupID")]
        public System.Int32 ProductGroupID { get; set; }

        [Column("ProductGroupName")]
        public System.String ProductGroupName { get; set; } = string.Empty;

        [Column("ProductGroupLatinName")]
        public System.String ProductGroupLatinName { get; set; } = string.Empty;

        //[Column("ProductGroupTypeID")]
        //public ProductGroupType ProductGroupType_ProductGroupTypeID { get; set; }

        [Column("ShouldMetalized")]
        public System.Boolean ShouldMetalized { get; set; }

        [Column("CertificateNo")]
        public System.String CertificateNo { get; set; } = string.Empty;


        #endregion properties

        public ProductGroup()
        {

        }
    }
}
