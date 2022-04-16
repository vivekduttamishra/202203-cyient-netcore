using System;
using System.ComponentModel.DataAnnotations;

namespace ConceptArchitect.Utils
{
    public class WordCountAttribute : ValidationAttribute
    {
        public int Min { get; set; } = -1;
        public int Max { get; set; } = -1;
        public WordCountAttribute()
        {
            ErrorMessage = "Invalid World Count";
        }
        public override bool IsValid(object value)
        {
            var text = value as string;

            if (string.IsNullOrEmpty(text))
                return true; //I don't handle required. I will check only if there is a text

            var wordCount = text.Split().Length;

            if (Min > 0 && wordCount < Min)
                return false;

            if (Max > 0 && wordCount > Max)
                return false;

            return true;


        }
    }
}
