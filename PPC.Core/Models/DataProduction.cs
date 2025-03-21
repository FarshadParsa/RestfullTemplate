using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Core.Models
{
    [Table("DataProduction")]
    public class DataProduction : IEntity
    {
        #region Base properties
        [Key]
        [Column("DataProductionID")]
        [JsonProperty("DataProductionID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int DataProductionID { get; set; }

        [Column("ProductionPlanPatilID")]
        [JsonProperty("ProductionPlanPatilID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int ProductionPlanPatilID { get; set; }

        [Column("StartDate")]
        [JsonProperty("StartDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string StartDate { get; set; }

        [Column("StartTime")]
        [JsonProperty("StartTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]

        public string StartTime { get; set; }

        [Column("EndDate")]
        [JsonProperty("EndDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string EndDate { get; set; }

        [Column("EndTime")]
        [JsonProperty("EndTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]

        public string EndTime { get; set; }

        [Column("Duration")]
        [JsonProperty("Duration")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int Duration { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]

        [MaxLength(150)]

        public string Describe { get; set; }

        [Column("PatilID")]
        [JsonProperty("PatilID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int PatilID { get; set; }

        [Column("Patil_Capacity")]
        [JsonProperty("Patil_Capacity")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public short Patil_Capacity { get; set; }

        [Column("Patil_EmptyWeight")]
        [JsonProperty("Patil_EmptyWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal Patil_EmptyWeight { get; set; }

        [Column("Patil_AfterChargeWeight")]
        [JsonProperty("Patil_AfterChargeWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal Patil_AfterChargeWeight { get; set; }

        [Column("Patil_AfterFirstMixWeight")]
        [JsonProperty("Patil_AfterFirstMixWeight")]



        public decimal? Patil_AfterFirstMixWeight { get; set; }

        [Column("Patil_DuringGrindingWeight")]
        [JsonProperty("Patil_DuringGrindingWeight")]



        public decimal? Patil_DuringGrindingWeight { get; set; }

        [Column("Patil_FinalWeight")]
        [JsonProperty("Patil_FinalWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal Patil_FinalWeight { get; set; }

        [Column("Patil_NetWeight")]
        [JsonProperty("Patil_NetWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal Patil_NetWeight { get; set; }

        [Column("Patil_MaterialEvaporation")]
        [JsonProperty("Patil_MaterialEvaporation")]



        public decimal? Patil_MaterialEvaporation { get; set; }

        [Column("Patil_Wastes")]
        [JsonProperty("Patil_Wastes")]



        public decimal? Patil_Wastes { get; set; }

        [Column("Patil_Describe")]
        [JsonProperty("Patil_Describe")]

        [MaxLength(150)]

        public string Patil_Describe { get; set; }








        //[Column("Dosing_StartDate")]
        //[JsonProperty("Dosing_StartDate")]
        //[MaxLength(10)]
        //public string Dosing_StartDate { get; set; }

        //[Column("Dosing_StartTime")]
        //[JsonProperty("Dosing_StartTime")]
        //[MaxLength(5)]
        //public string Dosing_StartTime { get; set; }

        //[Column("Dosing_EndDate")]
        //[JsonProperty("Dosing_EndDate")]
        //[MaxLength(10)]
        //public string Dosing_EndDate { get; set; }

        //[Column("Dosing_EndTime")]
        //[JsonProperty("Dosing_EndTime")]
        //[MaxLength(5)]
        //public string Dosing_EndTime { get; set; }

        //[Column("Dosing_Duration")]
        //[JsonProperty("Dosing_Duration")]
        //public short? Dosing_Duration { get; set; }

        //[Column("Dosing_WeighbridgeNo")]
        //[JsonProperty("Dosing_WeighbridgeNo")]
        //public byte? Dosing_WeighbridgeNo { get; set; }

        //[Column("Dosing_ShiftNo")]
        //[JsonProperty("Dosing_ShiftNo")]
        //[MaxLength(1)]
        //public string Dosing_ShiftNo { get; set; }

        //[Column("Dosing_Operators")]
        //[JsonProperty("Dosing_Operators")]
        //[MaxLength(50)]
        //public string Dosing_Operators { get; set; }

        //[Column("Dosing_Wastes")]
        //[JsonProperty("Dosing_Wastes")]
        //public decimal? Dosing_Wastes { get; set; }

        //[Column("Dosing_Stopes")]
        //[JsonProperty("Dosing_Stopes")]
        //public short? Dosing_Stopes { get; set; }

        //[Column("Dosing_StopesDesc")]
        //[JsonProperty("Dosing_StopesDesc")]
        //[MaxLength(50)]
        //public string Dosing_StopesDesc { get; set; }

        //[Column("Dosing_Describe")]
        //[JsonProperty("Dosing_Describe")]
        //[MaxLength(150)]
        //public string Dosing_Describe { get; set; }


        [Column("Dosing1_StartDate")]
        [JsonProperty("Dosing1_StartDate")]
        [MaxLength(10)]
        public string Dosing1_StartDate { get; set; }

        [Column("Dosing1_StartTime")]
        [JsonProperty("Dosing1_StartTime")]
        [MaxLength(5)]
        public string Dosing1_StartTime { get; set; }

        [Column("Dosing1_EndDate")]
        [JsonProperty("Dosing1_EndDate")]
        [MaxLength(10)]
        public string Dosing1_EndDate { get; set; }

        [Column("Dosing1_EndTime")]
        [JsonProperty("Dosing1_EndTime")]
        [MaxLength(5)]
        public string Dosing1_EndTime { get; set; }

        [Column("Dosing1_Duration")]
        [JsonProperty("Dosing1_Duration")]
        public short? Dosing1_Duration { get; set; }

        [Column("Dosing1_WeighbridgeNo")]
        [JsonProperty("Dosing1_WeighbridgeNo")]
        public byte? Dosing1_WeighbridgeNo { get; set; }

        [Column("Dosing1_ShiftNo")]
        [JsonProperty("Dosing1_ShiftNo")]
        [MaxLength(1)]
        public string Dosing1_ShiftNo { get; set; }

        [Column("Dosing1_Operators")]
        [JsonProperty("Dosing1_Operators")]
        [MaxLength(50)]
        public string Dosing1_Operators { get; set; }

        [Column("Dosing1_Wastes")]
        [JsonProperty("Dosing1_Wastes")]
        public decimal? Dosing1_Wastes { get; set; }

        [Column("Dosing1_Stopes")]
        [JsonProperty("Dosing1_Stopes")]
        public short? Dosing1_Stopes { get; set; }

        [Column("Dosing1_StopesDesc")]
        [JsonProperty("Dosing1_StopesDesc")]
        [MaxLength(50)]
        public string Dosing1_StopesDesc { get; set; }

        [Column("Dosing1_Describe")]
        [JsonProperty("Dosing1_Describe")]
        [MaxLength(150)]
        public string Dosing1_Describe { get; set; }


        [Column("Dosing2_StartDate")]
        [JsonProperty("Dosing2_StartDate")]
        [MaxLength(10)]
        public string Dosing2_StartDate { get; set; }

        [Column("Dosing2_StartTime")]
        [JsonProperty("Dosing2_StartTime")]
        [MaxLength(5)]
        public string Dosing2_StartTime { get; set; }

        [Column("Dosing2_EndDate")]
        [JsonProperty("Dosing2_EndDate")]
        [MaxLength(10)]
        public string Dosing2_EndDate { get; set; }

        [Column("Dosing2_EndTime")]
        [JsonProperty("Dosing2_EndTime")]
        [MaxLength(5)]
        public string Dosing2_EndTime { get; set; }

        [Column("Dosing2_Duration")]
        [JsonProperty("Dosing2_Duration")]
        public short? Dosing2_Duration { get; set; }

        [Column("Dosing2_WeighbridgeNo")]
        [JsonProperty("Dosing2_WeighbridgeNo")]
        public byte? Dosing2_WeighbridgeNo { get; set; }

        [Column("Dosing2_ShiftNo")]
        [JsonProperty("Dosing2_ShiftNo")]
        [MaxLength(1)]
        public string Dosing2_ShiftNo { get; set; }

        [Column("Dosing2_Operators")]
        [JsonProperty("Dosing2_Operators")]
        [MaxLength(50)]
        public string Dosing2_Operators { get; set; }

        [Column("Dosing2_Wastes")]
        [JsonProperty("Dosing2_Wastes")]
        public decimal? Dosing2_Wastes { get; set; }

        [Column("Dosing2_Stopes")]
        [JsonProperty("Dosing2_Stopes")]
        public short? Dosing2_Stopes { get; set; }

        [Column("Dosing2_StopesDesc")]
        [JsonProperty("Dosing2_StopesDesc")]
        [MaxLength(50)]
        public string Dosing2_StopesDesc { get; set; }

        [Column("Dosing2_Describe")]
        [JsonProperty("Dosing2_Describe")]
        [MaxLength(150)]
        public string Dosing2_Describe { get; set; }


        [Column("Dosing3_StartDate")]
        [JsonProperty("Dosing3_StartDate")]
        [MaxLength(10)]
        public string Dosing3_StartDate { get; set; }

        [Column("Dosing3_StartTime")]
        [JsonProperty("Dosing3_StartTime")]
        [MaxLength(5)]
        public string Dosing3_StartTime { get; set; }

        [Column("Dosing3_EndDate")]
        [JsonProperty("Dosing3_EndDate")]
        [MaxLength(10)]
        public string Dosing3_EndDate { get; set; }

        [Column("Dosing3_EndTime")]
        [JsonProperty("Dosing3_EndTime")]
        [MaxLength(5)]
        public string Dosing3_EndTime { get; set; }

        [Column("Dosing3_Duration")]
        [JsonProperty("Dosing3_Duration")]
        public short? Dosing3_Duration { get; set; }

        [Column("Dosing3_WeighbridgeNo")]
        [JsonProperty("Dosing3_WeighbridgeNo")]
        public byte? Dosing3_WeighbridgeNo { get; set; }

        [Column("Dosing3_ShiftNo")]
        [JsonProperty("Dosing3_ShiftNo")]
        [MaxLength(1)]
        public string Dosing3_ShiftNo { get; set; }

        [Column("Dosing3_Operators")]
        [JsonProperty("Dosing3_Operators")]
        [MaxLength(50)]
        public string Dosing3_Operators { get; set; }

        [Column("Dosing3_Wastes")]
        [JsonProperty("Dosing3_Wastes")]
        public decimal? Dosing3_Wastes { get; set; }

        [Column("Dosing3_Stopes")]
        [JsonProperty("Dosing3_Stopes")]
        public short? Dosing3_Stopes { get; set; }

        [Column("Dosing3_StopesDesc")]
        [JsonProperty("Dosing3_StopesDesc")]
        [MaxLength(50)]
        public string Dosing3_StopesDesc { get; set; }

        [Column("Dosing3_Describe")]
        [JsonProperty("Dosing3_Describe")]
        [MaxLength(150)]
        public string Dosing3_Describe { get; set; }


        [Column("Dosing4_StartDate")]
        [JsonProperty("Dosing4_StartDate")]
        [MaxLength(10)]
        public string Dosing4_StartDate { get; set; }

        [Column("Dosing4_StartTime")]
        [JsonProperty("Dosing4_StartTime")]
        [MaxLength(5)]
        public string Dosing4_StartTime { get; set; }

        [Column("Dosing4_EndDate")]
        [JsonProperty("Dosing4_EndDate")]
        [MaxLength(10)]
        public string Dosing4_EndDate { get; set; }

        [Column("Dosing4_EndTime")]
        [JsonProperty("Dosing4_EndTime")]
        [MaxLength(5)]
        public string Dosing4_EndTime { get; set; }

        [Column("Dosing4_Duration")]
        [JsonProperty("Dosing4_Duration")]
        public short? Dosing4_Duration { get; set; }

        [Column("Dosing4_WeighbridgeNo")]
        [JsonProperty("Dosing4_WeighbridgeNo")]
        public byte? Dosing4_WeighbridgeNo { get; set; }

        [Column("Dosing4_ShiftNo")]
        [JsonProperty("Dosing4_ShiftNo")]
        [MaxLength(1)]
        public string Dosing4_ShiftNo { get; set; }

        [Column("Dosing4_Operators")]
        [JsonProperty("Dosing4_Operators")]
        [MaxLength(50)]
        public string Dosing4_Operators { get; set; }

        [Column("Dosing4_Wastes")]
        [JsonProperty("Dosing4_Wastes")]
        public decimal? Dosing4_Wastes { get; set; }

        [Column("Dosing4_Stopes")]
        [JsonProperty("Dosing4_Stopes")]
        public short? Dosing4_Stopes { get; set; }

        [Column("Dosing4_StopesDesc")]
        [JsonProperty("Dosing4_StopesDesc")]
        [MaxLength(50)]
        public string Dosing4_StopesDesc { get; set; }

        [Column("Dosing4_Describe")]
        [JsonProperty("Dosing4_Describe")]
        [MaxLength(150)]
        public string Dosing4_Describe { get; set; }





        [Column("Mixer_StationID")]
        [JsonProperty("Mixer_StationID")]
        public int? Mixer_StationID { get; set; }

        [Column("Mixer_StartDate")]
        [JsonProperty("Mixer_StartDate")]

        [MaxLength(10)]

        public string Mixer_StartDate { get; set; }

        [Column("Mixer_StartTime")]
        [JsonProperty("Mixer_StartTime")]

        [MaxLength(5)]

        public string Mixer_StartTime { get; set; }

        [Column("Mixer_EndDate")]
        [JsonProperty("Mixer_EndDate")]

        [MaxLength(10)]

        public string Mixer_EndDate { get; set; }

        [Column("Mixer_EndTime")]
        [JsonProperty("Mixer_EndTime")]

        [MaxLength(5)]

        public string Mixer_EndTime { get; set; }

        [Column("Mixer_Duration")]
        [JsonProperty("Mixer_Duration")]



        public short? Mixer_Duration { get; set; }

        [Column("Mixer_ShiftNo")]
        [JsonProperty("Mixer_ShiftNo")]

        [MaxLength(1)]

        public string Mixer_ShiftNo { get; set; }

        [Column("Mixer_Operators")]
        [JsonProperty("Mixer_Operators")]

        [MaxLength(50)]

        public string Mixer_Operators { get; set; }

        [Column("Mixer_Wastes")]
        [JsonProperty("Mixer_Wastes")]



        public decimal? Mixer_Wastes { get; set; }

        [Column("Mixer_Stopes")]
        [JsonProperty("Mixer_Stopes")]



        public short? Mixer_Stopes { get; set; }

        [Column("Mixer_StopesDesc")]
        [JsonProperty("Mixer_StopesDesc")]

        [MaxLength(50)]

        public string Mixer_StopesDesc { get; set; }

        [Column("Mixer_StationSpeed")]
        [JsonProperty("Mixer_StationSpeed")]



        public short? Mixer_StationSpeed { get; set; }

        [Column("Mixer_Describe")]
        [JsonProperty("Mixer_Describe")]

        [MaxLength(150)]

        public string Mixer_Describe { get; set; }

        [Column("Reactor_StationID")]
        [JsonProperty("Reactor_StationID")]



        public int? Reactor_StationID { get; set; }

        [Column("Reactor_StartDate")]
        [JsonProperty("Reactor_StartDate")]

        [MaxLength(10)]

        public string Reactor_StartDate { get; set; }

        [Column("Reactor_StartTime")]
        [JsonProperty("Reactor_StartTime")]

        [MaxLength(5)]

        public string Reactor_StartTime { get; set; }

        [Column("Reactor_EndDate")]
        [JsonProperty("Reactor_EndDate")]

        [MaxLength(10)]

        public string Reactor_EndDate { get; set; }

        [Column("Reactor_EndTime")]
        [JsonProperty("Reactor_EndTime")]

        [MaxLength(5)]

        public string Reactor_EndTime { get; set; }

        [Column("Reactor_Duration")]
        [JsonProperty("Reactor_Duration")]



        public short? Reactor_Duration { get; set; }

        [Column("Reactor_ShiftNo")]
        [JsonProperty("Reactor_ShiftNo")]

        [MaxLength(1)]

        public string Reactor_ShiftNo { get; set; }

        [Column("Reactor_Operators")]
        [JsonProperty("Reactor_Operators")]

        [MaxLength(50)]

        public string Reactor_Operators { get; set; }

        [Column("Reactor_Wastes")]
        [JsonProperty("Reactor_Wastes")]



        public decimal? Reactor_Wastes { get; set; }

        [Column("Reactor_Stopes")]
        [JsonProperty("Reactor_Stopes")]



        public short? Reactor_Stopes { get; set; }

        [Column("Reactor_StopesDesc")]
        [JsonProperty("Reactor_StopesDesc")]

        [MaxLength(50)]

        public string Reactor_StopesDesc { get; set; }

        [Column("Reactor_MixerSpeed")]
        [JsonProperty("Reactor_MixerSpeed")]



        public short? Reactor_MixerSpeed { get; set; }

        [Column("Reactor_Temperature")]
        [JsonProperty("Reactor_Temperature")]



        public decimal? Reactor_Temperature { get; set; }

        [Column("Reactor_MaterialTemperature")]
        [JsonProperty("Reactor_MaterialTemperature")]



        public decimal? Reactor_MaterialTemperature { get; set; }

        [Column("Reactor_Describe")]
        [JsonProperty("Reactor_Describe")]

        [MaxLength(150)]

        public string Reactor_Describe { get; set; }

        [Column("Premix_StationID")]
        [JsonProperty("Premix_StationID")]



        public int? Premix_StationID { get; set; }

        [Column("Premix_StartDate")]
        [JsonProperty("Premix_StartDate")]

        [MaxLength(10)]

        public string Premix_StartDate { get; set; }

        [Column("Premix_StartTime")]
        [JsonProperty("Premix_StartTime")]

        [MaxLength(5)]

        public string Premix_StartTime { get; set; }

        [Column("Premix_EndDate")]
        [JsonProperty("Premix_EndDate")]

        [MaxLength(10)]

        public string Premix_EndDate { get; set; }

        [Column("Premix_EndTime")]
        [JsonProperty("Premix_EndTime")]

        [MaxLength(5)]

        public string Premix_EndTime { get; set; }

        [Column("Premix_Duration")]
        [JsonProperty("Premix_Duration")]



        public short? Premix_Duration { get; set; }

        [Column("Premix_ShiftNo")]
        [JsonProperty("Premix_ShiftNo")]

        [MaxLength(1)]

        public string Premix_ShiftNo { get; set; }

        [Column("Premix_Operators")]
        [JsonProperty("Premix_Operators")]

        [MaxLength(50)]

        public string Premix_Operators { get; set; }

        [Column("Premix_Wastes")]
        [JsonProperty("Premix_Wastes")]



        public decimal? Premix_Wastes { get; set; }

        [Column("Premix_Stopes")]
        [JsonProperty("Premix_Stopes")]



        public short? Premix_Stopes { get; set; }

        [Column("Premix_StopesDesc")]
        [JsonProperty("Premix_StopesDesc")]

        [MaxLength(50)]

        public string Premix_StopesDesc { get; set; }

        [Column("Premix_StationSpeed")]
        [JsonProperty("Premix_StationSpeed")]



        public short? Premix_StationSpeed { get; set; }

        [Column("Premix_Describe")]
        [JsonProperty("Premix_Describe")]

        [MaxLength(150)]

        public string Premix_Describe { get; set; }

        [Column("Grinding_StationID")]
        [JsonProperty("Grinding_StationID")]



        public int? Grinding_StationID { get; set; }

        [Column("Grinding_StartDate")]
        [JsonProperty("Grinding_StartDate")]

        [MaxLength(10)]

        public string Grinding_StartDate { get; set; }

        [Column("Grinding_StartTime")]
        [JsonProperty("Grinding_StartTime")]

        [MaxLength(5)]

        public string Grinding_StartTime { get; set; }

        [Column("Grinding_EndDate")]
        [JsonProperty("Grinding_EndDate")]

        [MaxLength(10)]

        public string Grinding_EndDate { get; set; }

        [Column("Grinding_EndTime")]
        [JsonProperty("Grinding_EndTime")]

        [MaxLength(5)]

        public string Grinding_EndTime { get; set; }

        [Column("Grinding_Duration")]
        [JsonProperty("Grinding_Duration")]



        public short? Grinding_Duration { get; set; }

        [Column("Grinding_ShiftNo")]
        [JsonProperty("Grinding_ShiftNo")]

        [MaxLength(1)]

        public string Grinding_ShiftNo { get; set; }

        [Column("Grinding_Operators")]
        [JsonProperty("Grinding_Operators")]

        [MaxLength(50)]

        public string Grinding_Operators { get; set; }

        [Column("Grinding_Stopes")]
        [JsonProperty("Grinding_Stopes")]



        public short? Grinding_Stopes { get; set; }

        [Column("Grinding_StopesDesc")]
        [JsonProperty("Grinding_StopesDesc")]

        [MaxLength(50)]

        public string Grinding_StopesDesc { get; set; }

        [Column("Grinding_StationSpeed")]
        [JsonProperty("Grinding_StationSpeed")]



        public short? Grinding_StationSpeed { get; set; }

        [Column("Grinding_Describe")]
        [JsonProperty("Grinding_Describe")]

        [MaxLength(150)]

        public string Grinding_Describe { get; set; }

        [Column("InsUserID")]
        [JsonProperty("InsUserID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int InsUserID { get; set; }

        [Column("InsDate")]
        [JsonProperty("InsDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string InsDate { get; set; }

        [Column("InsTime")]
        [JsonProperty("InsTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]

        public string InsTime { get; set; }

        [Column("EditUserID")]
        [JsonProperty("EditUserID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int EditUserID { get; set; }

        [Column("EditDate")]
        [JsonProperty("EditDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string EditDate { get; set; }

        [Column("EditTime")]
        [JsonProperty("EditTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]

        public string EditTime { get; set; }

        [Column("RowVer")]
        [JsonProperty("RowVer")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Timestamp]
        public byte[] RowVer { get; set; }

        #endregion Base properties


        [JsonProperty("ProductionPlanPatil")]
        [ForeignKey(nameof(ProductionPlanPatilID))]
        public ProductionPlanPatils ProductionPlanPatil { get; set; }

        [JsonProperty("Patil")]
        [ForeignKey(nameof(PatilID))]
        public Patils Patil { get; set; }

        [JsonProperty("Premix_Station")]
        [ForeignKey(nameof(Premix_StationID))]
        public Stations Premix_Station { get; set; }

        [JsonProperty("Grinding_Station")]
        [ForeignKey(nameof(Grinding_StationID))]
        public Stations Grinding_Station { get; set; }

        [JsonProperty("User_InsUser")]
        [ForeignKey(nameof(InsUserID))]
        public Users User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        [ForeignKey(nameof(EditUserID))]
        public Users User_EditUser { get; set; }



        [JsonProperty("DataDosingDetailList")]
        public List<DataDosingDetail> DataDosingDetailList { get; set; }

        [JsonProperty("DataGrindingDetailList")]
        public List<DataGrindingDetail> DataGrindingDetailList { get; set; }



        [JsonProperty("InvProductLis")]
        public List<InvProducts> InvProductLis { get; set; }



    }
}