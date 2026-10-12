using Microsoft.Data.Sqlite;
using WeighingScaleMiddleware.Data;
using WeighingScaleMiddleware.Models;

namespace WeighingScaleMiddleware.Services
{
    public class RecipeService
    {
        public List<Recipe> GetAll()
        {
            var recipes = new List<Recipe>();

            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    Mutu,
                    Bin1,
                    Bin2,
                    Bin3,
                    Bin4,
                    Semen,
                    FlyAsh,
                    Air,
                    Aditif
                FROM Recipes
                ORDER BY Id;
            ";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                recipes.Add(new Recipe
                {
                    Mutu = reader.GetString(0),
                    Bin1 = reader.GetDecimal(1),
                    Bin2 = reader.GetDecimal(2),
                    Bin3 = reader.GetDecimal(3),
                    Bin4 = reader.GetDecimal(4),
                    Semen = reader.GetDecimal(5),
                    FlyAsh = reader.GetDecimal(6),
                    Air = reader.GetDecimal(7),
                    Aditif = reader.GetDecimal(8)
                });
            }

            return recipes;
        }

        public Recipe? GetByMutu(string mutu)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    Mutu,
                    Bin1,
                    Bin2,
                    Bin3,
                    Bin4,
                    Semen,
                    FlyAsh,
                    Air,
                    Aditif
                FROM Recipes
                WHERE Mutu = $mutu
                LIMIT 1;
            ";

            command.Parameters.AddWithValue("$mutu", mutu);

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return new Recipe
            {
                Mutu = reader.GetString(0),
                Bin1 = reader.GetDecimal(1),
                Bin2 = reader.GetDecimal(2),
                Bin3 = reader.GetDecimal(3),
                Bin4 = reader.GetDecimal(4),
                Semen = reader.GetDecimal(5),
                FlyAsh = reader.GetDecimal(6),
                Air = reader.GetDecimal(7),
                Aditif = reader.GetDecimal(8)
            };
        }

        public void Add(Recipe recipe)
        {
            if (string.IsNullOrWhiteSpace(recipe.Mutu))
                throw new ArgumentException("Recipe mutu tidak boleh kosong.");

            if (GetByMutu(recipe.Mutu) != null)
                throw new ArgumentException(
                    $"Recipe untuk mutu {recipe.Mutu} sudah ada."
                );

            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO Recipes
                (
                    Mutu,
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
                    $mutu,
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

            command.Parameters.AddWithValue("$mutu", recipe.Mutu);
            command.Parameters.AddWithValue("$bin1", recipe.Bin1);
            command.Parameters.AddWithValue("$bin2", recipe.Bin2);
            command.Parameters.AddWithValue("$bin3", recipe.Bin3);
            command.Parameters.AddWithValue("$bin4", recipe.Bin4);
            command.Parameters.AddWithValue("$semen", recipe.Semen);
            command.Parameters.AddWithValue("$flyAsh", recipe.FlyAsh);
            command.Parameters.AddWithValue("$air", recipe.Air);
            command.Parameters.AddWithValue("$aditif", recipe.Aditif);

            command.ExecuteNonQuery();
        }

        public void Update(Recipe recipe)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                UPDATE Recipes
                SET
                    Bin1 = $bin1,
                    Bin2 = $bin2,
                    Bin3 = $bin3,
                    Bin4 = $bin4,
                    Semen = $semen,
                    FlyAsh = $flyAsh,
                    Air = $air,
                    Aditif = $aditif
                WHERE Mutu = $mutu;
            ";

            command.Parameters.AddWithValue("$mutu", recipe.Mutu);
            command.Parameters.AddWithValue("$bin1", recipe.Bin1);
            command.Parameters.AddWithValue("$bin2", recipe.Bin2);
            command.Parameters.AddWithValue("$bin3", recipe.Bin3);
            command.Parameters.AddWithValue("$bin4", recipe.Bin4);
            command.Parameters.AddWithValue("$semen", recipe.Semen);
            command.Parameters.AddWithValue("$flyAsh", recipe.FlyAsh);
            command.Parameters.AddWithValue("$air", recipe.Air);
            command.Parameters.AddWithValue("$aditif", recipe.Aditif);

            command.ExecuteNonQuery();
        }

        public void Delete(string mutu)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                DELETE FROM Recipes
                WHERE Mutu = $mutu;
            ";

            command.Parameters.AddWithValue("$mutu", mutu);

            command.ExecuteNonQuery();
        }

        public Dictionary<string, decimal> Calculate(
            string mutu,
            decimal volume)
        {
            var recipe = GetByMutu(mutu);

            if (recipe == null)
                throw new ArgumentException(
                    $"Recipe {mutu} tidak ditemukan."
                );

            return new Dictionary<string, decimal>
            {
                { "Bin1", recipe.Bin1 * volume },
                { "Bin2", recipe.Bin2 * volume },
                { "Bin3", recipe.Bin3 * volume },
                { "Bin4", recipe.Bin4 * volume },
                { "Semen", recipe.Semen * volume },
                { "FlyAsh", recipe.FlyAsh * volume },
                { "Air", recipe.Air * volume },
                { "Aditif", recipe.Aditif * volume }
            };
        }
    }
}