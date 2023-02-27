using System.Collections.Generic;
using System.IO;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using SuperHeroProject.domain.model.custom;
using SuperHeroProject.domain.repositories.interfaces;

namespace SuperHeroProject.infrastructure.repositories
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class CustomHeroRepository : ICustomHeroRepository
    {
        public const string BaseUrl = "https://superheroapp-23a80-default-rtdb.europe-west1.firebasedatabase.app/";

        private readonly FirebaseClient firebase = new(BaseUrl);
        private readonly FirebaseStorage storage = new("superheroapp-23a80.appspot.com");

        private const string Custom = "custom";
        private const string Photos = "photos";


        public void AddCustomHero(string userId, CustomHero hero)
        {
            firebase
                .Child(Custom)
                .Child(userId)
                .Child(hero.Id)
                .PutAsync(hero)
                .Wait();
        }

        public void DeleteCustomHeroById(string userId, string heroId)
        {
            firebase
                .Child(Custom)
                .Child(userId)
                .Child(heroId)
                .DeleteAsync()
                .Wait();
        }

        public IEnumerable<CustomHero> GetAllCustomHeroes(string userId)
        {
            var listOfCustomHeroes = firebase
                .Child(Custom)
                .Child(userId)
                .OnceAsync<CustomHero>();
            listOfCustomHeroes.Wait();
            return listOfCustomHeroes.Result.Select(i => i.Object);
        }

        public string UploadPhoto(FileStream stream, string photoId)
        {
            var downloadUrl = storage
                .Child(Photos)
                .Child(photoId)
                .PutAsync(stream).GetAwaiter().GetResult();
            return downloadUrl;
        }
    }
}