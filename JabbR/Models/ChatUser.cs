﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JabbR.Models
{
    public class ChatUser
    {
        [Key]
        public int Key { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        // MD5 email hash for gravatar
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string HashedPassword { get; set; }
        public DateTime LastActivity { get; set; }
        public DateTime? LastNudged { get; set; }
        public int Status { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        [StringLength(200)]
        public string AfkNote { get; set; }

        public bool IsAfk { get; set; }

        [StringLength(2)]
        public string Flag { get; set; }

        // List of clients that are currently connected for this user
        public virtual ICollection<ChatClient> ConnectedClients { get; set; }
        public virtual ICollection<ChatRoom> OwnedRooms { get; set; }
        public virtual ICollection<ChatRoom> Rooms { get; set; }

        // Private rooms this user is allowed to go into
        public virtual ICollection<ChatRoom> AllowedRooms { get; set; }

        public ChatUser()
        {
            ConnectedClients = new HashSet<ChatClient>();
            OwnedRooms = new HashSet<ChatRoom>();
            Rooms = new HashSet<ChatRoom>();
            AllowedRooms = new HashSet<ChatRoom>();
        }
    }
}