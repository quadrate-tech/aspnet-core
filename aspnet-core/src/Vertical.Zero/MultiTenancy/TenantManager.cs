using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using System;
using System.Threading.Tasks;
using Vertical.Application.Editions;
using Vertical.Authorization.Users;

namespace Vertical.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }

        internal Task<Tenant> GetByIdAsync(int v)
        {
            throw new NotImplementedException();
        }
    }
}
