﻿using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
namespace PPC.Response.DTOs
{
    public class CustomerGradesDTO
    {

        #region Base properties and methods(generated by  CodeGenerator)
        [JsonProperty("CustomerGradeID")]
        public System.Int16 CustomerGradeID { get; set; }

        [JsonProperty("CustomerGradeName")]
        public string CustomerGradeName { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; } = true;

        #endregion Base properties and methods(generated by  CodeGenerator)


    }
}
