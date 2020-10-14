using CarChecker.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarChecker.Client.Data
{
    public interface IVehicleReportOpener
    {
        void OpenReport(Vehicle vehicle);
    }
}
