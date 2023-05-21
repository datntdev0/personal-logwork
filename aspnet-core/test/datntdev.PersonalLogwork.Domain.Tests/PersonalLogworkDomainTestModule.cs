using datntdev.PersonalLogwork.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace datntdev.PersonalLogwork;

[DependsOn(
    typeof(PersonalLogworkEntityFrameworkCoreTestModule)
    )]
public class PersonalLogworkDomainTestModule : AbpModule
{

}
