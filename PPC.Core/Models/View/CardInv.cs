using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace PPC.Core.Models
{
    //[PrimaryKey(nameof(RawMaterialID))]

    public class CardInv : IEntity
    {
        #region Base properties
        //[Column("InvTypeID")]
        [JsonProperty("InvTypeID")]
        [MaxLength(1)]
        public char InvTypeID { get; set; }

        //[Column("Year")]
        [JsonProperty("Year")]
        public short Year { get; set; }

        //[Column("RawMaterialID")]
        [JsonProperty("RawMaterialID")]
        public int RawMaterialID { get; set; }

        //[Column("Amount")]
        [JsonProperty("Amount")]
        public decimal Amount { get; set; }
        #endregion Base properties
    }
}