﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinTask.Services
{
    interface IHttpService
    {
        Task<String> Get(string url);
    }
}
