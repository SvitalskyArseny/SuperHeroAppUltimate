using System.Collections.Generic;
using SuperHeroProject.domain.model.hero;

namespace SuperHeroProject.domain.repositories.interfaces
{
    public interface IHeroRepository
    {
        public List<Hero> GetAllHeroes();

        public Hero GetHeroById(string id);
    }
}