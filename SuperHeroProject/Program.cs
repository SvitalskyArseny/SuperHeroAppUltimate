using System;
using Ninject;
using Ninject.Modules;
using SuperHeroProject.domain.repositories.interfaces;
using SuperHeroProject.domain.services;
using SuperHeroProject.domain.services.interfaces;
using SuperHeroProject.infrastructure.db;
using SuperHeroProject.infrastructure.repositories;

namespace SuperHeroProject
{
    public static class Program
    {
        public class MainModule : NinjectModule
        {
            public override void Load()
            {
                if (Kernel == null) return;

                Kernel.Bind<AppDatabase>().ToSelf().InSingletonScope();

                Kernel.Bind<ICustomHeroRepository>().To<CustomHeroRepository>().InSingletonScope();
                Kernel.Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
                Kernel.Bind<IHeroRepository>().To<HeroRepository>().InSingletonScope();
                Kernel.Bind<IAuthRepository>().To<AuthRepository>().InSingletonScope();
                Kernel.Bind<IFavouritesRepository>().To<FavouritesRepository>().InSingletonScope();
                Kernel.Bind<IPlatformRepository>().To<PlatformRepository>().InSingletonScope();

                Kernel.Bind<ICustomHeroService>().To<CustomHeroService>().InSingletonScope();
                Kernel.Bind<IHeroService>().To<HeroService>().InSingletonScope();
                Kernel.Bind<IAuthService>().To<AuthService>().InSingletonScope();
                Kernel.Bind<IFavouritesService>().To<FavouritesService>().InSingletonScope();
                Kernel.Bind<IPlatformService>().To<PlatformService>().InSingletonScope();
            }
        }

        public static void Main(string[] args)
        {
            var container = new StandardKernel(new MainModule());
            var rep = container.Get<IPlatformService>();
            var db = container.Get<IUserRepository>();
            var rep1 = container.Get<IFavouritesService>();

            Console.WriteLine(db.GetUser().UserName);
            //var res = rep.AddHeroToPlatform(new CustomHero("hello", "salam222", "", "", new PowerStats(10, 10, 10)));
            var res = rep1.GetAllHeroesFromFavourites();
            //var res = rep.DeleteHeroFromPlatform("hello");
            if (res.Success)
            {
                Console.WriteLine("sheeesh");
                res.Value.ForEach(Console.WriteLine);
            }

            if (res.Failure)
            {
                Console.WriteLine(res.ErrorMessage);
                Console.WriteLine(res.Exception);
            }
        }

        // public static void Main()
        // {
        //     const string filePath =
        //         "/Users/alexanderkuzevanov/Downloads/SuperHeroApp/SuperHeroProject/domain/feature/text_processing/data/example_text.txt";
        //     var file = File.ReadAllText(filePath);
        //     var container = new StandardKernel(new MainModule());
        //     Console.WriteLine("[START]");
        //     var manager = container.Get<ITextCommandManager>();
        //     manager.AddCommand(new TextInfoCommand(file));
        //     var receiver = new SpellCheckerEnglish();
        //     manager.AddCommand(new CheckWordCommand(receiver, file));
        //
        //     var res = manager.ExecuteCommands();
        //     foreach (var a in res)
        //     {
        //         Console.WriteLine(a);
        //     }
        // }
//         public static void Main()
//         {
//             var container = new StandardKernel(new MainModule());
//             Console.WriteLine("[START]");
//             var repository2 = container.Get<IHeroRepository>();
//             var repository = container.Get<IMainRepository>();
//             var res = repository.DeleteHeroFromFavouritesById("52");
//             if (res.Success)
//             {
//                 Console.WriteLine("hello");
//                 // foreach (var h in res.Value)
//                 // {
//                 //     Console.WriteLine(h.Images);
//                 // }
//             }
//
//             // var res = repository3.AddHeroToMarket(new CustomHero("hello", "hello", "hello", "hello",
//             //     new PowerStats(1, 2, 3)), 1000);
//             // if (res.Success)
//             // {
//             //     Console.WriteLine("hello");
//             //     var r = res.Value;
//             //     //Console.WriteLine(r);
//             //     foreach (var h in r)
//             //     {
//             //         Console.WriteLine(h.Name);
//             //     }
//             // }
//             //else
//             // {
//             //Console.WriteLine(Utils.GetErrorMessage(res));
//             // }
//
//             //var h = repository2.GetHeroById("-100");
//             //Console.WriteLine(h.Error);
//             // var heroes = repository.GetAllCustomHeroes();
//             // if (heroes.Failure)
//             // {
//             //     Console.WriteLine("hello");
//             //     Console.WriteLine(heroes.Value);
//             //     Console.WriteLine(heroes.ErrorMessage);
//             //     Console.WriteLine(heroes.Exception);
//             // }
//             //
//             // if (heroes.Success)
//             // {
//             //     Console.WriteLine(heroes.Exception== null);
//             // }
//             // else
//             // {
//             // }
//             // var result = repository.GetHeroById(45);
//             // if (result.IsSuccess)
//             // {
//             //     var hero = result.Value;
//             //
//             //     Console.WriteLine(hero.Images);
//             //     repository2.AddHeroToFavourites(hero);
//             // }
//             // else
//             // {
//             //     Console.WriteLine(result.Errors[0]);
//             // }
//
//             // Result.Try()
//             //Console.WriteLine(result.Connections);
//             //
//             // var myuuid = Guid.NewGuid();
//             // var customHero = new CustomHero(myuuid.ToString(), "hello", "guys", "");
//             // Console.WriteLine(myuuid.ToString());
//
//             // var firebase =
//             //     new FirebaseClient("https://superheroproject-e3e22-default-rtdb.europe-west1.firebasedatabase.app/");
//             // await firebase
//             //     .Child("dinosaurs")
//             //     .Child(customHero.Id)
//             //     .PutAsync(customHero);
//
//             // await firebase
//             //     .Child("dinosaurs")
//             //     .Child("087ec841-eaa5-4eb3-8b2c-b07504181650")
//             //     .DeleteAsync();
//             //Console.WriteLine(myHero.Name);
//
//             // var stream = File.Open(@"C:\Users\Александр\Downloads\spiderman.jpg", FileMode.Open);
//             // Console.WriteLine(stream.Length);
//             // var result = repository.UploadPhoto(stream);
//             // if (result.IsSuccess)
//             // {
//             //     Console.WriteLine(result);
//             // }
//             // var task = new FirebaseStorage("superheroproject-e3e22.appspot.com")
//             //     .Child("random2")
//             //     .Child("spiderman2.jpg")
//             //     .PutAsync(stream);
//
// // Track progress of the upload
//             //task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
//
// // await the task to wait until upload completes and get the download url
//             //var downloadUrl = await task;
//             //Console.WriteLine(downloadUrl);
//
//             //var stream = File.Open(@"C:\Users\you\file.png", FileMode.Open);
//             //var firebase =
//             //new FirebaseClient("https://superheroproject-e3e22-default-rtdb.europe-west1.firebasedatabase.app/");
//             // add new item to list of data and let the client generate new key for you (done offline)
//             // var dino1 = await firebase
//             //     .Child("dinosaurs")
//             //     .Child(hero.Name)
//             //     //.AsRealtimeDatabase<>().Database
//             //     .PostAsync(hero);
//             //
//             // var dinos = await firebase
//             //     .Child("dinosaurs")
//             //     .OrderByKey()
//             //     .OnceAsync<Hero>();
//             // foreach (var dino in dinos)
//             // {
//             //     var h = dino.Object;
//             //     Console.WriteLine($"{dino.Key} is {h.Images}m high.");
//             // }
//             //
//             // var auth = "ABCDE"; // your app secret
//             // var firebaseClient = new FirebaseClient(
//             //     "<URL>",
//             //     new FirebaseOptions
//             //     {
//             //         AuthTokenAsyncFactory = () => Task.FromResult(auth). 
//             //     });
//             //
//             //
//         }
    }
}