using System.Collections.Generic;
using GameFramework.Network;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace MyGame.Room
{
	/// <summary>
	/// 用于缓存用户的房间信息
	/// </summary>
	[AddComponentMenu("Room")]
    public class RoomComponent : GameFrameworkComponent
	{
		[ShowInInspector]
		private Dictionary<string, INetworkChannel> userNetworkChannels;
		[ShowInInspector]
		private Dictionary<string, Room> userRooms;
		protected override void Awake()
		{
			base.Awake();
			userNetworkChannels=new Dictionary<string, INetworkChannel>();
			userRooms=new Dictionary<string, Room>();
		}

		public void RegisterRoom(string userid, Room room)
		{
			userRooms.Add(userid,room);
		}
		public Dictionary<string, INetworkChannel> GetChannels()
		{
			return userNetworkChannels;
		}
		public bool CheckChannels()
		{
			if (userNetworkChannels.Count<1)
			{
				return false;
			}
			foreach (var channel in userNetworkChannels)
			{
				if (channel.Value==null)
				{
					return false;
				}
			}
			return true;
		}
		public bool CheckIndexIsSelf(string userid,int index)
		{
			if (userRooms.ContainsKey(userid))
			{
				var room = userRooms[userid];
				if (room.players[index-1].userid == userid)
				{
					return true;
				}
			}
			return false;
		}

		public Room GetRoom(string userid)
		{
			return userRooms[userid];
		}
		public INetworkChannel GetNetworkChannel(string userid)
		{
			if (userNetworkChannels.ContainsKey(userid))
			{
				return userNetworkChannels[userid];
			}
			return null;
		}
		public void PreRegisterChannel(INetworkChannel channel)
		{
			userNetworkChannels.Add(channel.Name,null);
		}
		public void RegisterChannel(INetworkChannel channel)
		{
			userNetworkChannels[channel.Name] = channel;
		}
	}
}