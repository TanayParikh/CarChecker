using CarChecker.Client.Data;
using CarChecker.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarChecker.Client
{
    public class VehicleReportOpener : IVehicleReportOpener
    {
        public void OpenReport(Vehicle vehicle)
        {
            throw new PlatformNotSupportedException();
        }
    }
}
