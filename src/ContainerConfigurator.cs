using Autofac;
using Legion.Controllers;
using Legion.Model;
using Legion.Model.Helpers;
using Legion.Model.Repositories;
using Legion.View;
using Legion.View.Map;
using Legion.View.Map.Layers;
using Legion.View.Menu;
using Legion.View.Menu.Layers;
using Legion.View.Terrain;
using Microsoft.Xna.Framework;

namespace Legion
{
    public class ContainerConfigurator
    {
        private IContainer container;

        private void RegisterAll(Game game)
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(game).As<Game>();

            //Model
            builder.RegisterType<LegionConfig>().As<ILegionConfig>().SingleInstance();
            builder.RegisterType<LegionInfo>().As<ILegionInfo>().SingleInstance();

            builder.RegisterType<DefinitionsLoader>().As<IDefinitionsLoader>().SingleInstance();
            builder.RegisterType<DefinitionsRepository>().As<IDefinitionsRepository>().SingleInstance();
            builder.RegisterType<AdventuresRepository>().As<IAdventuresRepository>().SingleInstance();
            builder.RegisterType<ArmiesRepository>().As<IArmiesRepository>().SingleInstance();
            builder.RegisterType<CharactersRepository>().As<ICharactersRepository>().SingleInstance();
            builder.RegisterType<CitiesRepository>().As<ICitiesRepository>().SingleInstance();
            builder.RegisterType<PlayersRepository>().As<IPlayersRepository>().SingleInstance();

            builder.RegisterType<InitialDataGenerator>().As<IInitialDataGenerator>().SingleInstance();
            builder.RegisterType<CitiesHelper>().As<ICitiesHelper>().SingleInstance();
            builder.RegisterType<ArmiesHelper>().As<IArmiesHelper>().SingleInstance();

            //Controllers
            builder.RegisterType<MapController>().As<IMapController>().SingleInstance();

            builder.RegisterType<CityIncidents>().As<ICityIncidents>().SingleInstance();
            builder.RegisterType<BattleManager>().As<IBattleManager>().SingleInstance();

            //Main Views
            builder.RegisterType<MenuView>().As<MenuView>().SingleInstance();
            builder.RegisterType<MapView>().As<MapView>().SingleInstance();
            builder.RegisterType<TerrainView>().As<TerrainView>().SingleInstance();

            builder.RegisterType<LayersProvider>().As<ILayersProvider>().SingleInstance();
            // Map Layers:
            builder.RegisterType<MapLayer>().As<MapLayer>().SingleInstance();
            builder.RegisterType<CitiesLayer>().As<CitiesLayer>().SingleInstance();
            builder.RegisterType<ArmiesLayer>().As<ArmiesLayer>().SingleInstance();
            builder.RegisterType<MapGuiLayer>().As<MapGuiLayer>().SingleInstance();
            builder.RegisterType<MessagesLayer>().As<MessagesLayer>().SingleInstance();
            // Menu Layers:
            builder.RegisterType<MenuLayer>().As<MenuLayer>().SingleInstance();

            // Terrain Layers:
            // TODO 

            builder.RegisterType<MapMessagesService>().As<IMapMessagesService>().SingleInstance();

            builder.RegisterType<CitiesTurnProcessor>().As<ICitiesTurnProcessor>().SingleInstance();
            builder.RegisterType<ArmiesTurnProcessor>().As<IArmiesTurnProcessor>().SingleInstance();

            builder.RegisterType<ViewsProvider>().As<IViewsProvider>().SingleInstance();
            builder.RegisterType<StateController>().As<IStateController>().SingleInstance();
            container = builder.Build();
        }

        public void Configure(LegionGame game)
        {
            RegisterAll(game);
            CreateViews(game);

            var initialDataGenerator = container.Resolve<IInitialDataGenerator>();
            initialDataGenerator.GenerateAll();

            var stateController = container.Resolve<IStateController>();
            stateController.EnterMenu();
        }

        public void CreateViews(LegionGame game)
        {
            var menuView = container.Resolve<MenuView>();
            var mapView = container.Resolve<MapView>();
            var terrainView = container.Resolve<TerrainView>();

            game.Components.Add(menuView);
            game.Components.Add(mapView);
            game.Components.Add(terrainView);
        }
    }
}