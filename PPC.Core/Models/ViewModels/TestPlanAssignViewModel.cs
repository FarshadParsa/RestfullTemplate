using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Models
{
    public class TestPlanAssignViewModel
    {
        [JsonProperty("TestPlanAssign_TestPlanAssignID")]
        public int? TestPlanAssign_TestPlanAssignID { get; set; }

        [JsonProperty("TestPlanAssign_MaterialTypeID")]
        public byte? TestPlanAssign_MaterialTypeID { get; set; }

        [JsonProperty("TestPlanAssign_ProductID")]
        public int? TestPlanAssign_ProductID { get; set; }

        [JsonProperty("TestPlanAssign_RawMaterialGroupTypeID")]
        public short? TestPlanAssign_RawMaterialGroupTypeID { get; set; }

        [JsonProperty("TestPlanAssign_TestPlanID")]
        public int? TestPlanAssign_TestPlanID { get; set; }

        [JsonProperty("TestPlanAssign_TestPlanAssignedCode")]
        public string TestPlanAssign_TestPlanAssignedCode { get; set; }

        [JsonProperty("TestPlanAssign_AssignedCodeNum")]
        public short? TestPlanAssign_AssignedCodeNum { get; set; }

        [JsonProperty("TestPlanAssign_Version")]
        public short? TestPlanAssign_Version { get; set; }

        [JsonProperty("TestPlanAssign_InsSysTime")]
        public DateTime? TestPlanAssign_InsSysTime { get; set; }

        [JsonProperty("TestPlanAssign_InsUserID")]
        public int? TestPlanAssign_InsUserID { get; set; }

        [JsonProperty("TestPlanAssign_InsUserName")]
        public string TestPlanAssign_InsUserName { get; set; }

        [JsonProperty("TestPlanAssign_InsUserFullName")]
        public string TestPlanAssign_InsUserFullName { get; set; }

        [JsonProperty("TestPlanAssign_InsDate")]
        public string TestPlanAssign_InsDate { get; set; }

        [JsonProperty("TestPlanAssign_InsTime")]
        public string TestPlanAssign_InsTime { get; set; }
        [JsonProperty("TestPlanAssign_EditUserID")]
        public int? TestPlanAssign_EditUserID { get; set; }
        [JsonProperty("TestPlanAssign_EditUserName")]
        public string TestPlanAssign_EditUserName { get; set; }
        [JsonProperty("TestPlanAssign_EditUserFullName")]
        public string TestPlanAssign_EditUserFullName { get; set; }
        [JsonProperty("TestPlanAssign_EditDate")]
        public string TestPlanAssign_EditDate { get; set; }
        [JsonProperty("TestPlanAssign_EditTime")]
        public string TestPlanAssign_EditTime { get; set; }
        [JsonProperty("TestPlanAssign_IsActive")]
        public bool? TestPlanAssign_IsActive { get; set; }

        [JsonProperty("TestPlan_TestPlanID")]
        public int? TestPlan_TestPlanID { get; set; }

        [JsonProperty("TestPlan_MaterialTypeID")]
        public byte? TestPlan_MaterialTypeID { get; set; }

        [JsonProperty("TestPlan_TestPlanMCode")]
        public string TestPlan_TestPlanMCode { get; set; }

        [JsonProperty("TestPlan_TestPlanCode")]
        public string TestPlan_TestPlanCode { get; set; }

        [JsonProperty("TestPlan_TestPlanCodeChar")]
        public string TestPlan_TestPlanCodeChar { get; set; }

        [JsonProperty("TestPlan_TestPlanCodeNum")]
        public string TestPlan_TestPlanCodeNum { get; set; }

        [JsonProperty("TestPlan_TestPlanCodeSeri")]
        public string TestPlan_TestPlanCodeSeri { get; set; }

        [JsonProperty("TestPlan_TestPlanCodeVersion")]
        public string TestPlan_TestPlanCodeVersion { get; set; }

        [JsonProperty("TestPlan_Version")]
        public short? TestPlan_Version { get; set; }

        [JsonProperty("TestPlanGroup_TestPlanGroupID")]
        public int? TestPlanGroup_TestPlanGroupID { get; set; }

        [JsonProperty("TestPlanGroup_TestPlanGroupCode")]
        public string TestPlanGroup_TestPlanGroupCode { get; set; }

        [JsonProperty("TestPlanGroup_TestPlanGroupName")]
        public string TestPlanGroup_TestPlanGroupName { get; set; }

        [JsonProperty("TestPlanGroup_TestPlanGroupSign")]
        public string TestPlanGroup_TestPlanGroupSign { get; set; }

        [JsonProperty("ProductGroupType_ProductGroupTypeName")]
        public string ProductGroupType_ProductGroupTypeName { get; set; }

        [JsonProperty("RawMaterialGroupType_RawMaterialGroupTypeName")]
        public string RawMaterialGroupType_RawMaterialGroupTypeName { get; set; }

    }
}
