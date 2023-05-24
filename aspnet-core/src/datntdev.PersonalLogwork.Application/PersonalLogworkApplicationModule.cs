using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace datntdev.PersonalLogwork;

[DependsOn(
    typeof(PersonalLogworkDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(PersonalLogworkApplicationContractsModule),
    typeof(AbpIdentityApplicationModule)
)]
public class PersonalLogworkApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<PersonalLogworkApplicationModule>();
        });
    }
}
