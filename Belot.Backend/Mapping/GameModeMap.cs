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
    public class GameModeMap : EntityTypeConfiguration<GameMode>
    {
        public GameModeMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(t => t.Name)
                .IsRequired();

            this.Property(t => t.PlayersRequired)
                .IsRequired();

            this.ToTable("TD_GAME_MODE");
        }
    }
}
