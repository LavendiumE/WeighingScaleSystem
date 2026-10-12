using Microsoft.Data.Sqlite;
using WeighingScaleMiddleware.Data;
using WeighingScaleMiddleware.Models;

namespace WeighingScaleMiddleware.Services
{
    public class TransactionService
    {
        public void Add(Transaction transaction)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO Transactions
                (
                    TransId,
                    Tanggal,
                    Supir,
                    Pembeli,
                    Proyek,
                    NoTruck,
                    Mutu,
                    Alamat,
                    Volume,
                    Ritase,
                    Keterangan,
                    Total,
                    Petugas,
                    Slump,

                    Bin1,
                    Bin2,
                    Bin3,
                    Bin4,

                    Semen,
                    FlyAsh,
                    Air,
                    Aditif
                )
                VALUES
                (
                    $transId,
                    $tanggal,
                    $supir,
                    $pembeli,
                    $proyek,
                    $noTruck,
                    $mutu,
                    $alamat,
                    $volume,
                    $ritase,
                    $keterangan,
                    $total,
                    $petugas,
                    $slump,

                    $bin1,
                    $bin2,
                    $bin3,
                    $bin4,

                    $semen,
                    $flyAsh,
                    $air,
                    $aditif
                );
            ";

            command.Parameters.AddWithValue(
                "$transId",
                transaction.TransId
            );

            command.Parameters.AddWithValue(
                "$tanggal",
                transaction.Tanggal.ToString("yyyy-MM-dd HH:mm:ss")
            );

            command.Parameters.AddWithValue(
                "$supir",
                transaction.Supir
            );

            command.Parameters.AddWithValue(
                "$pembeli",
                transaction.Pembeli
            );

            command.Parameters.AddWithValue(
                "$proyek",
                transaction.Proyek
            );

            command.Parameters.AddWithValue(
                "$noTruck",
                transaction.NoTruck
            );

            command.Parameters.AddWithValue(
                "$mutu",
                transaction.Mutu
            );

            command.Parameters.AddWithValue(
                "$alamat",
                transaction.Alamat
            );

            command.Parameters.AddWithValue(
                "$volume",
                transaction.Volume
            );

            command.Parameters.AddWithValue(
                "$ritase",
                transaction.Ritase
            );

            command.Parameters.AddWithValue(
                "$keterangan",
                transaction.Keterangan
            );

            command.Parameters.AddWithValue(
                "$total",
                transaction.Total
            );

            command.Parameters.AddWithValue(
                "$petugas",
                transaction.Petugas
            );

            command.Parameters.AddWithValue(
                "$slump",
                transaction.Slump
            );

            // Sampling / hasil batching aggregate
            command.Parameters.AddWithValue(
                "$bin1",
                transaction.Bin1
            );

            command.Parameters.AddWithValue(
                "$bin2",
                transaction.Bin2
            );

            command.Parameters.AddWithValue(
                "$bin3",
                transaction.Bin3
            );

            command.Parameters.AddWithValue(
                "$bin4",
                transaction.Bin4
            );

            // Sampling / hasil material
            command.Parameters.AddWithValue(
                "$semen",
                transaction.Semen
            );

            command.Parameters.AddWithValue(
                "$flyAsh",
                transaction.FlyAsh
            );

            command.Parameters.AddWithValue(
                "$air",
                transaction.Air
            );

            command.Parameters.AddWithValue(
                "$aditif",
                transaction.Aditif
            );

            command.ExecuteNonQuery();
        }


        public List<Transaction> GetAll()
        {
            var transactions = new List<Transaction>();

            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    TransId,
                    Tanggal,
                    Supir,
                    Pembeli,
                    Proyek,
                    NoTruck,
                    Mutu,
                    Alamat,
                    Volume,
                    Ritase,
                    Keterangan,
                    Total,
                    Petugas,
                    Slump,

                    Bin1,
                    Bin2,
                    Bin3,
                    Bin4,

                    Semen,
                    FlyAsh,
                    Air,
                    Aditif

                FROM Transactions
                ORDER BY Id;
            ";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                transactions.Add(new Transaction
                {
                    TransId = reader.GetString(0),
                    Tanggal = DateTime.Parse(reader.GetString(1)),
                    Supir = reader.GetString(2),
                    Pembeli = reader.GetString(3),
                    Proyek = reader.GetString(4),
                    NoTruck = reader.GetString(5),
                    Mutu = reader.GetString(6),
                    Alamat = reader.GetString(7),
                    Volume = reader.GetDecimal(8),
                    Ritase = reader.GetDecimal(9),
                    Keterangan = reader.GetString(10),
                    Total = reader.GetDecimal(11),
                    Petugas = reader.GetString(12),
                    Slump = reader.GetDecimal(13),

                    Bin1 = reader.GetDecimal(14),
                    Bin2 = reader.GetDecimal(15),
                    Bin3 = reader.GetDecimal(16),
                    Bin4 = reader.GetDecimal(17),

                    Semen = reader.GetDecimal(18),
                    FlyAsh = reader.GetDecimal(19),
                    Air = reader.GetDecimal(20),
                    Aditif = reader.GetDecimal(21)
                });
            }

            return transactions;
        }


        public List<Transaction> Search(string keyword)
        {
            var transactions = new List<Transaction>();

            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    TransId,
                    Tanggal,
                    Supir,
                    Pembeli,
                    Proyek,
                    NoTruck,
                    Mutu,
                    Alamat,
                    Volume,
                    Ritase,
                    Keterangan,
                    Total,
                    Petugas,
                    Slump,

                    Bin1,
                    Bin2,
                    Bin3,
                    Bin4,

                    Semen,
                    FlyAsh,
                    Air,
                    Aditif

                FROM Transactions
                WHERE
                    LOWER(TransId) LIKE $keyword OR
                    LOWER(Supir) LIKE $keyword OR
                    LOWER(Pembeli) LIKE $keyword OR
                    LOWER(Proyek) LIKE $keyword OR
                    LOWER(NoTruck) LIKE $keyword OR
                    LOWER(Mutu) LIKE $keyword OR
                    LOWER(Alamat) LIKE $keyword

                ORDER BY Id;
            ";

            command.Parameters.AddWithValue(
                "$keyword",
                $"%{keyword.Trim().ToLower()}%"
            );

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                transactions.Add(new Transaction
                {
                    TransId = reader.GetString(0),
                    Tanggal = DateTime.Parse(reader.GetString(1)),
                    Supir = reader.GetString(2),
                    Pembeli = reader.GetString(3),
                    Proyek = reader.GetString(4),
                    NoTruck = reader.GetString(5),
                    Mutu = reader.GetString(6),
                    Alamat = reader.GetString(7),
                    Volume = reader.GetDecimal(8),
                    Ritase = reader.GetDecimal(9),
                    Keterangan = reader.GetString(10),
                    Total = reader.GetDecimal(11),
                    Petugas = reader.GetString(12),
                    Slump = reader.GetDecimal(13),

                    Bin1 = reader.GetDecimal(14),
                    Bin2 = reader.GetDecimal(15),
                    Bin3 = reader.GetDecimal(16),
                    Bin4 = reader.GetDecimal(17),

                    Semen = reader.GetDecimal(18),
                    FlyAsh = reader.GetDecimal(19),
                    Air = reader.GetDecimal(20),
                    Aditif = reader.GetDecimal(21)
                });
            }

            return transactions;
        }


        public List<Transaction> GetByDate(
            DateTime startDate,
            DateTime endDate)
        {
            var transactions = new List<Transaction>();

            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    TransId,
                    Tanggal,
                    Supir,
                    Pembeli,
                    Proyek,
                    NoTruck,
                    Mutu,
                    Alamat,
                    Volume,
                    Ritase,
                    Keterangan,
                    Total,
                    Petugas,
                    Slump,

                    Bin1,
                    Bin2,
                    Bin3,
                    Bin4,

                    Semen,
                    FlyAsh,
                    Air,
                    Aditif

                FROM Transactions
                WHERE date(Tanggal) >= date($startDate)
                  AND date(Tanggal) <= date($endDate)

                ORDER BY Id;
            ";

            command.Parameters.AddWithValue(
                "$startDate",
                startDate.ToString("yyyy-MM-dd")
            );

            command.Parameters.AddWithValue(
                "$endDate",
                endDate.ToString("yyyy-MM-dd")
            );

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                transactions.Add(new Transaction
                {
                    TransId = reader.GetString(0),
                    Tanggal = DateTime.Parse(reader.GetString(1)),
                    Supir = reader.GetString(2),
                    Pembeli = reader.GetString(3),
                    Proyek = reader.GetString(4),
                    NoTruck = reader.GetString(5),
                    Mutu = reader.GetString(6),
                    Alamat = reader.GetString(7),
                    Volume = reader.GetDecimal(8),
                    Ritase = reader.GetDecimal(9),
                    Keterangan = reader.GetString(10),
                    Total = reader.GetDecimal(11),
                    Petugas = reader.GetString(12),
                    Slump = reader.GetDecimal(13),

                    Bin1 = reader.GetDecimal(14),
                    Bin2 = reader.GetDecimal(15),
                    Bin3 = reader.GetDecimal(16),
                    Bin4 = reader.GetDecimal(17),

                    Semen = reader.GetDecimal(18),
                    FlyAsh = reader.GetDecimal(19),
                    Air = reader.GetDecimal(20),
                    Aditif = reader.GetDecimal(21)
                });
            }

            return transactions;
        }


        public void DeleteAll()
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = "DELETE FROM Transactions;";

            command.ExecuteNonQuery();
        }

        public string GenerateTransactionId()
        {
            string datePrefix = $"C{DateTime.Now:yyyyMMdd}";

            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT TransId
                FROM Transactions
                WHERE TransId LIKE $prefix || '-%'
                ORDER BY Id DESC
                LIMIT 1;
            ";

            command.Parameters.AddWithValue("$prefix", datePrefix);

            object? result = command.ExecuteScalar();

            if (result == null || result == DBNull.Value)
            {
                return $"{datePrefix}-1";
            }

            string lastTransId = result.ToString()!;

            // Ambil nomor setelah tanda "-"
            int separatorIndex = lastTransId.LastIndexOf('-');

            if (separatorIndex == -1)
            {
                return $"{datePrefix}-1";
            }

            string numberText =
                lastTransId.Substring(separatorIndex + 1);

            if (!int.TryParse(numberText, out int lastNumber))
            {
                return $"{datePrefix}-1";
            }

            int nextNumber = lastNumber + 1;

            return $"{datePrefix}-{nextNumber}";
        }
    }
}