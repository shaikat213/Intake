using Volo.Abp.Modularity;

namespace Intake;

[DependsOn(
    typeof(IntakeApplicationModule),
    typeof(IntakeDomainTestModule)
    )]
public class IntakeApplicationTestModule : AbpModule
{

}
