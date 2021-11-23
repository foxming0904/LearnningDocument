using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewSomeCase
{
    public class UserRequest : BaseRequest
    {
        public override string UrlStr { get => BaseUrl + "/UserVisit"; }
        public override int Visits { get; set; }
        public string UserName { get; set; }
        public string Reason { get; set; }
    }
}
