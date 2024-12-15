﻿namespace SSG.Infrastructure.Options
{
    public class DatabaseOption
    {
        public string ConnectionString { get; set; } = string.Empty;
        public int EnableRetryOnFailure { get; set; }
        public int CommandTimeout { get; set; }
        public bool EnableDetailedErrors { get; set; }
        public bool EnableSensitiveDataLogging { get; set; }
    }
}