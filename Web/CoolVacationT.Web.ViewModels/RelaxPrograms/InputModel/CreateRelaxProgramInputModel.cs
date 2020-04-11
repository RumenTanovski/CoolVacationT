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
        [StringLength(50)]
        public string EcoTrail { get; set; }

        [StringLength(50)]
        public string Party { get; set; }

        [StringLength(50)]
        public string SwimmingPool { get; set; }
    }
}
