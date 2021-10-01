using System;
using System.Collections.Generic;

namespace Taste.SharedModels.Models
{
    public class ApplicationUserModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public DateTimeOffset? LockOutEndDate { get; set; }

        public ICollection<string>  Roles { get; set; }


    }
}
 