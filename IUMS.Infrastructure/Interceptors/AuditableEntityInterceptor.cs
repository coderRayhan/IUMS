using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Abstractions.Domain;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using static AspNetCoreHero.Boilerplate.Application.Constants.Permissions;

namespace IUMS.Infrastructure.Interceptors
{
	public class AuditableEntityInterceptor : SaveChangesInterceptor
	{
		private readonly IAuthenticatedUserService _authenticateUser;
		private readonly IDateTimeService _dateTime;
		public AuditableEntityInterceptor(IAuthenticatedUserService authenticateUser, IDateTimeService dateTime) 
		{
			_authenticateUser = authenticateUser;
			_dateTime = dateTime;
		}

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = _authenticateUser.UserId;
                    entry.Entity.CreatedOn = _dateTime.NowUtc;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
                {
                    entry.Entity.LastModifiedBy = _authenticateUser.UserId;
                    entry.Entity.LastModifiedOn = _dateTime.NowUtc;
                }
            }
        }
    }

    public static class Extensions
    {
        public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
            entry.References.Any(r =>
                r.TargetEntry != null &&
                r.TargetEntry.Metadata.IsOwned() &&
                (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
    }
}

