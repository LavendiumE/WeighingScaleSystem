using System;
using System.Collections.Generic;
using System.Text;
using WeighingScaleMiddleware.Models;

namespace WeighingScaleMiddleware.Services
{
    public static class AppServices
    {
        public static RecipeService Recipe { get; } = new RecipeService();

        public static BuyerService Buyer { get; } = new BuyerService();

        public static TransactionService Transaction { get; } = new TransactionService();

        
    }
}
