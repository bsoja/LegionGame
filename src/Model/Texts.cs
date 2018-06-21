using System;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Legion.Model
{
    public class Texts : ITexts
    {
        private static readonly string FilePath = Path.Combine("data", "texts", "texts.{0}.json");
        private const StringComparison IgnoreCase = StringComparison.InvariantCultureIgnoreCase;

        private readonly ILegionConfig legionConfig;
        private LocalizedTexts localizedTexts;

        public Texts(ILegionConfig legionConfig)
        {
            this.legionConfig = legionConfig;

            legionConfig.LanguageChanged += Load;
            Load(legionConfig.Language);
        }

        private void Load(string language)
        {
            var textsJson = File.ReadAllText(string.Format(FilePath, language));
            localizedTexts = JsonConvert.DeserializeObject<LocalizedTexts>(textsJson);
            if (localizedTexts == null)
            {
                throw new Exception("Unable to load texts for language " + language);
            }
        }

        public string Get(string key, params object[] args)
        {
            var textPair = localizedTexts.Texts.Find(t => string.Equals(t.Key, key, IgnoreCase));
            if (textPair == null)
            {
                return string.Empty;
            }
            var text = textPair.Value;
            if (args != null && args.Length > 0)
            {
                text = string.Format(text, args);
            }
            //TODO: hack!!! current font doesn't support polish characters, for now we just remove them!
            text = RemovePolishCharacters(text);
            return text;
        }

        private string RemovePolishCharacters(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            var normalizedArray = new char[text.Length];
            for (var i = 0; i < text.Length; i++)
            {
                normalizedArray[i] = normalizeChar(text[i]);
            }
            return new String(normalizedArray);
        }

        private char normalizeChar(char c)
        {
            switch (c)
            {
                case 'ą':
                    return 'a';
                case 'ć':
                    return 'c';
                case 'ę':
                    return 'e';
                case 'ł':
                    return 'l';
                case 'ń':
                    return 'n';
                case 'ó':
                    return 'o';
                case 'ś':
                    return 's';
                case 'ż':
                case 'ź':
                    return 'z';
            }
            return c;
        }
    }
}