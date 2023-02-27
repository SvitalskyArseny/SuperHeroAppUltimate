using System.Collections.Generic;
using SuperHeroProject.domain.model.favourite;

namespace SuperHeroProject.domain.repositories.interfaces
{
    public interface IFavouritesRepository
    {
        public void AddHeroToFavourites(string userId, FavouriteHero hero);
        public IEnumerable<FavouriteHero> GetAllHeroesFromFavourites(string userId);
        public void DeleteHeroFromFavouritesById(string userId, string heroId);
    }
}