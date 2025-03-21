using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class RevertProductsDTO
    {

        #region Base properties
        public int Id { get; set; }

        public int RevertID { get; set; }

        public string Remark { get; set; }

        public int InsertUserId { get; set; }

        public int UpdateUserId { get; set; }

        public DateTime InsertDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
        #endregion Base properties




        #region Foreign Keys

        #region Revert


        /// <summary>
        /// Revert is parent of this
        /// </summary>
        public virtual RevertsDTO Revert { get; set; }


        #endregion

        #region Product


        /// <summary>
        /// شناسه محصول
        /// <summary>
        public int InvProductID { get; set; }


        /// <summary>
        /// Product is parent of this
        /// </summary>
        public virtual InvProductsDTO InvProduct { get; set; }


        #endregion

        #region New Product



        /// <summary>
        /// شناسه محصول جدید
        /// <summary>
        public int NewInvProductID { get; set; }


        /// <summary>
        /// Product is parent of this
        /// </summary>
        public virtual InvProductsDTO? NewInvProduct { get; set; }


        #endregion


        #endregion


        #region Children

        #endregion


    }
}