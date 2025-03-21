using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class InvProductsDTO
    {

        #region Base properties
        [JsonProperty("InvProductID")]
        public int InvProductID { get; set; }

        [JsonProperty("InvProductCode")]
        public string InvProductCode { get; set; }

        [JsonProperty("DataProductionID")]
        public int? DataProductionID { get; set; }

        [JsonProperty("ProductID")]
        public int ProductID { get; set; }

        [JsonProperty("WeightingProductDetailID")]
        public int? WeightingProductDetailID { get; set; }

        [JsonProperty("Weight")]
        public decimal Weight { get; set; }

        [JsonProperty("NetWeight")]
        public decimal NetWeight { get; set; }

        [JsonProperty("EntryDate")]
        public string EntryDate { get; set; }

        [JsonProperty("ProducedDate")]
        public string ProducedDate { get; set; }

        [JsonProperty("ExpireDate")]
        public string ExpireDate { get; set; }

        [JsonProperty("ShelfLife")]
        public string ShelfLife { get; set; }

        [JsonProperty("EnProducedDate")]
        public string EnProducedDate { get; set; }

        [JsonProperty("EnExpireDate")]
        public string EnExpireDate { get; set; }

        [JsonProperty("EnShelfLife")]
        public string EnShelfLife { get; set; }

        [JsonProperty("PackagingTypeID")]
        public int PackagingTypeID { get; set; }

        [JsonProperty("SupplierID")]
        public short? SupplierID { get; set; }

        [JsonProperty("Remark")]
        public string Remark { get; set; }

        [JsonProperty("Status")]
        public byte Status { get; set; }

        [JsonProperty("QcStatus")]
        public byte QcStatus { get; set; }

        [JsonProperty("PaletID")]
        public int? PaletID { get; set; }

        [JsonProperty("ParentID")]
        public int? ParentID { get; set; }

        [JsonProperty("InsUserID")]
        public int InsUserID { get; set; }

        [JsonProperty("InsDate")]
        public string InsDate { get; set; }

        [JsonProperty("InsTime")]
        public string InsTime { get; set; }

        [JsonProperty("EditUserID")]
        public int EditUserID { get; set; }

        [JsonProperty("EditDate")]
        public string EditDate { get; set; }

        [JsonProperty("EditTime")]
        public string EditTime { get; set; }
        #endregion Base properties



        [JsonProperty("DataProduction")]
        public DataProductionDTO DataProduction { get; set; }

        [JsonProperty("Product")]
        public ProductsDTO Product { get; set; }

        [JsonProperty("WeightingProductDetail")]
        public WeightingProductDetailDTO WeightingProductDetail { get; set; }

        [JsonProperty("PackagingType")]
        public PackagingTypesDTO PackagingType { get; set; }

        [JsonProperty("Supplier")]
        public SuppliersDTO Supplier { get; set; }

        [JsonProperty("Palet")]
        public PaletsDTO Palet { get; set; }

        [JsonProperty("Parent")]
        public InvProductsDTO Parent { get; set; }

        [JsonProperty("User_InsUser")]
        public UsersDTO User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        public UsersDTO User_EditUser { get; set; }


    }
}
