using System.Threading.Tasks;

namespace datntdev.PersonalLogwork.Data;

public interface IPersonalLogworkDbSchemaMigrator
{
    Task MigrateAsync();
}
