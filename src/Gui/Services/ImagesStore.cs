using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

namespace Gui.Services
{
    internal class Images
    {
        public List<ImageData> ImagesData { get; set; }
    }

    internal class ImageData
    {
        public string Name { get; set; }
        public List<string> Images { get; set; }
        public int Count { get; set; }
    }

    public class ImagesStore : IImagesStore
    {
        private static readonly string FilePath = Path.Combine("data", "images.json");
        private readonly Images _images;
        private readonly Dictionary<string, List<Texture2D>> _data;

        public ImagesStore()
        {
            _data = new Dictionary<string, List<Texture2D>>();

            var jsonData = File.ReadAllText(FilePath);
            _images = JsonConvert.DeserializeObject<Images>(jsonData);
            if (_images == null)
            {
                throw new Exception("Unable to load images");
            }
        }

        public void LoadContent(Game game)
        {
            foreach (var imageData in _images.ImagesData)
            {
                var list = new List<Texture2D>();
                foreach (var name in imageData.Images)
                {
                    var lastDotIdx = name.LastIndexOf('.');
                    if (imageData.Count > 0 && lastDotIdx >= 0)
                    {
                        var namePart = name.Substring(0, lastDotIdx);
                        var nr = int.Parse(name.Substring(lastDotIdx + 1));
                        for (var i = nr; i < nr + imageData.Count; i++)
                        {
                            list.Add(game.Content.Load<Texture2D>(namePart + "." + i));
                        }
                    }
                    else
                    {
                        list.Add(game.Content.Load<Texture2D>(name));
                    }
                }
                _data.Add(imageData.Name, list);
            }
        }

        public List<string> GetNames()
        {
            return _data.Keys.Select(k => k.ToString()).ToList();
        }

        public Texture2D GetImage(string type)
        {
            return _data[type][0];
        }

        public List<Texture2D> GetImages(string type)
        {
            return _data[type];
        }

    }
}