using System.Collections.Generic;
using SuperHeroProject.domain.model.enums;
using SuperHeroProject.domain.model.hero;
using SuperHeroProject.domain.utils;

namespace SuperHeroProject.domain.services.interfaces
{
    public interface IHeroService
    {
        public Result<List<Hero>> GetAllHeroes();
        public Result<Hero> GetHeroById(string id);
        public List<Hero> SortHeroes(List<Hero> heroes, SortType sortType);
    }
}