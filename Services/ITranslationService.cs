using System;

namespace MultiLangApp.Services
{
    /**
     * Service Layer Interface
     * Defines the translation behavior.
     */
    public interface ITranslationService
    {
        string Translate(string input, string fromLang, string toLang);
    }
}
