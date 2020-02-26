using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Transactions;
using Vertical.EntityFrameworkCore.Seed.Host;

namespace Vertical.EntityFrameworkCore.Seed
{
    public static class SeedHelper
    {
        public static void SeedHostDb(IIocResolver iocResolver)
        {
            WithDbContext<VerticalZeroDbContext>(iocResolver, SeedHostDb);
        }

        public static void SeedHostDb(VerticalZeroDbContext context)
        {
            context.SuppressAutoSetTenantId = true;

            // Host seed
            new HostInitialDbBuilder(context).Create();

            // Default tenant seed (in host database).
            new DefaultTenatInitialDbBuilder(context).Create();
        }

        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
            where TDbContext : DbContext
        {
            using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                    contextAction(context);

                    uow.Complete();
                }
            }
        }
    }
}
