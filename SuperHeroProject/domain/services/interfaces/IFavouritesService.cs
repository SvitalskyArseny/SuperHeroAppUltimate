using System.Collections.Generic;
using SuperHeroProject.domain.model.hero;
using SuperHeroProject.domain.utils;

namespace SuperHeroProject.domain.services.interfaces
{
    public interface IFavouritesService
    {
        public Result<List<Hero>> GetAllHeroesFromFavourites();
        public Result AddHeroToFavouritesById(string id);
        public Result DeleteHeroFromFavouritesById(string id);
    }
}