namespace SuperHeroProject.domain.model.user
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public record User(
        int Id,
        string UserId,
        string UserName,
        string Password,
        int AmountOfCoins
    );
}