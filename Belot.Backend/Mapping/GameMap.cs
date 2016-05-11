using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belot.Backend.Models;

namespace Belot.Backend.Mapping
{
    public class GameMap : EntityTypeConfiguration<Game>
    {
        public GameMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(t => t.ModeFK)
                .IsRequired();

            this.ToTable("T_GAME");

            this.HasMany(t => t.Users)
                .WithRequired()
                .HasForeignKey(t => t.GameFK);

            this.HasMany(t => t.Score)
                .WithOptional()
                .HasForeignKey(t => t.GameFK);

            this.HasRequired(t => t.Mode)
                .WithMany()
                .HasForeignKey(t => t.ModeFK);
        }
    }
}
