using Newtonsoft.Json;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class PaletsDTO
    {

        #region Base properties
        [JsonProperty("PaletID")]
        public int PaletID { get; set; }

        [JsonProperty("PaletNo")]
        public string PaletNo { get; set; }

        [JsonProperty("CustomerID")]
        public int? CustomerID { get; set; }

        [JsonProperty("OrderDetailID")]
        public int? OrderDetailID { get; set; }

        [JsonProperty("ProductID")]
        public int ProductID { get; set; }

        [JsonProperty("NetWeight")]
        public decimal NetWeight { get; set; }

        [JsonProperty("Weight")]
        public decimal Weight { get; set; }

        [JsonProperty("QTY")]
        public short QTY { get; set; }

        [JsonProperty("PaletDate")]
        public string PaletDate { get; set; }

        [JsonProperty("PaletTime")]
        public string PaletTime { get; set; }

        [JsonProperty("UserID")]
        public int UserID { get; set; }

        [JsonProperty("StationID")]
        public int StationID { get; set; }

        [JsonProperty("QualityClass")]
        public string QualityClass { get; set; }

        [JsonProperty("Status")]
        public byte Status { get; set; }

        [JsonProperty("ProductsQuality")]
        public string ProductsQuality { get; set; }

        [JsonProperty("Remarks")]
        public string Remarks { get; set; }

        [JsonProperty("QcStatus")]
        public byte? QcStatus { get; set; }
        #endregion Base properties


        [JsonProperty("Customer")]
        public CustomersDTO Customer { get; set; }


        [JsonProperty("OrderDetail")]
        public OrderDetailsDTO OrderDetail { get; set; }


        [JsonProperty("Product")]
        public ProductsDTO Product { get; set; }


        [JsonProperty("User")]
        public UsersDTO User { get; set; }


        [JsonProperty("Station")]
        public StationsDTO Station { get; set; }


        [JsonProperty("PaletDetailList")]
        public List<PaletDetailDTO> PaletDetailList { get; set; }

        #region Foreign Keys


        #endregion


        #region Children

        #region RevertPalets


        /// <summary>
        /// List<Palet>
        /// </summary>
        public virtual List<RevertPaletsDTO> RevertPaletsList { get; set; }

        #endregion

        #region RevertPalets


        /// <summary>
        /// List<Palet>
        /// </summary>
        public virtual List<RevertPaletsDTO> RevertNewPaletsList { get; set; }

        #endregion



        #endregion


    }
}