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
    public class GameCardMap : EntityTypeConfiguration<GameCard>
    {
        public GameCardMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(t => t.Turn)
                .IsRequired();

            this.ToTable("TM_GAME_CARD");

            this.HasRequired(t => t.Card)
                .WithMany()
                .HasForeignKey(t => t.CardFK);

            this.HasRequired(t => t.Player)
                .WithMany()
                .HasForeignKey(t => t.PlayerFK);

            this.HasRequired(t => t.Game)
                .WithMany()
                .HasForeignKey(t => t.GameFK);
        }
    }
}
