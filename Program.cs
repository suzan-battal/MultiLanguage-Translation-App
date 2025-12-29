using System;
using MultiLangApp.Services;

namespace MultiLangApp
{
    /**
     * Entry Point
     * Console demonstration of the translation service
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Çoklu Dil Çeviri Uygulaması ===\n");
            
            // Initialize the translation service
            ITranslationService translationService = new TranslationService();
            
            // Test 1: English to Turkish
            Console.WriteLine("Test 1: English → Turkish");
            string input1 = "hello world";
            string output1 = translationService.Translate(input1, "English", "Turkish");
            Console.WriteLine($"Input:  {input1}");
            Console.WriteLine($"Output: {output1}\n");
            
            // Test 2: Turkish to Arabic
            Console.WriteLine("Test 2: Turkish → Arabic");
            string input2 = "merhaba öğretmen";
            string output2 = translationService.Translate(input2, "Turkish", "Arabic");
            Console.WriteLine($"Input:  {input2}");
            Console.WriteLine($"Output: {output2}\n");
            
            // Test 3: English to Arabic
            Console.WriteLine("Test 3: English → Arabic");
            string input3 = "good morning teacher";
            string output3 = translationService.Translate(input3, "English", "Arabic");
            Console.WriteLine($"Input:  {input3}");
            Console.WriteLine($"Output: {output3}\n");
            
            // Test 4: Unknown words
            Console.WriteLine("Test 4: Bilinmeyen kelimeler (English → Turkish)");
            string input4 = "hello universe";
            string output4 = translationService.Translate(input4, "English", "Turkish");
            Console.WriteLine($"Input:  {input4}");
            Console.WriteLine($"Output: {output4}");
            Console.WriteLine("(Not: 'universe' sözlükte olmadığı için değişmedi)\n");
            
            Console.WriteLine("Testler tamamlandı!");
            Console.ReadLine();
        }
    }
}
