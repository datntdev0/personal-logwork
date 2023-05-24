using datntdev.PersonalLogwork.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace datntdev.PersonalLogwork.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PersonalLogworkEntityFrameworkCoreModule),
    typeof(PersonalLogworkApplicationContractsModule)
    )]
public class PersonalLogworkDbMigratorModule : AbpModule
{

}
