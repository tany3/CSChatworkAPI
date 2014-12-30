using System;

namespace CSChatworkAPI.Models
{
    public class TooManyRequestsException : Exception
    {
        public RateLimit RateLimit { get; private set; }

        public TooManyRequestsException(RateLimit rl)
        {
            RateLimit = rl;
        }

        public override string ToString()
        {
            return string.Format("{0}, RateLimit: {1}", base.ToString(), RateLimit);
        }
    }
}
