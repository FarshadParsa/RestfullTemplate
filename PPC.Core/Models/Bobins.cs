using PPC.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPC.Core.Models
{
    [Table("Bobins")]
    public class Bobins :IEntity
    {
        #region properties
        [Key]
        [Column("BobinID")]
        public System.Int64 BobinID { get; set; }

        [Column("BobinNo")]
        public System.String BobinNo { get; set; } = string.Empty;

        [Column("BobinCode")]
        public System.String BobinCode { get; set; } = string.Empty;

        //[Column("PlanLotID")]
        //public PlanLotsDL PlanLots_PlanLotID { get; set; }

        //[Column("ProductID")]
        //public ProductDL Product_ProductID { get; set; }

        [Column("Thickness")]
        public System.Byte Thickness { get; set; }

        [Column("Width")]
        public System.Int16 Width { get; set; }

        [Column("Length")]
        public System.Int32 Length { get; set; }

        [Column("Weight")]
        public System.Decimal Weight { get; set; }

        [Column("MetalWeight")]
        public System.Decimal MetalWeight { get; set; }

        [Column("InnerDiameter")]
        public System.Int16 InnerDiameter { get; set; }

        [Column("OuterDiameter")]
        public System.Int16 OuterDiameter { get; set; }

        [Column("Corona")]
        public System.Byte Corona { get; set; }

        [Column("CoatingSide")]
        public System.Byte CoatingSide { get; set; }

        [Column("MetalSide")]
        public System.Byte MetalSide { get; set; }

        [Column("MatteSide")]
        public System.Byte MatteSide { get; set; }

        [Column("AloxSide")]
        public System.Byte AloxSide { get; set; }

        //[Column("OrderDetailID")]
        //public OrderDetailDL OrderDetail_OrderDetailID { get; set; }

        [Column("MotherBobinID")]
        public Bobins Bobins_MotherBobinID { get; set; }

        //[Column("FWMRID")]
        //public FWMotherRollDL FWMotherRoll_FWMRID { get; set; }

        //[Column("SlitterID")]
        //public SlitterDL Slitter_SlitterID { get; set; }

        //[Column("CoatingID")]
        //public CoatingDL Coating_CoatingID { get; set; }

        //[Column("LaminationID")]
        //public LaminationDL Lamination_LaminationID { get; set; }

        //[Column("MetalizeBobinID ")]
        //public MetalizerBobinsDL MetalizerBobins_MetalizeBobinID { get; set; }

        [Column("PaletID")]
        public Palets Palets_PaletID { get; set; }

        //[Column("RevertID")]
        //public RevertDL Revert_RevertID { get; set; }

        [Column("QualityClass")]
        public System.String QualityClass { get; set; } = string.Empty;

        [Column("SlitterStationID")]
        public Stations Station_SlitterStationID { get; set; }

        [Column("CoatingStationID")]
        public Stations Station_CoatingStationID { get; set; }

        [Column("LaminationStationID")]
        public Stations Station_LaminationStationID { get; set; }

        [Column("Status")]
        public System.Byte Status { get; set; }

        [Column("SlitterPreviousStatus")]
        public System.Byte SlitterPreviousStatus { get; set; }

        [Column("MetalizerPreviousStatus")]
        public System.Byte MetalizerPreviousStatus { get; set; }

        [Column("WeightingPreviousStatus")]
        public System.Byte WeightingPreviousStatus { get; set; }

        [Column("PaletizerPreviousStatus")]
        public System.Byte PaletizerPreviousStatus { get; set; }

        [Column("CoatingPreviousStatus")]
        public System.Byte CoatingPreviousStatus { get; set; }

        [Column("LaminationPreviousStatus")]
        public System.Byte LaminationPreviousStatus { get; set; }

        [Column("RevertPreviousStatus")]
        public System.Byte RevertPreviousStatus { get; set; }

        [Column("IsGarbage")]
        public System.Boolean IsGarbage { get; set; }

        [Column("HasPlasma")]
        public System.Boolean HasPlasma { get; set; }

        [Column("QcStatus")]
        public System.Byte QcStatus { get; set; }

        [Column("QcDesc")]
        public System.String QcDesc { get; set; } = string.Empty;

        [Column("NextStationID")]
        public Stations Station_NextStationID { get; set; }

        //[Column("EmptyBobinWeightID")]
        //public EmptyBobinWeightDL EmptyBobinWeight_EmptyBobinWeightID { get; set; }

        //[Column("InvFilmRollID")]
        //public InvFilmRollsDL InvFilmRolls_InvFilmRollID { get; set; }

        [Column("EmptyBobinWidth")]
        public System.Int16 EmptyBobinWidth { get; set; }

        [Column("IsUnknownBobin")]
        public System.Boolean IsUnknownBobin { get; set; }

        [Column("LineNumber")]
        public System.Byte LineNumber { get; set; }

        
        # endregion properties

    }
}
