using System.Collections.Generic;
using RestSharp;
using SuperHeroProject.domain.model.hero;
using SuperHeroProject.domain.repositories.interfaces;
using SuperHeroProject.infrastructure.mapper;
using SuperHeroProject.infrastructure.model;

namespace SuperHeroProject.infrastructure.repositories
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class HeroRepository : IHeroRepository
    {
        private readonly RestClient client = new("https://akabab.github.io/superhero-api/api");

        public List<Hero> GetAllHeroes()
        {
            var request = new RestRequest("all.json");
            var response = client.Execute<List<HeroResponse>>(request);
            return response.Data.ToDomain();
        }

        public Hero GetHeroById(string id)
        {
            var request = new RestRequest($"id/{id}.json");
            var response = client.Execute<HeroResponse>(request);
            return response.Data.ToDomain();
        }
    }
}