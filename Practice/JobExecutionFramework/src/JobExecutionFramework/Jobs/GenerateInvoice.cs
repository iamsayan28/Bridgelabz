using System;
using System.Collections.Generic;
using System.Text;

namespace JobExecutionFramework.src.JobExecutionFramework.Jobs
{
    internal class GenerateInvoice : IJob<InvoiceRequest, InvoiceResult>
    {
        public GenerateInvoice()
        { }

        public InvoiceResult ExecuteJob(InvoiceRequest jobRequest)
        {
            
        }
    }
}
