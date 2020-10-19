using CarChecker.Components.Data;
using CarChecker.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CarChecker
{
    public class DesktopVehicleReportOpener : IVehicleReportOpener
    {
        public void OpenReport(Vehicle vehicle)
        {
            var reportText = GenerateReportAsString(vehicle);

            var path = Path.GetTempFileName() + ".txt";
            File.WriteAllText(path, reportText);

            Process.Start(new ProcessStartInfo { FileName = path, UseShellExecute = true });
        }

        private static string GenerateReportAsString(Vehicle vehicle)
        {
            var report = new StringBuilder();
            report.AppendLine("VEHICLE REPORT");
            report.AppendLine();
            report.AppendLine($"Vehicle: {vehicle.Make} {vehicle.Model} ({vehicle.RegistrationDate.Year})");
            report.AppendLine();
            report.AppendLine($"Mileage: {vehicle.Mileage}");
            report.AppendLine($"Fuel tank level: {vehicle.Tank}");
            report.AppendLine();

            foreach (var note in vehicle.Notes)
            {
                report.AppendLine($"NOTE: {note.Location}");
                report.AppendLine(note.Text);
                report.AppendLine();
            }

            return report.ToString();
        }
    }
}
