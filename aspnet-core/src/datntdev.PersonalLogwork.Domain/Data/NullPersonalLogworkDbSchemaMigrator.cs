using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace datntdev.PersonalLogwork.Data;

/* This is used if database provider does't define
 * IPersonalLogworkDbSchemaMigrator implementation.
 */
public class NullPersonalLogworkDbSchemaMigrator : IPersonalLogworkDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
