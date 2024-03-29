﻿using System.IO;
using Core.AppSettings;
using Infra.Extensions;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Infra.Contexts
{
    public class WarrenContext : DbContext, IWarrenContext
    {
        private readonly IConfiguration _configuration;

        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public WarrenContext(IConfiguration configuration) =>
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        public WarrenContext(DbContextOptions options, IConfiguration configuration) : base(options) => _configuration = configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Initialize<IMappingWarren>();
            modelBuilder.UseConventions();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = _configuration.GetSection("ConnectionStrings").Get<ConnectionSettings>();

            optionsBuilder.UseSqlServer(connection.Warren);

            
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }
    }
}