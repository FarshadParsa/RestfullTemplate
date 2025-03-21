using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Seedwork.Abstractions;
using System;
using PPC.Core.Models.Entity;


namespace PPC.Core.Models
{
    [Table("RevertPalets", Schema = "dbo")]
    public class RevertPalets : IEntity
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
        public int RevertPaletsId { get => Id; set => Id = value; }


        /// <summary>
        /// شرح
        /// <summary>



        public string? Remark { get; set; }

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

        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        /// <summary>
        /// زمان ویرایش
        /// <summary>
        public DateTime UpdateDateTime { get; set; }

        #endregion Base properties


        #region Foreign Keys

        #region Reverts


        /// <summary>
        /// شناسه برگشتی
        /// <summary>
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int RevertID { get; set; }


        /// <summary>
        /// Reverts is parent of this
        /// </summary>
        public virtual Reverts? Reverts { get; set; }


        #endregion

        #region Palet




        /// <summary>
        /// شناسه پالت
        /// <summary>
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int PaletID { get; set; }


        /// <summary>
        /// Palet is parent of this
        /// </summary>
        public virtual Palets? Palet { get; set; }


        #endregion

        #region NewPalet



        /// <summary>
        /// شناسه پالت جدید
        /// <summary>
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int NewPaletID { get; set; }


        /// <summary>
        /// Palet is parent of this
        /// </summary>
        public virtual Palets? NewPalet { get; set; }


        #endregion

        #endregion


        #region Children

        #endregion


    }
}