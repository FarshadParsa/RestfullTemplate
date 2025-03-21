using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class ProductionPlanBOMDetailDTO
    {

        #region Base properties
        [JsonProperty("ProductionPlanBOMDetailID")]
        public int ProductionPlanBOMDetailID { get; set; }

        [JsonProperty("ProductionPlanID")]
        public int ProductionPlanID { get; set; }

        [JsonProperty("BomDetailID")]
        public int? BomDetailID { get; set; }

        [JsonProperty("RawMaterialID")]
        public int RawMaterialID { get; set; }

        [JsonProperty("RawMaterialType")]
        public string RawMaterialType { get; set; }

        [JsonProperty("ComplementaryCount")]
        public short ComplementaryCount { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }

        [JsonProperty("BOMComplementaryDesc")]
        public string BOMComplementaryDesc { get; set; }

        [JsonProperty("Planned")]
        public decimal Planned { get; set; }

        [JsonProperty("Stock")]
        public decimal Stock { get; set; }

        [JsonProperty("PlanningReserved")]
        public decimal PlanningReserved { get; set; }

        [JsonProperty("Expiration")]
        public string Expiration { get; set; }

        [JsonProperty("IsFinalRM")]
        public bool IsFinalRM { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }

        [JsonProperty("Percentage")]
        public decimal Percentage { get; set; }

        [JsonProperty("RequiredWeight")]
        public decimal RequiredWeight { get; set; }

        [JsonProperty("EditUserID")]
        public int EditUserID { get; set; }

        [JsonProperty("EditDate")]
        public string EditDate { get; set; }

        [JsonProperty("EditTime")]
        public string EditTime { get; set; }

        [JsonProperty("RowVer")]
        public byte[] RowVer { get; set; }
        #endregion Base properties


        [JsonProperty("ProductionPlan")]
        public ProductionPlansDTO ProductionPlan { get; set; }

        [JsonProperty("BOMDetail")]
        public BOMDetailDTO BOMDetail { get; set; }

        [JsonProperty("RawMaterial")]
        public RawMaterialsDTO RawMaterial { get; set; }

        [JsonProperty("User_EditUser")]
        public UsersDTO User_EditUser { get; set; }





    }
}