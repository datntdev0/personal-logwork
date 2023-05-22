using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace datntdev.PersonalLogwork.Themes
{
    [ThemeName(Name)]
    public class DefaultTheme : ITheme, ITransientDependency
    {
        public const string Name = "Default";

        public virtual string GetLayout(string name, bool fallbackToDefault = true)
        {
            switch (name)
            {
                case StandardLayouts.Account:
                    return "~/Themes/Default/Layouts/Account.cshtml";
                default:
                    return fallbackToDefault ? "~/Themes/Default/Layouts/Account.cshtml" : null;
            }
        }
    }
}
