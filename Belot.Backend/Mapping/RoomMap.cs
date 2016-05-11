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
    public class RoomMap : EntityTypeConfiguration<Room>
    {
        public RoomMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(t => t.Name)
                .IsRequired();

            this.Property(t => t.IsChatAvaiable)
                .IsRequired();

            this.ToTable("T_ROOM");

            this.HasMany(t => t.PlayersId)
                .WithRequired()
                .HasForeignKey(t => t.GameFK);
        }
    }
}
