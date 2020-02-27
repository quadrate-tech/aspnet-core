using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Configuration;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Vertical.EntityFrameworkCore.Seed.Host
{
    public class DefaultSettingsCreator
    {
        private readonly VerticalZeroDbContext _context;

        public DefaultSettingsCreator(VerticalZeroDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            int? tenantId = null;

            if (VerticalConsts.MultiTenancyEnabled == false)
            {
                tenantId = MultiTenancyConsts.DefaultTenantId;
            }

            // Languages
            AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "en", tenantId);
        }

        private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
        {
            if (_context.Settings.IgnoreQueryFilters().Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
            {
                return;
            }

            _context.Settings.Add(new Setting(tenantId, null, name, value));
            _context.SaveChanges();
        }
    }
}
