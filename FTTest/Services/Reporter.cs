using System.Collections.Generic;
using FTTest.Models;

namespace FTTest.Services
{
    class Reporter
    {
        public void ComponentsSearch(List<ReportModel> reports, IzdelModel izdel)
        {
            foreach (var conponent in izdel.Components)
            {
                int level = reports.Find(i => i.Name.Equals(izdel.Name)).Level + 1;
                
                var report = new ReportModel
                {
                    Name = conponent.Izdel.Name,
                    Count = conponent.Count,
                    Cost = conponent.Izdel.Price * conponent.Count,
                    Level = level,
                    ParentName = izdel.Name
                };
                
                reports.Add(report);
                
                var parentName = report.ParentName;
                
                while (parentName != null)
                {
                    reports.Find(r => r.Name == parentName).Cost += report.Cost;
                    parentName = reports.Find(r => r.Name == parentName).ParentName;
                }

                if (conponent.Izdel.Components.Count > 0)
                {
                    ComponentsSearch(reports, conponent.Izdel);
                }
            }
        }

        public List<ReportModel> Generate(List<IzdelModel> izdels)
        {
            List<ReportModel> reports = new List<ReportModel>();

            foreach (var izdel in izdels.FindAll(i => i.Links == null))
            {
                reports.Add(new ReportModel
                {
                    Name = izdel.Name,
                    Count = 1,
                    Cost = izdel.Price,
                    Level = 0
                });

                if (izdel.Components.Count > 0)
                {
                    ComponentsSearch(reports, izdel);
                }
            }

            return reports;
        }
    }
}