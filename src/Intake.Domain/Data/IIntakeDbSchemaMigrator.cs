using System.Threading.Tasks;

namespace Intake.Data;

public interface IIntakeDbSchemaMigrator
{
    Task MigrateAsync();
}
