using System;

namespace ConceptArchitect.BookManagement
{
    public class IdTool
    {
        internal static string Normalize(string str)
        {
            return str.ToLower().Replace(" ", "-");
        }
    }
}