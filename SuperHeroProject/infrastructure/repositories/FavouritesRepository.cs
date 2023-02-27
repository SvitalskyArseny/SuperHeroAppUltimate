using System.Collections.Generic;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;
using SuperHeroProject.domain.model.favourite;
using SuperHeroProject.domain.repositories.interfaces;

namespace SuperHeroProject.infrastructure.repositories
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class FavouritesRepository : IFavouritesRepository
    {
        private readonly FirebaseClient firebase = new(CustomHeroRepository.BaseUrl);

        private const string Favourites = "favourites";

        public void AddHeroToFavourites(string userId, FavouriteHero hero)
        {
            firebase
                .Child(Favourites)
                .Child(userId)
                .Child(hero.Id)
                .PutAsync(hero)
                .Wait();
        }

        public IEnumerable<FavouriteHero> GetAllHeroesFromFavourites(string userId)
        {
            var listOfHeroIds = firebase
                .Child(Favourites)
                .Child(userId)
                .OnceAsync<FavouriteHero>();
            listOfHeroIds.Wait();
            return listOfHeroIds.Result.Select(i => i.Object);
        }

        public void DeleteHeroFromFavouritesById(string userId, string heroId)
        {
            firebase
                .Child(Favourites)
                .Child(userId)
                .Child(heroId)
                .DeleteAsync()
                .Wait();
        }
    }
}