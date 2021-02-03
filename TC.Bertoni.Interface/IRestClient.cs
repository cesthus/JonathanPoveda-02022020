using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC.Bertoni.Interface
{
    public interface IRestClient
    {
        Task<T> GetAsync<T>(string url);
        Task<List<T>> GetListAsync<T>(string url);
    }
}
