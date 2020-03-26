namespace CoolVacationT.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFeedBackService
    {
        Task<string> AddAsync(int rating, string comment, string id);
    }
}
