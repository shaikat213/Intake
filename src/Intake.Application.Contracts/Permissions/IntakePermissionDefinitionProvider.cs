using Intake.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Intake.Permissions;

public class IntakePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(IntakePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(IntakePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<IntakeResource>(name);
    }
}
