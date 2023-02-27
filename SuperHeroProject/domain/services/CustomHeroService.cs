using System.Collections.Generic;
using System.IO;
using System.Linq;
using SuperHeroProject.domain.model.custom;
using SuperHeroProject.domain.repositories.interfaces;
using SuperHeroProject.domain.services.interfaces;
using SuperHeroProject.domain.utils;
using PowerStats = SuperHeroProject.domain.model.custom.PowerStats;

namespace SuperHeroProject.domain.services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class CustomHeroService : ICustomHeroService
    {
        private readonly ICustomHeroRepository customHeroService;
        private readonly IPlatformService platformService;
        private readonly IUserRepository userRepository;

        public CustomHeroService(
            ICustomHeroRepository customHeroService,
            IPlatformService platformService,
            IUserRepository userRepository
        )
        {
            this.customHeroService = customHeroService;
            this.platformService = platformService;
            this.userRepository = userRepository;
        }

        public Result<List<CustomHero>> GetAllCustomHeroes()
        {
            return ExceptionHelper.TryCatch(() =>
            {
                var userId = userRepository.GetUserId();
                var listOfCustomHeroes = customHeroService.GetAllCustomHeroes(userId).ToList();
                return Result.Ok(listOfCustomHeroes);
            });
        }

        public Result AddCustomHero(
            string name,
            string biography,
            FileStream stream,
            PowerStats powerStats,
            bool isPublic)
        {
            return ExceptionHelper.TryCatch(() =>
            {
                var photoId = Utils.GetNewId();
                var photoUrl = customHeroService.UploadPhoto(stream, photoId);


                var heroId = Utils.GetNewId();
                var customHero = new CustomHero(heroId, name, biography, photoUrl, powerStats, isPublic);
                var userId = userRepository.GetUserId();
                customHeroService.AddCustomHero(userId, customHero);

                if (isPublic)
                {
                    platformService.AddHeroToPlatform(customHero);
                }
            });
        }

        public Result DeleteCustomHeroById(string id)
        {
            return ExceptionHelper.TryCatch(() =>
            {
                var userId = userRepository.GetUserId();
                customHeroService.DeleteCustomHeroById(userId, id);
            });
        }
    }
}