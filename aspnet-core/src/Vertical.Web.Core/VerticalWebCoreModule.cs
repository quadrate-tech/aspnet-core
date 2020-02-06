using Abp.AspNetCore;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Vertical.Configuration;

namespace Vertical.Web
{
    [DependsOn(
         typeof(AbpAspNetCoreSignalRModule),
         typeof(VerticalZeroModule)
     )]
    public class VerticalWebCoreModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public VerticalWebCoreModule(IWebHostEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                VerticalConsts.ConnectionStringName
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VerticalWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(VerticalWebCoreModule).Assembly);
        }
    }
}
