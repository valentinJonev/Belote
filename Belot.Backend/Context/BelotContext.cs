using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belot.Auth.Core.Context;
using Belot.Backend.Mapping;
using Belot.Backend.Models;
using Belot.Business.Migrations;

namespace Belot.Backend.Context
{
    public class BelotContext: AuthContext
    {
        public BelotContext()
            : base("BelotContext")
        {
            SetInitializer();

            Games = Set<Game>();
            Rooms = Set<Room>();
            Scores = Set<Score>();
        }

        public DbSet<Game> Games { get; private set; }
        public DbSet<GameMode> GameModes { get; private set; }
        public DbSet<Room> Rooms { get; private set; }
        public DbSet<Card> Cards { get; private set; }
        public DbSet<CardValue> CardValues { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<User> Players { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GameMap());
            modelBuilder.Configurations.Add(new CardMap());
            modelBuilder.Configurations.Add(new CardValueMap());
            modelBuilder.Configurations.Add(new RoomMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new GameModeMap());
            modelBuilder.Configurations.Add(new ScoreMap());

            base.OnModelCreating(modelBuilder);
        }

        public static void SetInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BelotContext, Configuration>());
        }
    }
}
