﻿using Drivers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Contracts
{
    public interface IDriverLicenseRepository : IGenericRepository<DriverLicense>
    {
    }
}