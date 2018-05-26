using System.Collections.Generic;
using Legion.Gui.Services;
using Legion.Model;
using Legion.Model.Types;
using Legion.Views.Map.Layers;

namespace Legion.Views.Map
{
    public class MapMessagesService : IMessagesService
    {
        private readonly ModalLayer messagesLayer;
        private readonly IGuiServices guiServices;
        private readonly ITextsManager textsManager;
        private readonly Dictionary<TextType, ImageType> dict;

        public MapMessagesService(ModalLayer messagesLayer,
            IGuiServices guiServices,
            ITextsManager textsManager)
        {
            this.messagesLayer = messagesLayer;
            this.guiServices = guiServices;
            this.textsManager = textsManager;
            dict = new Dictionary<TextType, ImageType>();

            LoadData();
        }

        private void LoadData()
        {
            dict.Add(TextType.FireBurnsPeopleAndCity, ImageType.FireBurnsPeopleAndCity);
            dict.Add(TextType.EpidemyInsideCity, ImageType.EpidemyInsideCity);
            dict.Add(TextType.AllFoodsEatenByRats, ImageType.AllFoodsEatenByRats);
            dict.Add(TextType.ChaosWarriorsBurnsCity, ImageType.FireBurnsPeopleAndCity);
        }

        public void ShowMessage(Message message)
        {
            var text = textsManager.Get(message.Type);
            var args = new object[message.MapObjects.Count - 1];
            for (var i = 0; i < message.MapObjects.Count - 1; i++)
            {
                args[i] = message.MapObjects[i + 1].Name;
            }

            var content = string.Format(text, args);
            var title = message.MapObjects[0].Name;
            var imageType = dict[message.Type];
            var image = guiServices.ImagesProvider.GetImage(imageType);

            messagesLayer.Show(title, content, image, message.OnClose);
        }
    }
}