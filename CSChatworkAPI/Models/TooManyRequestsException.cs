using System;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// TooManyRequestsException
    /// </summary>
    public class TooManyRequestsException : Exception
    {
        /// <summary>
        /// RateLimit
        /// </summary>
        public RateLimit RateLimit { get; private set; }

        /// <summary>
        /// TooManyRequestsException
        /// </summary>
        /// <param name="rl">RateLimit</param>
        public TooManyRequestsException(RateLimit rl)
        {
            RateLimit = rl;
        }

        /// <summary>
        /// フォーマット済み文字列を返します
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0}, RateLimit: {1}", base.ToString(), RateLimit);
        }
    }
}
