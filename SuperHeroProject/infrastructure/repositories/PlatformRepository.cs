using System.Collections.Generic;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;
using SuperHeroProject.domain.model.market;
using SuperHeroProject.domain.repositories.interfaces;

namespace SuperHeroProject.infrastructure.repositories
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class PlatformRepository : IPlatformRepository
    {
        private readonly FirebaseClient firebase = new(CustomHeroRepository.BaseUrl);

        private const string Platform = "platform";
        private const string PlatformUsers = "platform_users";
        private const string PlatformLikes = "platform_likes";

        public void AddHeroToPlatform(PlatformHero hero)
        {
            firebase
                .Child(Platform)
                .Child(hero.Hero.Id)
                .PutAsync(hero)
                .Wait();

            firebase
                .Child(PlatformUsers)
                .Child(hero.UserName)
                .Child(hero.Hero.Id)
                .PutAsync(hero)
                .Wait();
        }

        public IEnumerable<PlatformHero> GetAllHeroesFromPlatform()
        {
            var listOfPlatformHeroes = firebase
                .Child(Platform)
                .OnceAsync<PlatformHero>();
            listOfPlatformHeroes.Wait();
            return listOfPlatformHeroes.Result.Select(i => i.Object);
        }

        public IEnumerable<PlatformHero> GetAllHeroesByUserName(string userName)
        {
            var listOfPlatformHeroes = firebase
                .Child(PlatformUsers)
                .Child(userName)
                .OnceAsync<PlatformHero>();
            listOfPlatformHeroes.Wait();
            return listOfPlatformHeroes.Result.Select(i => i.Object);
        }

        public void DeleteHeroFromPlatform(string userName, string heroId)
        {
            firebase
                .Child(Platform)
                .Child(heroId)
                .DeleteAsync()
                .Wait();

            firebase
                .Child(PlatformUsers)
                .Child(userName)
                .Child(heroId)
                .DeleteAsync()
                .Wait();
        }

        public void SetLike(bool isSet, string heroId, string userName)
        {
            if (isSet)
            {
                firebase
                    .Child(PlatformLikes)
                    .Child(heroId)
                    .Child(userName)
                    .PutAsync<string>(userName)
                    .Wait();
            }
            else
            {
                firebase
                    .Child(PlatformLikes)
                    .Child(heroId)
                    .Child(userName)
                    .DeleteAsync()
                    .Wait();
            }
        }

        public IEnumerable<string> GetListOfLikedUsers(string heroId)
        {
            var listOfUsernames = firebase
                .Child(PlatformLikes)
                .Child(heroId)
                .OnceAsync<string>();
            listOfUsernames.Wait();
            return listOfUsernames.Result.Select(i => i.Object);
        }
    }
}