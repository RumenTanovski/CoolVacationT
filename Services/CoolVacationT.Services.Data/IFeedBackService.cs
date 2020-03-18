using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoolVacationT.Services.Data
{
    public interface IFeedBackService
    {
        Task AddAsync(int rating, string comment);
    }
}
