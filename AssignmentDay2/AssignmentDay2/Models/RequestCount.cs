using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDay2.Models
{
    
    
    public static class RequestCount
    {
        private static List<Requests> ReqList=new List<Requests>();
        private static List<Requests> ErrorReqList = new List<Requests>();

        public static void AddCount(string requesturl)
        {

            if (requesturl!="")
            {
                if(!ReqList.Where(x => x.URL.Equals(requesturl)).Any())
                {
                    ReqList.Add(new Requests { URL = requesturl, Count = 1 });
                }
                else
                {
                    var count = ReqList.Where(x => x.URL.Equals(requesturl)).FirstOrDefault().Count;
                    ReqList.Where(x => x.URL.Equals(requesturl)).Select(y => { y.Count = count + 1; return y; } ).ToList();
                }
            }
            
        }
        public static void AddError(string requesturl)
        {

            if (requesturl != "")
            {
                if (!ErrorReqList.Where(x => x.URL.Equals(requesturl)).Any())
                {
                    ErrorReqList.Add(new Requests { URL = requesturl });
                }
               
            }

        }
        public static List<Requests> GetRequests()
        {
            return ReqList;
        }
        public static List<Requests> GetErrorRequests()
        {
            return ErrorReqList;
        }
    }

        public class Requests
        {
            public string URL { get; set; }
            public int Count { get; set; }
        }
}
