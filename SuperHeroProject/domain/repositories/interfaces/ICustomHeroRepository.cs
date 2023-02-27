using System.Collections.Generic;
using System.IO;
using SuperHeroProject.domain.model.custom;

namespace SuperHeroProject.domain.repositories.interfaces
{
    public interface ICustomHeroRepository
    {
        public void AddCustomHero(string userId, CustomHero hero);
        public void DeleteCustomHeroById(string userId, string heroId);
        public IEnumerable<CustomHero> GetAllCustomHeroes(string userId);
        public string UploadPhoto(FileStream stream, string photoId);
    }
}