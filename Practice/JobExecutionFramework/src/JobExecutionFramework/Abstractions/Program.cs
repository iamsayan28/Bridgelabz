// Concepts to master - OOP, Generics, Exception, Attributes and 3rd party ones

// Generic JobRunner that executes various supported background jobs

// - Accepts the type of request and type of result our job is dealing with.
// - like IJob<InvoiceRequest, InvoiceResult>
interface IJob<TRequest, TResult>
{
    TResult ExecuteJob(TRequest jobRequest);
}