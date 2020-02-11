using System.Collections.Generic;

namespace scm.Service
{
    public class ServiceResult<T>{
        public bool isSuccess{get; set;}
        public T Result { get; set; }
        public List<T> Results {get; set;} //Para recibir una lista de respuest xd
        public List<string> Errors { get; set; }
    }
}