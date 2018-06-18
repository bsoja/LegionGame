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
        private readonly ITexts texts;
        private readonly Dictionary<MessageType, ImageType> dict;

        public MapMessagesService(ModalLayer messagesLayer,
            IGuiServices guiServices,
            ITexts texts)
        {
            this.messagesLayer = messagesLayer;
            this.guiServices = guiServices;
            this.texts = texts;
            dict = new Dictionary<MessageType, ImageType>();

            LoadData();
        }

        private void LoadData()
        {
            dict.Add(MessageType.FireInTheCity, ImageType.FireInTheCity);
            dict.Add(MessageType.EpidemyInTheCity, ImageType.EpidemyInTheCity);
            dict.Add(MessageType.RatsInTheCity, ImageType.RatsInTheCity);
            dict.Add(MessageType.ChaosWarriorsBurnedCity, ImageType.ChaosWarriorsBurnedCity);
        }

        public void ShowMessage(Message message)
        {
            var args = new object[message.MapObjects.Count - 1];
            for (var i = 0; i < message.MapObjects.Count - 1; i++)
            {
                args[i] = message.MapObjects[i + 1].Name;
            }

            var text = texts.Get(message.Type.ToString(), args);
            var title = message.MapObjects[0].Name;
            var imageType = dict[message.Type];
            var image = guiServices.ImagesProvider.GetImage(imageType);

            messagesLayer.Show(title, text, image, message.OnClose);
        }
    }
}