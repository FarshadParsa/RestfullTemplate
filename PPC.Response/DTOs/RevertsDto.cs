using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class RevertsDTO
    {

        #region Base properties
        public int Id { get; set; }

        public string RevertDate { get; set; }

        public string? Remark { get; set; }

        public int InsertUserId { get; set; }

        public int UpdateUserId { get; set; }

        public DateTime InsertDateTime { get; set; }

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
        public virtual CustomersDTO Customer { get; set; }


        #endregion

        #region User



        /// <summary>
        /// کاربر
        /// <summary>
        public int? UserID { get; set; }


        /// <summary>
        /// User is parent of this
        /// </summary>
        public virtual UsersDTO Users { get; set; }


        #endregion


        #endregion


        #region Children
        #region RevertPalets


        /// <summary>
        /// List<Reverts>
        /// </summary>
        public virtual List<RevertPaletsDTO>? RevertPaletsList { get; set; }

        #endregion

        #region RevertProducts


        /// <summary>
        /// List<Revert>
        /// </summary>
        public virtual List<RevertProductsDTO>? RevertProductsList { get; set; }

        #endregion

        #endregion

    }
}