using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Events.Contract.Dto
{
    public class EventDtoResult
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<InvitedFriendDto> InvitedFriends { get; set; }
    }
}
