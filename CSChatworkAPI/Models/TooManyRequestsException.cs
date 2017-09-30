/* See the file "LICENSE" for the full license governing this code. */

using System;
using Newtonsoft.Json;

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
        [JsonProperty("rate_limit")]
        public RateLimit RateLimit { get; private set; }

        /// <summary>
        /// TooManyRequestsException
        /// </summary>
        /// <param name="rateLimit">RateLimit</param>
        public TooManyRequestsException(RateLimit rateLimit)
        {
            RateLimit = rateLimit;
        }

        #region ReSharper Generated
        /// <summary>
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return $"{base.ToString()}, RateLimit: {RateLimit}";
        }
        #endregion
    }
}
