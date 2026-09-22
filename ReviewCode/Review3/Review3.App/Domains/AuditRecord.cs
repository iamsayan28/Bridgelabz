public class AuditRecord
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public ProcessingStatus ProcessingStatus { get; set; }
    public string ValidationStatus { get; set; }
    public string DatabaseStatus { get; set; }
    public string Reason { get; set; }
    public DateTime ProcessedAt { get; set; } = DateTime.Now;
}