using set_basic_aspnet_mvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace set_basic_aspnet_mvc.Domain.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
                HasKey(r => r.Id).Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

                this.Property(u => u.Email);
                this.Property(u => u.FullName);
                this.Property(u => u.Language);
                this.Property(u => u.ImageUrl);
                this.Property(u => u.IsActive);

                this.Property(u => u.PasswordHash);
                this.Property(u => u.PasswordResetRequestedAt);

                this.Property(u => u.PasswordResetToken);
                this.Property(u => u.LastLoginAt);
                this.Property(u => u.LoginTryCount);

                this.Property(u => u.RoleId);
                this.Property(u => u.RoleName);

                this.Property(u => u.UpdatedBy);
                this.Property(u => u.UpdatedAt);

                this.Property(u => u.CreatedBy);
                this.Property(u => u.CreatedAt);

                this.Property(u => u.DeletedBy);
                this.Property(u => u.DeletedAt);
                this.Property(u => u.IsDeleted);
        }
    }
}