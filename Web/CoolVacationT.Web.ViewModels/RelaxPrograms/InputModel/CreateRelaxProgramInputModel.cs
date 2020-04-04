namespace CoolVacationT.Web.ViewModels.RelaxPrograms.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class CreateRelaxProgramInputModel : IMapTo<RelaxProgram>
    {
        public string EcoTrail { get; set; }

        public string Party { get; set; }

        public string SwimmingPool { get; set; }
    }
}
