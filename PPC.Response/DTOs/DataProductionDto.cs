using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Response.DTOs
{
    public class DataProductionDTO
    {

        #region Base properties
        [JsonProperty("DataProductionID")]
        public int DataProductionID { get; set; }

        [JsonProperty("ProductionPlanPatilID")]
        public int ProductionPlanPatilID { get; set; }

        [JsonProperty("StartDate")]
        public string StartDate { get; set; }

        [JsonProperty("StartTime")]
        public string StartTime { get; set; }

        [JsonProperty("EndDate")]
        public string EndDate { get; set; }

        [JsonProperty("EndTime")]
        public string EndTime { get; set; }

        [JsonProperty("Duration")]
        public int Duration { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }

        [JsonProperty("PatilID")]
        public int PatilID { get; set; }

        [JsonProperty("Patil_Capacity")]
        public short Patil_Capacity { get; set; }

        [JsonProperty("Patil_EmptyWeight")]
        public decimal Patil_EmptyWeight { get; set; }

        [JsonProperty("Patil_AfterChargeWeight")]
        public decimal Patil_AfterChargeWeight { get; set; }

        [JsonProperty("Patil_AfterFirstMixWeight")]
        public decimal? Patil_AfterFirstMixWeight { get; set; }

        [JsonProperty("Patil_DuringGrindingWeight")]
        public decimal? Patil_DuringGrindingWeight { get; set; }

        [JsonProperty("Patil_FinalWeight")]
        public decimal Patil_FinalWeight { get; set; }

        [JsonProperty("Patil_NetWeight")]
        public decimal Patil_NetWeight { get; set; }

        [JsonProperty("Patil_MaterialEvaporation")]
        public decimal? Patil_MaterialEvaporation { get; set; }

        [JsonProperty("Patil_Wastes")]
        public decimal? Patil_Wastes { get; set; }

        [JsonProperty("Patil_Describe")]
        public string Patil_Describe { get; set; }


        //[JsonProperty("Dosing_StartDate")]
        //public string Dosing_StartDate { get; set; }

        //[JsonProperty("Dosing_StartTime")]
        //public string Dosing_StartTime { get; set; }

        //[JsonProperty("Dosing_EndDate")]
        //public string Dosing_EndDate { get; set; }

        //[JsonProperty("Dosing_EndTime")]
        //public string Dosing_EndTime { get; set; }

        //[JsonProperty("Dosing_Duration")]
        //public short? Dosing_Duration { get; set; }

        //[JsonProperty("Dosing_WeighbridgeNo")]
        //public byte? Dosing_WeighbridgeNo { get; set; }

        //[JsonProperty("Dosing_ShiftNo")]
        //public string Dosing_ShiftNo { get; set; }

        //[JsonProperty("Dosing_Operators")]
        //public string Dosing_Operators { get; set; }

        //[JsonProperty("Dosing_Wastes")]
        //public decimal? Dosing_Wastes { get; set; }

        //[JsonProperty("Dosing_Stopes")]
        //public short? Dosing_Stopes { get; set; }

        //[JsonProperty("Dosing_StopesDesc")]
        //public string Dosing_StopesDesc { get; set; }

        //[JsonProperty("Dosing_Describe")]
        //public string Dosing_Describe { get; set; }



        [JsonProperty("Dosing1_StartDate")]
        public string Dosing1_StartDate { get; set; }

        [JsonProperty("Dosing1_StartTime")]
        public string Dosing1_StartTime { get; set; }

        [JsonProperty("Dosing1_EndDate")]
        public string Dosing1_EndDate { get; set; }

        [JsonProperty("Dosing1_EndTime")]
        public string Dosing1_EndTime { get; set; }

        [JsonProperty("Dosing1_Duration")]
        public short? Dosing1_Duration { get; set; }

        [JsonProperty("Dosing1_WeighbridgeNo")]
        public byte? Dosing1_WeighbridgeNo { get; set; }

        [JsonProperty("Dosing1_ShiftNo")]
        public string Dosing1_ShiftNo { get; set; }

        [JsonProperty("Dosing1_Operators")]
        public string Dosing1_Operators { get; set; }

        [JsonProperty("Dosing1_Wastes")]
        public decimal? Dosing1_Wastes { get; set; }

        [JsonProperty("Dosing1_Stopes")]
        public short? Dosing1_Stopes { get; set; }

        [JsonProperty("Dosing1_StopesDesc")]
        public string Dosing1_StopesDesc { get; set; }

        [JsonProperty("Dosing1_Describe")]
        public string Dosing1_Describe { get; set; }


        [JsonProperty("Dosing2_StartDate")]
        public string Dosing2_StartDate { get; set; }

        [JsonProperty("Dosing2_StartTime")]
        public string Dosing2_StartTime { get; set; }

        [JsonProperty("Dosing2_EndDate")]
        public string Dosing2_EndDate { get; set; }

        [JsonProperty("Dosing2_EndTime")]
        public string Dosing2_EndTime { get; set; }

        [JsonProperty("Dosing2_Duration")]
        public short? Dosing2_Duration { get; set; }

        [JsonProperty("Dosing2_WeighbridgeNo")]
        public byte? Dosing2_WeighbridgeNo { get; set; }

        [JsonProperty("Dosing2_ShiftNo")]
        public string Dosing2_ShiftNo { get; set; }

        [JsonProperty("Dosing2_Operators")]
        public string Dosing2_Operators { get; set; }

        [JsonProperty("Dosing2_Wastes")]
        public decimal? Dosing2_Wastes { get; set; }

        [JsonProperty("Dosing2_Stopes")]
        public short? Dosing2_Stopes { get; set; }

        [JsonProperty("Dosing2_StopesDesc")]
        public string Dosing2_StopesDesc { get; set; }

        [JsonProperty("Dosing2_Describe")]
        public string Dosing2_Describe { get; set; }


        [JsonProperty("Dosing3_StartDate")]
        public string Dosing3_StartDate { get; set; }

        [JsonProperty("Dosing3_StartTime")]
        public string Dosing3_StartTime { get; set; }

        [JsonProperty("Dosing3_EndDate")]
        public string Dosing3_EndDate { get; set; }

        [JsonProperty("Dosing3_EndTime")]
        public string Dosing3_EndTime { get; set; }

        [JsonProperty("Dosing3_Duration")]
        public short? Dosing3_Duration { get; set; }

        [JsonProperty("Dosing3_WeighbridgeNo")]
        public byte? Dosing3_WeighbridgeNo { get; set; }

        [JsonProperty("Dosing3_ShiftNo")]
        public string Dosing3_ShiftNo { get; set; }

        [JsonProperty("Dosing3_Operators")]
        public string Dosing3_Operators { get; set; }

        [JsonProperty("Dosing3_Wastes")]
        public decimal? Dosing3_Wastes { get; set; }

        [JsonProperty("Dosing3_Stopes")]
        public short? Dosing3_Stopes { get; set; }

        [JsonProperty("Dosing3_StopesDesc")]
        public string Dosing3_StopesDesc { get; set; }

        [JsonProperty("Dosing3_Describe")]
        public string Dosing3_Describe { get; set; }

        [JsonProperty("Dosing4_StartDate")]
        public string Dosing4_StartDate { get; set; }

        [JsonProperty("Dosing4_StartTime")]
        public string Dosing4_StartTime { get; set; }

        [JsonProperty("Dosing4_EndDate")]
        public string Dosing4_EndDate { get; set; }

        [JsonProperty("Dosing4_EndTime")]
        public string Dosing4_EndTime { get; set; }

        [JsonProperty("Dosing4_Duration")]
        public short? Dosing4_Duration { get; set; }

        [JsonProperty("Dosing4_WeighbridgeNo")]
        public byte? Dosing4_WeighbridgeNo { get; set; }

        [JsonProperty("Dosing4_ShiftNo")]
        public string Dosing4_ShiftNo { get; set; }

        [JsonProperty("Dosing4_Operators")]
        public string Dosing4_Operators { get; set; }

        [JsonProperty("Dosing4_Wastes")]
        public decimal? Dosing4_Wastes { get; set; }

        [JsonProperty("Dosing4_Stopes")]
        public short? Dosing4_Stopes { get; set; }

        [JsonProperty("Dosing4_StopesDesc")]
        public string Dosing4_StopesDesc { get; set; }

        [JsonProperty("Dosing4_Describe")]
        public string Dosing4_Describe { get; set; }



        [JsonProperty("Mixer_StationID")]
        public int? Mixer_StationID { get; set; }

        [JsonProperty("Mixer_StartDate")]
        public string Mixer_StartDate { get; set; }

        [JsonProperty("Mixer_StartTime")]
        public string Mixer_StartTime { get; set; }

        [JsonProperty("Mixer_EndDate")]
        public string Mixer_EndDate { get; set; }

        [JsonProperty("Mixer_EndTime")]
        public string Mixer_EndTime { get; set; }

        [JsonProperty("Mixer_Duration")]
        public short? Mixer_Duration { get; set; }

        [JsonProperty("Mixer_ShiftNo")]
        public string Mixer_ShiftNo { get; set; }

        [JsonProperty("Mixer_Operators")]
        public string Mixer_Operators { get; set; }

        [JsonProperty("Mixer_Wastes")]
        public decimal? Mixer_Wastes { get; set; }

        [JsonProperty("Mixer_Stopes")]
        public short? Mixer_Stopes { get; set; }

        [JsonProperty("Mixer_StopesDesc")]
        public string Mixer_StopesDesc { get; set; }

        [JsonProperty("Mixer_StationSpeed")]
        public short? Mixer_StationSpeed { get; set; }

        [JsonProperty("Mixer_Describe")]
        public string Mixer_Describe { get; set; }

        [JsonProperty("Reactor_StationID")]
        public int? Reactor_StationID { get; set; }

        [JsonProperty("Reactor_StartDate")]
        public string Reactor_StartDate { get; set; }

        [JsonProperty("Reactor_StartTime")]
        public string Reactor_StartTime { get; set; }

        [JsonProperty("Reactor_EndDate")]
        public string Reactor_EndDate { get; set; }

        [JsonProperty("Reactor_EndTime")]
        public string Reactor_EndTime { get; set; }

        [JsonProperty("Reactor_Duration")]
        public short? Reactor_Duration { get; set; }

        [JsonProperty("Reactor_ShiftNo")]
        public string Reactor_ShiftNo { get; set; }

        [JsonProperty("Reactor_Operators")]
        public string Reactor_Operators { get; set; }

        [JsonProperty("Reactor_Wastes")]
        public decimal? Reactor_Wastes { get; set; }

        [JsonProperty("Reactor_Stopes")]
        public short? Reactor_Stopes { get; set; }

        [JsonProperty("Reactor_StopesDesc")]
        public string Reactor_StopesDesc { get; set; }

        [JsonProperty("Reactor_MixerSpeed")]
        public short? Reactor_MixerSpeed { get; set; }

        [JsonProperty("Reactor_Temperature")]
        public decimal? Reactor_Temperature { get; set; }

        [JsonProperty("Reactor_MaterialTemperature")]
        public decimal? Reactor_MaterialTemperature { get; set; }

        [JsonProperty("Reactor_Describe")]
        public string Reactor_Describe { get; set; }

        [JsonProperty("Premix_StationID")]
        public int? Premix_StationID { get; set; }

        [JsonProperty("Premix_StartDate")]
        public string Premix_StartDate { get; set; }

        [JsonProperty("Premix_StartTime")]
        public string Premix_StartTime { get; set; }

        [JsonProperty("Premix_EndDate")]
        public string Premix_EndDate { get; set; }

        [JsonProperty("Premix_EndTime")]
        public string Premix_EndTime { get; set; }

        [JsonProperty("Premix_Duration")]
        public short? Premix_Duration { get; set; }

        [JsonProperty("Premix_ShiftNo")]
        public string Premix_ShiftNo { get; set; }

        [JsonProperty("Premix_Operators")]
        public string Premix_Operators { get; set; }

        [JsonProperty("Premix_Wastes")]
        public decimal? Premix_Wastes { get; set; }

        [JsonProperty("Premix_Stopes")]
        public short? Premix_Stopes { get; set; }

        [JsonProperty("Premix_StopesDesc")]
        public string Premix_StopesDesc { get; set; }

        [JsonProperty("Premix_StationSpeed")]
        public short? Premix_StationSpeed { get; set; }

        [JsonProperty("Premix_Describe")]
        public string Premix_Describe { get; set; }

        [JsonProperty("Grinding_StationID")]
        public int? Grinding_StationID { get; set; }

        [JsonProperty("Grinding_StartDate")]
        public string Grinding_StartDate { get; set; }

        [JsonProperty("Grinding_StartTime")]
        public string Grinding_StartTime { get; set; }

        [JsonProperty("Grinding_EndDate")]
        public string Grinding_EndDate { get; set; }

        [JsonProperty("Grinding_EndTime")]
        public string Grinding_EndTime { get; set; }

        [JsonProperty("Grinding_Duration")]
        public short? Grinding_Duration { get; set; }

        [JsonProperty("Grinding_ShiftNo")]
        public string Grinding_ShiftNo { get; set; }

        [JsonProperty("Grinding_Operators")]
        public string Grinding_Operators { get; set; }

        [JsonProperty("Grinding_Stopes")]
        public short? Grinding_Stopes { get; set; }

        [JsonProperty("Grinding_StopesDesc")]
        public string Grinding_StopesDesc { get; set; }

        [JsonProperty("Grinding_StationSpeed")]
        public short? Grinding_StationSpeed { get; set; }

        [JsonProperty("Grinding_Describe")]
        public string Grinding_Describe { get; set; }

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

        [JsonProperty("RowVer")]
        public byte[] RowVer { get; set; }

        #endregion Base properties


        [JsonProperty("ProductionPlanPatil")]
        public ProductionPlanPatilsDTO ProductionPlanPatil { get; set; }

        [JsonProperty("Patil")]
        public PatilsDTO Patil { get; set; }

        [JsonProperty("Premix_Station")]
        public StationsDTO Premix_Station { get; set; }

        [JsonProperty("Grinding_Station")]
        public StationsDTO Grinding_Station { get; set; }

        [JsonProperty("User_InsUser")]
        public UsersDTO User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        public UsersDTO User_EditUser { get; set; }



        [JsonProperty("DataDosingDetailList")]
        public List<DataDosingDetailDTO> DataDosingDetailList { get; set; }

        [JsonProperty("DataGrindingDetailList")]
        public List<DataGrindingDetailDTO> DataGrindingDetailList { get; set; }



    }
}