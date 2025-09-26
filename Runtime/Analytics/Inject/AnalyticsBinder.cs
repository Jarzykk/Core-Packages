using Zenject;

namespace Infrastructure.Services.Analytics.Extensions
{
    public static class AnalyticsBinder
    {
        public static DiContainer BindAnalyticService<TService>(this DiContainer container) where TService : class, IAnalyticService
        {
            container
                .Bind<IAnalyticService>()
                .To<TService>()
                .AsSingle();

            return container;
        }

        public static DiContainer WithProvider<TProvider>(this DiContainer container) where TProvider : class, IAnalyticProvider
        {
            container
                .Bind<IAnalyticProvider>()
                .To<TProvider>()
                .AsSingle()
                .NonLazy();

            return container;
        }
    }
}
