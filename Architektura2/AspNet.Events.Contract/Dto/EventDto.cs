using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Events.Contract.Dto
{
    public class EventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int EventTypeId { get; set; }

        public List<InvitedFriendDto> InvitedFriends { get; set; }
    }
}
