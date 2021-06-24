using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinTask.Services
{
    interface IHttpService<T>
    {
        Task<List<T>> Get(string url);
    }
}
