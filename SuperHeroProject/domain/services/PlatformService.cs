using System.Collections.Generic;
using System.Linq;
using SuperHeroProject.domain.model.custom;
using SuperHeroProject.domain.model.market;
using SuperHeroProject.domain.repositories.interfaces;
using SuperHeroProject.domain.services.interfaces;
using SuperHeroProject.domain.utils;

namespace SuperHeroProject.domain.services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository platformRepository;
        private readonly IUserRepository userRepository;

        public PlatformService(IPlatformRepository platformRepository, IUserRepository userRepository)
        {
            this.platformRepository = platformRepository;
            this.userRepository = userRepository;
        }

        public Result AddHeroToPlatform(CustomHero hero)
        {
            return ExceptionHelper.TryCatch(() =>
            {
                var user = userRepository.GetUser();
                var platformHero = new PlatformHero(user.UserName, hero);
                platformRepository.AddHeroToPlatform(platformHero);
            });
        }

        public Result<List<PlatformHero>> GetAllHeroesByUserName(string userName)
        {
            return ExceptionHelper.TryCatch(() =>
            {
                var listOfPlatformHeroes = platformRepository.GetAllHeroesByUserName(userName).ToList();
                return listOfPlatformHeroes.Count == 0
                    ? Result.Fail<List<PlatformHero>>("Пользователь с таким именем не найден")
                    : Result.Ok(listOfPlatformHeroes);
            });
        }

        public Result<List<PlatformHero>> GetAllHeroesFromPlatform()
        {
            return ExceptionHelper.TryCatch(() =>
            {
                var listOfPlatformHeroes = platformRepository.GetAllHeroesFromPlatform().ToList();
                return Result.Ok(listOfPlatformHeroes);
            });
        }

        public Result DeleteHeroFromPlatform(string heroId)
        {
            return ExceptionHelper.TryCatch(() =>
            {
                var user = userRepository.GetUser();
                platformRepository.DeleteHeroFromPlatform(user.UserName, heroId);
            });
        }

        public Result SetLikeHero(bool isSet, string heroId)
        {
            return ExceptionHelper.TryCatch(() =>
            {
                platformRepository.SetLike(isSet, heroId, userRepository.GetUser().UserName);
            });
        }

        public Result<List<string>> GetListOfLikedUsers(string heroId)
        {
            return ExceptionHelper.TryCatch(() =>
            {
                var listOfLikedUsers = platformRepository.GetListOfLikedUsers(heroId).ToList();
                return Result.Ok(listOfLikedUsers);
            });
        }
    }
}