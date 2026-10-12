using Microsoft.Data.Sqlite;
using System.IO;

namespace WeighingScaleMiddleware.Data
{
    public static class Database
    {
        private static readonly string DbPath =
            Path.Combine(AppContext.BaseDirectory, "weighing.db");

        private static readonly string ConnectionString =
            $"Data Source={DbPath}";

        public static void Initialize()
        {
            using var connection = new SqliteConnection(ConnectionString);

            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Buyers
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Address TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Recipes
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Mutu TEXT NOT NULL UNIQUE,
                    Bin1 REAL NOT NULL,
                    Bin2 REAL NOT NULL,
                    Bin3 REAL NOT NULL,
                    Bin4 REAL NOT NULL,
                    Semen REAL NOT NULL,
                    FlyAsh REAL NOT NULL,
                    Air REAL NOT NULL,
                    Aditif REAL NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Transactions
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    TransId TEXT NOT NULL,
                    Tanggal TEXT NOT NULL,
                    Supir TEXT NOT NULL,
                    Pembeli TEXT NOT NULL,
                    Proyek TEXT NOT NULL,
                    NoTruck TEXT NOT NULL,
                    Mutu TEXT NOT NULL,
                    Alamat TEXT NOT NULL,
                    Volume REAL NOT NULL,
                    Ritase REAL NOT NULL,
                    Keterangan TEXT NOT NULL,
                    Total REAL NOT NULL,
                    Petugas TEXT NOT NULL,
                    Slump REAL NOT NULL,

                    Bin1 REAL NOT NULL DEFAULT 0,
                    Bin2 REAL NOT NULL DEFAULT 0,
                    Bin3 REAL NOT NULL DEFAULT 0,
                    Bin4 REAL NOT NULL DEFAULT 0,

                    Semen REAL NOT NULL DEFAULT 0,
                    FlyAsh REAL NOT NULL DEFAULT 0,
                    Air REAL NOT NULL DEFAULT 0,
                    Aditif REAL NOT NULL DEFAULT 0
                );
            ";

            command.ExecuteNonQuery();

            // Migration database lama
            AddColumnIfNotExists(connection, "Bin1");
            AddColumnIfNotExists(connection, "Bin2");
            AddColumnIfNotExists(connection, "Bin3");
            AddColumnIfNotExists(connection, "Bin4");

            AddColumnIfNotExists(connection, "Semen");
            AddColumnIfNotExists(connection, "FlyAsh");
            AddColumnIfNotExists(connection, "Air");
            AddColumnIfNotExists(connection, "Aditif");

            
        }

        private static void AddColumnIfNotExists(
        SqliteConnection connection,
        string columnName)
        {
            using var checkCommand = connection.CreateCommand();

            checkCommand.CommandText = @"
                SELECT COUNT(*)
                FROM pragma_table_info('Transactions')
                WHERE name = $columnName;
            ";

            checkCommand.Parameters.AddWithValue("$columnName", columnName);

            long exists = (long)checkCommand.ExecuteScalar()!;

            if (exists > 0)
                return;

            using var alterCommand = connection.CreateCommand();

            alterCommand.CommandText =
                $"ALTER TABLE Transactions ADD COLUMN {columnName} REAL NOT NULL DEFAULT 0;";

            alterCommand.ExecuteNonQuery();
        }

        public static SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            return connection;
        }


    }
}