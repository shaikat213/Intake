using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Intake.Data;

/* This is used if database provider does't define
 * IIntakeDbSchemaMigrator implementation.
 */
public class NullIntakeDbSchemaMigrator : IIntakeDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
