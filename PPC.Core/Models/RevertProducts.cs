using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Seedwork.Abstractions;
using System;
using PPC.Core.Models.Entity;


namespace PPC.Core.Models
{
    [Table("RevertProducts", Schema = "PPC")]
    public class RevertProducts : IEntity, IEntityInt, IEntityHasInsertUserIdInt, IEntityHasUpdateUserIdInt, IEntityHasInsertDateTime, IEntityHasUpdateDateTime
    {
        #region Base properties
        public int Id { get; set; }

        /// <summary>
        /// شناسه
        /// <summary>

        [NotMapped]
        public int RevertProductsId { get => Id; set => Id = value; }


        /// <summary>
        /// شناسه برگشتی
        /// <summary>
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int RevertID { get; set; }


        /// <summary>
        /// توضیحات
        /// <summary>
        public string? Remark { get; set; }

        /// <summary>
        /// شناسه ایجاد کننده
        /// <summary>
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int InsertUserId { get; set; }

        /// <summary>
        /// شناسه ویرایش کننده
        /// <summary>
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int UpdateUserId { get; set; }

        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        /// <summary>
        /// زمان ثبت
        /// <summary>
        public DateTime InsertDateTime { get; set; }

        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        /// <summary>
        /// 
        /// <summary>
        public DateTime UpdateDateTime { get; set; }
        #endregion Base properties


        #region Foreign Keys

        #region Revert


        /// <summary>
        /// Revert is parent of this
        /// </summary>
        public virtual Reverts? Revert { get; set; }


        #endregion

        #region Product


        /// <summary>
        /// شناسه محصول
        /// <summary>
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int InvProductID { get; set; }


        /// <summary>
        /// InvProduct is parent of this
        /// </summary>
        public virtual InvProducts InvProduct { get; set; }


        #endregion

        #region New Product



        /// <summary>
        /// شناسه محصول جدید
        /// <summary>
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int NewInvProductID { get; set; }


        /// <summary>
        /// Product is parent of this
        /// </summary>
        public virtual InvProducts NewInvProduct { get; set; }


        #endregion


        #endregion


        #region Children

        #endregion


    }
}