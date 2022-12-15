using Intake.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Intake.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(IntakeEntityFrameworkCoreModule),
    typeof(IntakeApplicationContractsModule)
    )]
public class IntakeDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
