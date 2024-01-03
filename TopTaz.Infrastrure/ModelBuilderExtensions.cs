using Microsoft.EntityFrameworkCore;
using System;
using TopTaz.Domain.FrameWorkDomain;

namespace TopTaz.Infrastrure
{
    public static class ModelBuilderExtensions
    {
        public static void AddAuditableProperties(this ModelBuilder modelBuilder)
        {
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                if (item.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    modelBuilder.Entity(item.Name).Property<DateTime?>("CreatedOn");
                    modelBuilder.Entity(item.Name).Property<DateTime?>("LastModified");
                    modelBuilder.Entity(item.Name).Property<DateTime?>("LastDeleted");
                    modelBuilder.Entity(item.Name).Property<bool>("IsRemoved");
                }
            }
            
        }
        
    }
}
