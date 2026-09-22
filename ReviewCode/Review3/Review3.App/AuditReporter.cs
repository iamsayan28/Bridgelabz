using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
public class AuditReporter
{
    public void ExportReport(IEnumerable<AuditRecord> records, string exportPath)
    {
        using (var writer = new StreamWriter(exportPath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(records);
        }
    }
}