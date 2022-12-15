using Intake.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Intake.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class IntakeController : AbpControllerBase
{
    protected IntakeController()
    {
        LocalizationResource = typeof(IntakeResource);
    }
}
