using System;

namespace MultiLangApp.Models
{
    /**
     * Model Layer
     * Represents a single word in three languages.
     */
    public class WordPair
    {
        public string English { get; set; }
        public string Turkish { get; set; }
        public string Arabic { get; set; }
    }
}
