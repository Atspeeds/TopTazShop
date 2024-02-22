using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TopTaz.Domain.BasketAgg;
using TopTaz.Domain.CatalogAgg;

namespace TopTaz.Infrastrure
{
    public class EntityStateHelper
    {
        private readonly DbContext _context;

        public EntityStateHelper(DbContext context)
        {
            _context = context;
        }
       

        public void TrackAndModifyEntities()
        {
            var stateTracker = _context.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted);

            foreach (var item in stateTracker)
            {
                var entityTyp = item.Context.Model.FindEntityType(item.Entity.GetType());

                if (item.State == EntityState.Added)
                {
                    SetCreationDate(item, entityTyp);
                }
                if (item.State == EntityState.Modified)
                {
                    SetModifiedDate(item, entityTyp);
                }
                if (item.State == EntityState.Deleted)
                {
                    SetDeletedDate(item, entityTyp);
                }
                
            }
        }

        private void SetCreationDate(EntityEntry item, IEntityType entityTyp)
        {
            var insertType = entityTyp.FindProperty("CreatedOn");
            if (insertType != null)
            {
                item.Property("CreatedOn").CurrentValue = DateTime.Now;
            }
        }

        private void SetModifiedDate(EntityEntry item, IEntityType entityTyp)
        {
            var modifiedType = entityTyp.FindProperty("LastModified");
            if (modifiedType != null)
            {
                item.Property("LastModified").CurrentValue = DateTime.Now;
            }

            var RemovedType = entityTyp.FindProperty("IsRemoved");
            if (RemovedType != null)
            {
                item.Property("IsRemoved").CurrentValue = false;
            }
        }

        private void SetDeletedDate(EntityEntry item, IEntityType entityTyp)
        {
            var DeletedType = entityTyp.FindProperty("LastDeleted");
            if (DeletedType != null)
            {
                item.Property("LastDeleted").CurrentValue = DateTime.Now;
            }
        }
      


    }
}
