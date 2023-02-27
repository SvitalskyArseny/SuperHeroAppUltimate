using SuperHeroProject.domain.model.custom;

namespace SuperHeroProject.domain.model.market
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public record PlatformHero
    (
        string UserName,
        CustomHero Hero
    );
}