using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TemperatureAndVolumeConversion.Models
{
    public class CheckConversion
    {
        [Display(Name = "Input Numerical Value")]
        public double InputNumericalValue { get; set; }
        [Display(Name = "Input Unit Of Measure")]
        public string InputUnitOfMeasure { get; set; }
        [Display(Name = "Target Unit Of Measure")]
        public string TargetUnitOfMeasure { get; set; }
        [Display(Name = "Student Response")]
        public double StudentResponse { get; set; }
        public string Output { get; set; }
    }
}