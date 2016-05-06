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
    public class CardValueMap : EntityTypeConfiguration<CardValue>
    {
        public CardValueMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(t => t.Value)
                .IsRequired();

            this.Property(t => t.CardFK)
                .IsRequired();

            this.Property(t => t.ModeFK)
                .IsRequired();

            this.ToTable("TD_CARD_VALUE");
        }
    }
}
