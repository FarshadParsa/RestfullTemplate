using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Seedwork.Abstractions;
using System;
using PPC.Common.Auth;
using System.Collections.Generic;
using PPC.Core.Models.Entity;
using Microsoft.Extensions.Logging;


namespace PPC.Core.Models
{
    [Table("Reverts", Schema = "dbo")]
    public class Reverts : IEntity 
        , IEntityInt
        , IEntityHasInsertUserIdInt
        , IEntityHasUpdateUserIdInt
        , IEntityHasInsertDateTime
        , IEntityHasUpdateDateTime
    {
        #region Base properties
        public int Id { get; set; }


        /// <summary>
        /// شناسه
        /// <summary>
        [NotMapped]
        public int RevertId { get => Id; set => Id = value; }


        /// <summary>
        /// تاریخ برگشت
        /// <summary>
        public string RevertDate { get; set; }


        /// <summary>
        /// شرح
        /// <summary>
        public string Remark { get; set; }


        /// <summary>
        /// شناسه ثبت کننده
        /// <summary>
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int InsertUserId { get; set; }


        /// <summary>
        /// شناسه ویرایش کننده
        /// <summary>
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int UpdateUserId { get; set; }


        /// <summary>
        /// زمان ثبت
        /// <summary>
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public DateTime InsertDateTime { get; set; }




        /// <summary>
        /// زمان ویرایش
        /// <summary>
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public DateTime UpdateDateTime { get; set; }



        #endregion Base properties


        #region Foreign Keys


        #region Customer



        /// <summary>
        /// شناسه مشتری
        /// <summary>
        public int? CustomerID { get; set; }


        /// <summary>
        /// Customer is parent of this
        /// </summary>
        public virtual Customers Customer { get; set; }


        #endregion

        #region User



        /// <summary>
        /// کاربر
        /// <summary>
        public int UserID { get; set; }


        /// <summary>
        /// User is parent of this
        /// </summary>
        public virtual Users Users { get; set; }


        #endregion


        #endregion


        #region Children

        #region RevertPalets


        /// <summary>
        /// List<Reverts>
        /// </summary>
        //[ForeignKey(nameof(RevertId))]
        [ForeignKey("RevertID")]
        public virtual List<RevertPalets>? RevertPaletsList { get; set; }

        #endregion



        #region RevertProducts


        /// <summary>
        /// List<Revert>
        /// </summary>
        [ForeignKey(nameof(RevertId))]
        public virtual List<RevertProducts>? RevertProductsList { get; set; }

        #endregion


        #endregion





    }
}