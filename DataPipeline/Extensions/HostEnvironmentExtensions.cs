namespace DataPipeline.Extensions
{
    public static class HostEnvironmentExtensions
    {
        public static bool IsDevOrStaging(this WebApplication app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            return app.Environment.IsDevelopment() || app.Environment.IsStaging();
        }
    }
}
