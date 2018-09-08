using System.Collections.Generic;
using Gui.Services;
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
        private readonly Dictionary<MessageType, string> dict;

        public MapMessagesService(ModalLayer messagesLayer,
            IGuiServices guiServices,
            ITexts texts)
        {
            this.messagesLayer = messagesLayer;
            this.guiServices = guiServices;
            this.texts = texts;
            dict = new Dictionary<MessageType, string>();

            LoadData();
        }

        private void LoadData()
        {
            dict.Add(MessageType.FireInTheCity, "event.fire");
            dict.Add(MessageType.EpidemyInTheCity, "event.epidemy");
            dict.Add(MessageType.RatsInTheCity, "event.rats");
            dict.Add(MessageType.ChaosWarriorsBurnedCity, "event.burnedCity");
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
            var image = guiServices.ImagesStore.GetImage(imageType);

            messagesLayer.Show(title, text, image, message.OnClose);
        }
    }
}