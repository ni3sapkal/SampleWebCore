using Newtonsoft.Json.Linq;
using SampleWebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebCore.Helpers
{
    public class JsonHelper
    {
        public static SalesForceToken ConvertSalesForceToken(dynamic inputJson)
        {
            var parsedToken = JObject.Parse(inputJson);
            SalesForceToken token = new SalesForceToken();
            token.access_token = parsedToken.access_token;
            return token;
        }

        public static Accounts ConvertSalesForceUserList(dynamic inputJson)
        {
            var parsedUsers = JObject.Parse(inputJson);
            Accounts accounts = new Accounts();
            accounts.records = new List<Account>();
            accounts.totalSize = parsedUsers.totalSize;
            accounts.done = parsedUsers.done;
            foreach (var user in parsedUsers.records)
            {
                Account sfUser = new Account();
                sfUser.Name = user.Name;
                sfUser.Id = user.Id;
                accounts.records.Add(sfUser);
            }
            return accounts;
        }
    }
}
