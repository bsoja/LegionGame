using Autofac;
using Gui.Services;
using Legion.Archive;
using Legion.Controllers.Map;
using Legion.Controllers.Terrain;
using Legion.Localization;
using Legion.Model;
using Legion.Model.Helpers;
using Legion.Model.Repositories;
using Legion.Views;
using Legion.Views.Map;
using Legion.Views.Map.Layers;
using Legion.Views.Menu;
using Legion.Views.Menu.Layers;
using Legion.Views.Terrain;
using Legion.Views.Terrain.Layers;

namespace Legion
{
    public class ContainerConfigurator
    {
        private IContainer _container;

        private void RegisterAll(LegionGame game)
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(game).As<IGuiServices>().As<IViewSwitcher>();

            //Model
            builder.RegisterType<LegionConfig>().As<ILegionConfig>().SingleInstance();
            builder.RegisterType<LegionInfo>().As<ILegionInfo>().SingleInstance();
            builder.RegisterType<LanguageProvider>().As<ILanguageProvider>().SingleInstance();
            builder.RegisterType<Texts>().As<ITexts>().SingleInstance();

            builder.RegisterType<DefinitionsRepository>().As<IDefinitionsRepository>().SingleInstance();
            builder.RegisterType<AdventuresRepository>().As<IAdventuresRepository>().SingleInstance();
            builder.RegisterType<ArmiesRepository>().As<IArmiesRepository>().SingleInstance();
            builder.RegisterType<CharactersRepository>().As<ICharactersRepository>().SingleInstance();
            builder.RegisterType<CitiesRepository>().As<ICitiesRepository>().SingleInstance();
            builder.RegisterType<PlayersRepository>().As<IPlayersRepository>().SingleInstance();

            builder.RegisterType<InitialDataGenerator>().As<IInitialDataGenerator>().SingleInstance();
            builder.RegisterType<GameArchive>().As<IGameArchive>().SingleInstance();
            builder.RegisterType<BytesHelper>().As<IBytesHelper>().SingleInstance();

            builder.RegisterType<CitiesHelper>().As<ICitiesHelper>().SingleInstance();
            builder.RegisterType<ArmiesHelper>().As<IArmiesHelper>().SingleInstance();

            //Controllers
            builder.RegisterType<MapController>().As<IMapController>().SingleInstance();
            builder.RegisterType<TerrainController>().As<ITerrainController>().SingleInstance();

            builder.RegisterType<CityIncidents>().As<ICityIncidents>().SingleInstance();
            builder.RegisterType<BattleManager>().As<IBattleManager>().SingleInstance();

            builder.RegisterType<MapCityGuiFactory>().As<IMapCityGuiFactory>().SingleInstance();
            builder.RegisterType<MapArmyGuiFactory>().As<IMapArmyGuiFactory>().SingleInstance();
            builder.RegisterType<CommonMapGuiFactory>().As<ICommonMapGuiFactory>().SingleInstance();

            //Main Views
            builder.RegisterType<ViewsManager>().As<IViewsManager>();
            builder.RegisterType<LegionViewsManager>().As<ILegionViewsManager>();

            builder.RegisterType<MenuView>().As<MenuView>().SingleInstance();
            builder.RegisterType<MapView>().As<MapView>().SingleInstance();
            builder.RegisterType<TerrainView>().As<TerrainView>().SingleInstance();
            // Map Layers:
            builder.RegisterType<MapLayer>().As<MapLayer>().SingleInstance();
            builder.RegisterType<CitiesLayer>().As<CitiesLayer>().SingleInstance();
            builder.RegisterType<ArmiesLayer>().As<ArmiesLayer>().SingleInstance();
            builder.RegisterType<MapGuiLayer>().As<MapGuiLayer>().SingleInstance();
            builder.RegisterType<DrawingLayer>().As<DrawingLayer>().SingleInstance();
            builder.RegisterType<ModalLayer>().As<ModalLayer>().SingleInstance();
            // Menu Layers:
            builder.RegisterType<MenuLayer>().As<MenuLayer>().SingleInstance();

            // Terrain Layers:
            builder.RegisterType<TerrainLayer>().As<TerrainLayer>().SingleInstance();
            builder.RegisterType<CharactersLayer>().As<CharactersLayer>().SingleInstance();

            builder.RegisterType<MapMessagesService>().As<IMessagesService>().SingleInstance();
            builder.RegisterType<MapServices>().As<IMapServices>().SingleInstance();

            builder.RegisterType<CitiesTurnProcessor>().As<ICitiesTurnProcessor>().SingleInstance();
            builder.RegisterType<ArmiesTurnProcessor>().As<IArmiesTurnProcessor>().SingleInstance();

            _container = builder.Build();
        }

        public void Configure(LegionGame game)
        {
            RegisterAll(game);

            game.ViewsManager = _container.Resolve<ILegionViewsManager>();
            game.GameLoaded += () =>
            {
                var initialDataGenerator = _container.Resolve<IInitialDataGenerator>();
                initialDataGenerator.Generate();

                ////var archivePath = "/home/bartosz/Pobrane/dh0/legion/Legion/Archiwum/zapis 1";
                //var archivePath = "/home/bartosz/Pobrane/_legion.lha/legion/Archiwum/Zapis 5";
                //var gameArchive = container.Resolve<IGameArchive>();
                //gameArchive.LoadGame(archivePath);

                game.OpenMenu();
                //game.OpenTerrain(new TerrainActionContext)
                //game.OpenMap(null);
            };
        }
    }
}