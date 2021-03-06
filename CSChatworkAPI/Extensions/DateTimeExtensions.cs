﻿/* See the file "LICENSE" for the full license governing this code. */

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CSChatworkAPI.Extensions
{
    /// <summary>
    /// DateTimeExtensions
    /// </summary>
    /// <remarks>
    /// http://tech.tanaka733.net/entry/chatwork-api-csharp-with-pcl
    /// http://blog.ch3cooh.jp/entry/20130225/1361776951
    /// </remarks>
    internal static class DateTimeExtensions
    {
        internal static readonly DateTime EpocDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Convert to UnixTime
        /// </summary>
        internal static long ToUnixTime(this DateTime date)
        {
            var delta = date - EpocDateTime;
            if (delta.TotalSeconds < 0)
            {
                throw new ArgumentOutOfRangeException("date", "Unix epoc starts January 1st, 1970");
            }
            return (long)delta.TotalSeconds;
        }

        /// <summary>
        /// Convert to DateTime
        /// </summary>
        internal static DateTime ToDateTime(long unixTime)
        {
            return EpocDateTime.AddSeconds(unixTime);
        }

        /// <summary>
        /// UnixDateTimeConverter
        /// </summary>
        internal class UnixDateTimeConverter : DateTimeConverterBase
        {
            /// <summary>
            /// ReadJson
            /// </summary>
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                    JsonSerializer serializer)
            {
                if (reader.TokenType != JsonToken.Integer)
                {
                    throw new Exception(
                        $"Unexpected token parsing date. Expected Integer, got {reader.TokenType}.");
                }

                var ticks = (long)reader.Value;
                return EpocDateTime.AddSeconds(ticks);
            }

            /// <summary>
            /// WriteJson
            /// </summary>
            public override void WriteJson(JsonWriter writer, object value,
                JsonSerializer serializer)
            {
                if (value is DateTime)
                {
                    var ticks = ((DateTime)value).ToUnixTime();
                    writer.WriteValue(ticks);
                }
                else
                {
                    throw new Exception("Expected date object value.");
                }
            }
        }
    }
}
