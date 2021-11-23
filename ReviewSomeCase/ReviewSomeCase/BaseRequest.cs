using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewSomeCase
{
    public class BaseRequest
    {
        public string BaseUrl {get=> "local"; }
        public virtual string  UrlStr { get; set; }
        public virtual int Visits { get; set; } 
    }
}
