using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class RevertPaletsDTO
    {

        #region Base properties
        public int Id { get; set; }

        public string? Remark { get; set; }

        public int InsertUserId { get; set; }

        public int UpdateUserId { get; set; }

        public DateTime InsertDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
        #endregion Base properties



        #region Foreign Keys

        #region Reverts


        /// <summary>
        /// شناسه برگشتی
        /// <summary>
        public int RevertID { get; set; }


        /// <summary>
        /// Reverts is parent of this
        /// </summary>
        public virtual RevertsDTO? Reverts { get; set; }


        #endregion

        #region Palet




        /// <summary>
        /// شناسه پالت
        /// <summary>
        public int PaletID { get; set; }


        /// <summary>
        /// Palet is parent of this
        /// </summary>
        public virtual PaletsDTO? Palet { get; set; }


        #endregion

        #region NewPalet






        /// <summary>
        /// شناسه پالت جدید
        /// <summary>
        public int NewPaletID { get; set; }


        /// <summary>
        /// Palet is parent of this
        /// </summary>
        public virtual PaletsDTO? NewPalet { get; set; }


        #endregion


        #endregion


        #region Children

        #endregion



    }
}