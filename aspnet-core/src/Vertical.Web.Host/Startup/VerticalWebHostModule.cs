using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Vertical.Web.Startup
{
    [DependsOn(typeof(VerticalWebCoreModule))]
    public class VerticalWebHostModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VerticalWebHostModule).GetAssembly());
        }
    }
}
