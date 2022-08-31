using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Questionnaire.Infrastructure.Database;

namespace Questionnaire.Infrastructure.DatabaseServices
{
    public class MigrationService : IHostedService
    {
        private readonly IServiceProvider _service;

        public MigrationService(IServiceProvider service)
        {
            _service = service;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _service.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<QuestionnaireContext>();
            await context.Database.MigrateAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
