﻿using Localization.Resources.AbpUi;
using datntdev.PersonalLogwork.Localization;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;

namespace datntdev.PersonalLogwork;

[DependsOn(
    typeof(PersonalLogworkApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule)
)]
public class PersonalLogworkHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<PersonalLogworkResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
