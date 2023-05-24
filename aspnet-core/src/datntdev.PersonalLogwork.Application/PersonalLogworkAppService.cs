using System;
using System.Collections.Generic;
using System.Text;
using datntdev.PersonalLogwork.Localization;
using Volo.Abp.Application.Services;

namespace datntdev.PersonalLogwork;

/* Inherit your application services from this class.
 */
public abstract class PersonalLogworkAppService : ApplicationService
{
    protected PersonalLogworkAppService()
    {
        LocalizationResource = typeof(PersonalLogworkResource);
    }
}
