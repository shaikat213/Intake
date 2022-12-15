using Volo.Abp.Settings;

namespace Intake.Settings;

public class IntakeSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(IntakeSettings.MySetting1));
    }
}
