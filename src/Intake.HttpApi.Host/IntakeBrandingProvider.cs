using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Intake;

[Dependency(ReplaceServices = true)]
public class IntakeBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Intake";
}
