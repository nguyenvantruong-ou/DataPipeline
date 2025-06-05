namespace DataPipeline.Models.UnitOfWork
{
    public interface IUnitOfWork<TContext>
    {
        Task CompleteAsync();
    }
}
