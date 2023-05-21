using datntdev.PersonalLogwork.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace datntdev.PersonalLogwork.Permissions;

public class PersonalLogworkPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PersonalLogworkPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(PersonalLogworkPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PersonalLogworkResource>(name);
    }
}
