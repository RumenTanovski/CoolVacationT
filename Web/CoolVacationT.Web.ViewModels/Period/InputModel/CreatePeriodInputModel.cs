namespace CoolVacationT.Web.ViewModels.Period.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CoolVacationT.Data.Models;
    using CoolVacationT.Services.Mapping;

    public class CreatePeriodInputModel : IMapTo<Period>
    {
        public DateTime ArrivalDate { get; set; }

        public DateTime DepartDate { get; set; }
    }
}
