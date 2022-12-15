using System;
using System.Collections.Generic;
using System.Text;
using Intake.Localization;
using Volo.Abp.Application.Services;

namespace Intake;

/* Inherit your application services from this class.
 */
public abstract class IntakeAppService : ApplicationService
{
    protected IntakeAppService()
    {
        LocalizationResource = typeof(IntakeResource);
    }
}
