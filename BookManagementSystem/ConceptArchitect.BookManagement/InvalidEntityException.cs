using System;
using System.Runtime.Serialization;

namespace ConceptArchitect.BookManagement
{
    [Serializable]
    public class InvalidEntityException : Exception
    {
        
        public string Id { get; private set; }

       
        public InvalidEntityException(string message, string id):base(message)
        {
        
            this.Id = id;
        }

      
    }
}