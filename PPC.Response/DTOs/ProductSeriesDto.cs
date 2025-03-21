﻿using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class ProductSeriesDTO
    {

        #region Base properties and methods(generated by  CodeGenerator)
        [JsonProperty("ProductSerieID")]
        public int ProductSerieID { get; set; }

        [JsonProperty("ProductSerieName")]
        public string ProductSerieName { get; set; }

        [JsonProperty("ProductTypeID")]
        public short ProductTypeID { get; set; }

        [JsonProperty("ProductSerieLabelName")]
        public string ProductSerieLabelName { get; set; }

        [JsonProperty("ProductSerieLatinLabelName")]
        public string ProductSerieLatinLabelName { get; set; }

        [JsonProperty("Usages")]
        public string Usages { get; set; }

        [JsonProperty("BOMSerialCode")]
        public string BOMSerialCode { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
        #endregion Base properties and methods(generated by  CodeGenerator)


        [JsonProperty("ProductType")]
        public ProductTypesDTO ProductType { get; set; }

        //[JsonProperty("PrintingTechniques")]
        //public List<PrintingTechniquesDTO> PrintingTechniques { get; set; }

        [JsonProperty("ProductSerieTechniqueList")]
        public List<ProductSerieTechniqueAssignsDTO> ProductSerieTechniqueList { get; set; }


    }
}
