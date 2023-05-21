using Volo.Abp.Modularity;

namespace datntdev.PersonalLogwork;

[DependsOn(
    typeof(PersonalLogworkApplicationModule),
    typeof(PersonalLogworkDomainTestModule)
    )]
public class PersonalLogworkApplicationTestModule : AbpModule
{

}
