﻿using System;
using System.IO;
using Newtonsoft.Json;

namespace Legion.Localization
{
    public class Texts : ITexts
    {
        private static readonly string FilePath = Path.Combine("data", "texts", "texts.{0}.json");
        private const StringComparison IgnoreCase = StringComparison.InvariantCultureIgnoreCase;

        private LocalizedTexts _localizedTexts;
        private readonly ILanguageProvider _languageProvider;

        public Texts(ILanguageProvider languageProvider)
        {
            _languageProvider = languageProvider;
            Load(languageProvider.Language);
            languageProvider.LanguageChanged += lang => Load(lang);
        }

        private void Load(string language)
        {
            var textsJson = File.ReadAllText(string.Format(FilePath, language));
            _localizedTexts = JsonConvert.DeserializeObject<LocalizedTexts>(textsJson);
            if (_localizedTexts == null)
            {
                throw new Exception("Unable to load texts for language " + language);
            }
        }

        public string Get(string key, params object[] args)
        {
            var textPair = _localizedTexts.Texts.Find(t => string.Equals(t.Key, key, IgnoreCase));
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
                normalizedArray[i] = NormalizeChar(text[i]);
            }
            return new String(normalizedArray);
        }

        private char NormalizeChar(char c)
        {
            switch (c)
            {
                case 'ą':
                    return 'a';
                case 'Ą':
                    return 'A';
                case 'ć':
                    return 'c';
                case 'Ć':
                    return 'C';
                case 'ę':
                    return 'e';
                case 'Ę':
                    return 'E';
                case 'ł':
                    return 'l';
                case 'Ł':
                    return 'L';
                case 'ń':
                    return 'n';
                case 'Ń':
                    return 'N';
                case 'ó':
                    return 'o';
                case 'Ó':
                    return 'O';
                case 'ś':
                    return 's';
                case 'Ś':
                    return 'S';
                case 'ż':
                case 'ź':
                    return 'z';
                case 'Ż':
                case 'Ź':
                    return 'Z';
            }
            return c;
        }
    }
}