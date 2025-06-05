
namespace DataPipeline.Models.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbAppContext
    {
        private readonly DbAppContext _appContext;

        public UnitOfWork(DbAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task CompleteAsync()
        {
            await _appContext.SaveChangesAsync();
        }
    }
}
