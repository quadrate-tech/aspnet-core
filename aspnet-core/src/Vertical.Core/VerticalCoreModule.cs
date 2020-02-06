using Abp.AspNetCore;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Vertical
{
    [DependsOn(
         typeof(AbpAspNetCoreModule),
         typeof(AbpAutoMapperModule)
     )]
    public class VerticalCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;
            Configuration.MultiTenancy.IsEnabled = VerticalConsts.MultiTenancyEnabled;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VerticalCoreModule).GetAssembly());
        }
    }
}
