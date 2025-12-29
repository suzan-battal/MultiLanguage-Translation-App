import { wordPairs } from './words.js';

/**
 * Service Layer: TranslationService
 * Implements dictionary-based translation logic.
 */
export class TranslationService {
    /**
     * Translates input text from one language to another.
     * @param {string} input - The text to translate.
     * @param {string} fromLang - Source language (english, turkish, arabic).
     * @param {string} toLang - Target language (english, turkish, arabic).
     * @returns {string} - The translated text.
     */
    translate(input, fromLang, toLang) {
        if (!input) return "";

        const sourceLang = fromLang.toLowerCase();
        const targetLang = toLang.toLowerCase();

        console.log("Translating:", input);
        console.log("From:", sourceLang, "To:", targetLang);

        // Split text into words (handling punctuation simply for this demo)
        const words = input.split(/\s+/);

        const translatedWords = words.map(word => {
            // Remove punctuation for lookup
            const cleanWord = word.toLowerCase().replace(/[.,!?;:]/g, "");
            const punctuation = word.slice(cleanWord.length) || word.match(/[.,!?;:]/g)?.join("") || "";

            const pair = wordPairs.find(p => p[sourceLang] && p[sourceLang].toLowerCase() === cleanWord);

            console.log("Word:", cleanWord, "Found:", pair ? "YES" : "NO");

            if (pair) {
                return pair[targetLang] + punctuation;
            } else {
                return word; // Keep unknown words unchanged
            }
        });

        return translatedWords.join(" ");
    }
}
