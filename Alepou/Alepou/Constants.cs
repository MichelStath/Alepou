using SQLite;
using System;
using System.IO;

namespace Alepou
{
    public static class Constants
    {
        public const string DatabaseFilename = "SQLite.db3";

        public const SQLiteOpenFlags Flags =
            // Open the database in read/write mode.
            SQLiteOpenFlags.ReadWrite |
            // Create the database if it doesn't exist.
            SQLiteOpenFlags.Create |
            // Enable multi-threaded database access.
            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData
                );
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
