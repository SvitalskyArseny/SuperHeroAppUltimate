using System.Collections.Generic;
using SuperHeroProject.domain.model.custom;
using SuperHeroProject.domain.model.market;
using SuperHeroProject.domain.utils;

namespace SuperHeroProject.domain.services.interfaces
{
    public interface IPlatformService
    {
        public Result AddHeroToPlatform(CustomHero hero);
        public Result<List<PlatformHero>> GetAllHeroesByUserName(string userName);
        public Result<List<PlatformHero>> GetAllHeroesFromPlatform();
        public Result DeleteHeroFromPlatform(string heroId);
        public Result SetLikeHero(bool isSet, string heroId);
        public Result<List<string>> GetListOfLikedUsers(string heroId);
    }
}