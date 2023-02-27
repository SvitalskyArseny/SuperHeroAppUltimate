using System.Collections.Generic;
using System.IO;
using SuperHeroProject.domain.model.custom;
using SuperHeroProject.domain.utils;
using PowerStats = SuperHeroProject.domain.model.custom.PowerStats;

namespace SuperHeroProject.domain.services.interfaces
{
    public interface ICustomHeroService
    {
        public Result<List<CustomHero>> GetAllCustomHeroes();

        public Result AddCustomHero(string name, string biography, FileStream stream, PowerStats powerStats,
            bool isPublic);

        public Result DeleteCustomHeroById(string id);
    }
}