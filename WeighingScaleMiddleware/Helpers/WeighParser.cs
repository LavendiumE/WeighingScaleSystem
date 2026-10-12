using System.Globalization;
using System.Text.RegularExpressions;

namespace WeighingScaleMiddleware.Helpers
{
    public static class WeightParser
    {
        public static decimal ParseWeight(string rawData)
        {
            if (string.IsNullOrWhiteSpace(rawData))
                return 0;

            // Ambil angka dengan format:
            // +0000.012
            // -0000.012
            // 0000.012
            Match match = Regex.Match(
                rawData,
                @"([+-]?)(\d+)(?:\.(\d+))?"
            );

            if (!match.Success)
                return 0;

            string sign = match.Groups[1].Value;
            string integerPart = match.Groups[2].Value;
            string decimalPart = match.Groups[3].Value;

            // Gabungkan angka sebelum dan sesudah titik
            // 0000.012 -> 0000012
            string weightText = integerPart + decimalPart;

            // Buang angka 0 di depan
            weightText = weightText.TrimStart('0');

            // Kalau semuanya 0
            if (string.IsNullOrEmpty(weightText))
                weightText = "0";

            if (!decimal.TryParse(
                weightText,
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out decimal weight))
            {
                return 0;
            }

            // Kembalikan tanda negatif kalau ada
            if (sign == "-")
                weight *= -1;

            return weight;
        }
    }
}