using WeighingScaleMiddleware.Data;
using WeighingScaleMiddleware.Models;

namespace WeighingScaleMiddleware.Services
{
    public class BuyerService
    {
        public void Add(Buyer buyer)
        {
            if (string.IsNullOrWhiteSpace(buyer.Name))
                throw new ArgumentException("Nama pembeli tidak boleh kosong.");

            if (GetByName(buyer.Name) != null)
                throw new ArgumentException(
                    $"Pembeli {buyer.Name} sudah ada."
                );

            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO Buyers
                (
                    Name,
                    Address
                )
                VALUES
                (
                    $name,
                    $address
                );
            ";

            command.Parameters.AddWithValue("$name", buyer.Name);
            command.Parameters.AddWithValue("$address", buyer.Address);

            command.ExecuteNonQuery();
        }

        public List<Buyer> GetAll()
        {
            var buyers = new List<Buyer>();

            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    Name,
                    Address
                FROM Buyers
                ORDER BY Id;
            ";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                buyers.Add(new Buyer
                {
                    Name = reader.GetString(0),
                    Address = reader.GetString(1)
                });
            }

            return buyers;
        }

        public Buyer? GetByName(string name)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    Name,
                    Address
                FROM Buyers
                WHERE Name = $name
                LIMIT 1;
            ";

            command.Parameters.AddWithValue("$name", name);

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return new Buyer
            {
                Name = reader.GetString(0),
                Address = reader.GetString(1)
            };
        }

        public void Delete(string name)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                DELETE FROM Buyers
                WHERE Name = $name;
            ";

            command.Parameters.AddWithValue("$name", name);

            command.ExecuteNonQuery();
        }
    }
}