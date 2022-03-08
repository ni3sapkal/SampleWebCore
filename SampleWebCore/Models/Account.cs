using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebCore.Models
{
    public class Attributes
    {
        public string type { get; set; }
        public string url { get; set; }
    }

    public class Account
    {
        public Attributes attributes { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Accounts
    {
        public int totalSize { get; set; }
        public bool done { get; set; }
        public List<Account> records { get; set; }
    }


}
