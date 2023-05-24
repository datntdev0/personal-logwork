using datntdev.PersonalLogwork.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace datntdev.PersonalLogwork.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PersonalLogworkController : AbpControllerBase
{
    protected PersonalLogworkController()
    {
        LocalizationResource = typeof(PersonalLogworkResource);
    }
}
