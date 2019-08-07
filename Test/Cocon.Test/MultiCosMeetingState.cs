using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocon.Test
{
    public enum MultiCosMeetingState
    {
        MeetingEnded = 0,

        MeetingStarting = 1,

        MeetingRunning = 2,

        MeetingPausing = 3,

        MeetingResuming = 4,

        MeetingEnding = 5,

        Error = 6,

        MeetingPrepared = 7
    }
}
