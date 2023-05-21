using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace datntdev.PersonalLogwork;

[Dependency(ReplaceServices = true)]
public class PersonalLogworkBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "PersonalLogwork";
}
