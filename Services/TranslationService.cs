using System;
using System.Collections.Generic;
using System.Linq;
using MultiLangApp.Models;

namespace MultiLangApp.Services
{
    /**
     * Service Layer Implementation
     * Implements dictionary-based translation.
     */
    public class TranslationService : ITranslationService
    {
        private List<WordPair> _wordPairs;

        public TranslationService()
        {
            // Initialize dictionary with predefined words
            _wordPairs = new List<WordPair>
            {
                new WordPair { English = "hello", Turkish = "merhaba", Arabic = "مرحبا" },
                new WordPair { English = "world", Turkish = "dünya", Arabic = "عالم" },
                new WordPair { English = "good", Turkish = "iyi", Arabic = "جيد" },
                new WordPair { English = "morning", Turkish = "günaydın", Arabic = "صباح الخير" },
                new WordPair { English = "thank you", Turkish = "teşekkür ederim", Arabic = "شكرا لك" },
                new WordPair { English = "teacher", Turkish = "öğretmen", Arabic = "muallim" },
                new WordPair { English = "book", Turkish = "kitap", Arabic = "كتاب" },
                new WordPair { English = "school", Turkish = "okul", Arabic = "مدرسة" },
                new WordPair { English = "student", Turkish = "öğrenci", Arabic = "طالب" },
                new WordPair { English = "computer", Turkish = "bilgisayar", Arabic = "كمبيوتر" },
                new WordPair { English = "apple", Turkish = "elma", Arabic = "تفاحة" },
                new WordPair { English = "water", Turkish = "su", Arabic = "ماء" }
            };
        }

        public string Translate(string input, string fromLang, string toLang)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            // Split sentences into words
            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> translatedWords = new List<string>();

            foreach (string word in words)
            {
                string cleanWord = word.ToLower();
                
                // Find matching pair
                var pair = _wordPairs.FirstOrDefault(p => GetValueByLang(p, fromLang).ToLower() == cleanWord);

                if (pair != null)
                {
                    translatedWords.Add(GetValueByLang(pair, toLang));
                }
                else
                {
                    translatedWords.Add(word); // Keep unknown words unchanged
                }
            }

            return string.Join(" ", translatedWords);
        }

        private string GetValueByLang(WordPair pair, string lang)
        {
            switch (lang)
            {
                case "English": return pair.English;
                case "Turkish": return pair.Turkish;
                case "Arabic": return pair.Arabic;
                default: return string.Empty;
            }
        }
    }
}
