using Basket.API.Entities;

namespace Basket.API.Repositories
{
    public interface IBasketRepo
    {
        Task<ShoppingCart> GetBasket(string userName);
        /**
         * Since that this service is relies on redis database which is key:value pairs, 
           we need to pass the key=Username and value=ShoppingCart to the database
           if this username doesn't have a shoppingCart before then we need to create a new one for this user,
             otherwise we need to update the existing one
         */
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
        Task<bool> DeleteBasket(string userName);
    }
}