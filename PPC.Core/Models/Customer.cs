using PPC.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPC.Core.Models
{
    [Table("Customer")]
    public class Customer : IEntity
    {

        [Key]
        [Column("CustomerID")]
        public System.Int32 CustomerID { get; set; }

        [Column("CustCode")]
        public System.String CustCode { get; set; } = string.Empty;

        [Column("CustName")]
        public System.String CustName { get; set; } = string.Empty;

        [Column("ProvinceID")]
        public Provinces Province_ProvinceID { get; set; }

        //[Column("CustomerTargetingID")]
        //public CustomerTargetingDL CustomerTargeting_CustomerTargetingID { get; set; }

        [Column("CustLatinName")]
        public System.String CustLatinName { get; set; } = string.Empty;

        [Column("Address")]
        public System.String Address { get; set; } = string.Empty;

        [Column("Tel")]
        public System.String Tel { get; set; } = string.Empty;

        [Column("ContactPerson")]
        public System.String ContactPerson { get; set; } = string.Empty;

        [Column("IsActive")]
        public System.Boolean IsActive { get; set; }

        [Column("IsForiegn")]
        public System.Boolean IsForiegn { get; set; }

        [Column("IsWhite")]
        public System.Boolean IsWhite { get; set; }

        [Column("CustPersianName")]
        public System.String CustPersianName { get; set; } = string.Empty;

        [Column("InvoicingAddress")]
        public System.String InvoicingAddress { get; set; } = string.Empty;

        [Column("DeliveryAddress")]
        public System.String DeliveryAddress { get; set; } = string.Empty;

        [Column("Stars")]
        public System.Int16 Stars { get; set; }

        [Column("IsAgent")]
        public System.Boolean IsAgent { get; set; }

        [Column("AgentName")]
        public System.String AgentName { get; set; } = string.Empty;

        [Column("AgentID")]
        public System.Int32? AgentID { get; set; }

        //[Column("TrackingID")]
        //public CustomerAgentsTrackingDL CustomerAgentsTracking_TrackingID { get; set; }


        public Customer()
        {

        }


    }
}
