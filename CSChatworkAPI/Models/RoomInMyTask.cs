﻿/* See the file "LICENSE" for the full license governing this code. */

using System;
using Newtonsoft.Json;

namespace CSChatworkAPI.Models
{
    /// <summary>
    /// Room
    /// </summary>
    public class RoomInMyTask : IEquatable<RoomInMyTask>
    {
        /// <summary>
        /// room_id
        /// </summary>
        [JsonProperty("room_id")]
        public string RoomId { get; set; }

        /// <summary>
        /// name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// icon_path
        /// </summary>
        [JsonProperty("icon_path")]
        public string IconPath { get; set; }

        #region ReSharper Generated
        /// <summary>
        /// formatting members
        /// </summary>
        public override string ToString()
        {
            return $"icon_path: {IconPath}, name: {Name}, room_id: {RoomId}";
        }

        public bool Equals(RoomInMyTask other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(RoomId, other.RoomId) && string.Equals(Name, other.Name) && string.Equals(IconPath, other.IconPath);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RoomInMyTask)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (RoomId != null ? RoomId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (IconPath != null ? IconPath.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(RoomInMyTask left, RoomInMyTask right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RoomInMyTask left, RoomInMyTask right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}
