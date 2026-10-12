using WeighingScaleMiddleware.Models;
using WeighingScaleMiddleware.Models.WeighingScaleMiddleware.Models;

namespace WeighingScaleMiddleware.Services
{
    public class BatchingService
    {
        public BatchingResult Calculate(Recipe recipe, decimal volume)
        {
            decimal bin1 = recipe.Bin1 * volume;
            decimal bin2 = recipe.Bin2 * volume;
            decimal bin3 = recipe.Bin3 * volume;
            decimal bin4 = recipe.Bin4 * volume;

            decimal semen = recipe.Semen * volume;
            decimal flyAsh = recipe.FlyAsh * volume;
            decimal air = recipe.Air * volume;
            decimal aditif = recipe.Aditif * volume;

            return new BatchingResult
            {
                Bin1 = bin1,
                Bin2 = bin2,
                Bin3 = bin3,
                Bin4 = bin4,

                CumulativeBin1 = bin1,
                CumulativeBin2 = bin1 + bin2,
                CumulativeBin3 = bin1 + bin2 + bin3,
                CumulativeBin4 = bin1 + bin2 + bin3 + bin4,

                Semen = semen,
                CumulativeSemen = semen,

                FlyAsh = flyAsh,
                CumulativeFlyAsh = flyAsh,

                Air = air,
                Aditif = aditif
            };
        }
    }
}