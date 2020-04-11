namespace CoolVacationT.Web.ViewModels.RelaxPrograms.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class CreateRelaxProgramInputModel : IMapTo<RelaxProgram>
    {
        //50
        [StringLength(10)]
        public string EcoTrail { get; set; }

        [StringLength(10)]
        public string Party { get; set; }

        [StringLength(10)]
        public string SwimmingPool { get; set; }
    }
}
