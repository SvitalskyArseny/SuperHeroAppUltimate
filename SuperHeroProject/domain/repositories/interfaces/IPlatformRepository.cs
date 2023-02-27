using System.Collections.Generic;
using SuperHeroProject.domain.model.market;

namespace SuperHeroProject.domain.repositories.interfaces
{
    public interface IPlatformRepository
    {
        public void AddHeroToPlatform(PlatformHero hero);
        public IEnumerable<PlatformHero> GetAllHeroesByUserName(string userName);
        public IEnumerable<PlatformHero> GetAllHeroesFromPlatform();
        public void DeleteHeroFromPlatform(string userName, string heroId);

        public void SetLike(bool isSet, string heroId, string userName);

        public IEnumerable<string> GetListOfLikedUsers(string heroId);
    }
}