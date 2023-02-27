using System.Collections.Generic;
using System.Linq;
using SuperHeroProject.domain.model.favourite;
using SuperHeroProject.domain.model.hero;
using SuperHeroProject.domain.repositories.interfaces;
using SuperHeroProject.domain.services.interfaces;
using SuperHeroProject.domain.utils;

namespace SuperHeroProject.domain.services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class FavouritesService : IFavouritesService
    {
        private readonly IHeroRepository heroRepository;
        private readonly IFavouritesRepository favouritesRepository;
        private readonly IUserRepository userRepository;

        public FavouritesService(
            IHeroRepository heroRepository,
            IFavouritesRepository favouritesRepository,
            IUserRepository userRepository
        )
        {
            this.heroRepository = heroRepository;
            this.favouritesRepository = favouritesRepository;
            this.userRepository = userRepository;
        }

        public Result<List<Hero>> GetAllHeroesFromFavourites()
        {
            return ExceptionHelper.TryCatch(() =>
            {
                var userId = userRepository.GetUserId();
                var listOfHeroIds
                    = favouritesRepository.GetAllHeroesFromFavourites(userId);
                var listOfHeroes
                    = listOfHeroIds.Select(hero => heroRepository.GetHeroById(hero.Id)).ToList();
                return Result.Ok(listOfHeroes);
            });
        }

        public Result AddHeroToFavouritesById(string id)
        {
            return ExceptionHelper.TryCatch(() =>
            {
                var userId = userRepository.GetUserId();
                var favHero = new FavouriteHero(id);
                favouritesRepository.AddHeroToFavourites(userId, favHero);
            });
        }

        public Result DeleteHeroFromFavouritesById(string id)
        {
            return ExceptionHelper.TryCatch(() =>
            {
                var userId = userRepository.GetUserId();
                favouritesRepository.DeleteHeroFromFavouritesById(userId, id);
            });
        }
    }
}