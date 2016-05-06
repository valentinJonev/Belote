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
    public class ScoreMap : EntityTypeConfiguration<Score>
    {
        public ScoreMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(t => t.TeamA)
                .IsRequired();

            this.Property(t => t.TeamB)
                .IsRequired();

            this.Property(t => t.Turn)
                .IsRequired();

            this.Property(t => t.GameFK)
                .IsRequired();

            this.ToTable("T_SCORE");
        }
    }
}
