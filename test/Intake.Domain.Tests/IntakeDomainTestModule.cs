using Intake.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Intake;

[DependsOn(
    typeof(IntakeEntityFrameworkCoreTestModule)
    )]
public class IntakeDomainTestModule : AbpModule
{

}
