using System.Collections.Generic;

namespace Market.Application.Users.Queries.GetUserList
{
    public class UserListVm
    {
        public int Count
        {
            get
            {
                return Users.Count;
            }
        }

        public IList<UserLookupDto> Users { get; set; }
    }
}
