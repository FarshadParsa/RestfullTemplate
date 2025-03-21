using PPC.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPC.Core.Models
{
    [Table("Product")]
    public class Product :IEntity
    {

        # region properties
        [Key]
        [Column("ProductID")]
        public System.Int32 ProductID { get; set; }

        [Column("ProductCode")]
        public System.String ProductCode { get; set; } = string.Empty;

        [Column("ProductName")]
        public System.String ProductName { get; set; } = string.Empty;

        [Column("ProductLatinName")]
        public System.String ProductLatinName { get; set; } = string.Empty;

        [Column("ProductLabelName")]
        public System.String ProductLabelName { get; set; } = string.Empty;

        [Column("ProductLatinLabelName")]
        public System.String ProductLatinLabelName { get; set; } = string.Empty;

        [Column("ProductGroupID")]
        public ProductGroup ProductGroupID_ProductGroupID { get; set; }

        [Column("ProductTypeID")]
        public ProductType ProductType_ProductTypeID { get; set; }

        [Column("MetalizedPRoductID")]
        public System.Int32 MetalizedPRoductID { get; set; }

        [Column("CoatingProductID")]
        public Product Product_CoatingProductID { get; set; }

        [Column("IsTestProduct")]
        public System.Boolean IsTestProduct { get; set; }

        [Column("Description")]
        public System.String Description { get; set; } = string.Empty;

        [Column("DescriptionLatin")]
        public System.String DescriptionLatin { get; set; } = string.Empty;

        [Column("StoragePeriod")]
        public System.Int16 StoragePeriod { get; set; }

        [Column("MetalizedProductGroupID")]
        public ProductGroup ProductGroup_MetalizedProductGroupID { get; set; }

        //[Column("CoatingProductGroupID")]
        //public CoatingProductsGroup CoatingProductGroup_CoatingProductGroupID { get; set; }

        [Column("CoronaSymbolOUT")]
        public System.String CoronaSymbolOUT { get; set; } = string.Empty;

        [Column("CoronaSymbolIN")]
        public System.String CoronaSymbolIN { get; set; } = string.Empty;

        [Column("IsActive")]
        public System.Boolean IsActive { get; set; }

        [Column("Antistatic")]
        public System.Boolean Antistatic { get; set; }

        [Column("CertificateNo")]
        public System.String CertificateNo { get; set; } = string.Empty;


        #endregion properties


        public Product()
        {

        }

    }
}
