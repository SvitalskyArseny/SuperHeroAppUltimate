using System.Collections.Generic;
using System.Linq;
using SuperHeroProject.domain.model.enums;
using SuperHeroProject.domain.model.hero;
using SuperHeroProject.domain.repositories.interfaces;
using SuperHeroProject.domain.services.interfaces;
using SuperHeroProject.domain.utils;

namespace SuperHeroProject.domain.services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository service;

        public HeroService(IHeroRepository service)
        {
            this.service = service;
        }

        public Result<List<Hero>> GetAllHeroes()
        {
            return ExceptionHelper.TryCatch(() =>
            {
                var allHeroes = service.GetAllHeroes();
                return Result.Ok(allHeroes);
            });
        }

        public Result<Hero> GetHeroById(string id)
        {
            return ExceptionHelper.TryCatch(() =>
            {
                var hero = service.GetHeroById(id);
                return Result.Ok(hero);
            });
        }

        public List<Hero> SortHeroes(List<Hero> heroes, SortType sortType)
        {
            return sortType switch
            {
                SortType.SortByName => heroes.OrderBy(hero => hero.Name).ToList(),
                SortType.SortByNameDesc => heroes.OrderByDescending(hero => hero.Name).ToList(),
                _ => heroes
            };
        }
    }
}