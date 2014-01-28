﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aura.Channel.World.Entities;
using Aura.Shared.Network;
using Aura.Channel.World;
using Aura.Shared.Mabi.Const;

namespace Aura.Channel.Network.Sending
{
	public static partial class Send
	{
		/// <summary>
		/// Sends MoonGateInfoRequestR to creature's client.
		/// </summary>
		/// <param name="creature"></param>
		public static void MoonGateInfoRequestR(Creature creature)
		{
			var packet = new Packet(Op.MoonGateInfoRequestR, creature.EntityId);
			//packet.PutString("_moongate_tara_west");
			//packet.PutString("_moongate_tirchonaill");

			creature.Client.Send(packet);
		}

		/// <summary>
		/// Sends MailsRequestR to creature's client.
		/// </summary>
		/// <param name="creature"></param>
		public static void MailsRequestR(Creature creature)
		{
			var packet = new Packet(Op.MailsRequestR, creature.EntityId);
			// ...

			creature.Client.Send(packet);
		}

		/// <summary>
		/// Sends SosButtonRequestR to creature's client.
		/// </summary>
		/// <param name="creature"></param>
		/// <param name="enabled"></param>
		public static void SosButtonRequestR(Creature creature, bool enabled)
		{
			var packet = new Packet(Op.SosButtonRequestR, creature.EntityId);
			packet.PutByte(enabled);

			creature.Client.Send(packet);
		}

		/// <summary>
		/// Sends HomesteadInfoRequestR to creature's client.
		/// </summary>
		/// <param name="creature"></param>
		public static void HomesteadInfoRequestR(Creature creature)
		{
			var packet = new Packet(Op.HomesteadInfoRequestR, creature.EntityId);
			packet.PutByte(0);
			packet.PutByte(0);
			packet.PutByte(1);

			creature.Client.Send(packet);
		}

		/// <summary>
		/// Sends Disappear to creature's client.
		/// </summary>
		/// <remarks>
		/// Should this be broadcasted? What does it even do? TODO.
		/// </remarks>
		/// <param name="creature"></param>
		public static void Disappear(Creature creature)
		{
			var packet = new Packet(Op.Disappear, MabiId.Channel);
			packet.PutLong(creature.EntityId);

			creature.Client.Send(packet);
		}

		/// <summary>
		/// Sends ChannelLoginUnkR to creature's client.
		/// </summary>
		/// <param name="creature"></param>
		public static void ChannelLoginUnkR(Creature creature)
		{
			var packet = new Packet(Op.ChannelLoginUnkR, creature.EntityId);
			packet.PutByte(1); // success?
			packet.PutInt(0);
			packet.PutInt(0);

			creature.Client.Send(packet);
		}

		/// <summary>
		/// Sends WarpDateUnkR to creature's client.
		/// </summary>
		/// <param name="creature"></param>
		public static void ContinentWarpDateUnkR(Creature creature)
		{
			var packet = new Packet(Op.ContinentWarpDateUnkR, creature.EntityId);
			packet.PutByte(1);

			// Alternative structure: (Conti and Nao warps)
			// 001 [..............00]  Byte   : 0
			// 002 [000039BA86EA43C0]  Long   : 000039BA86EA43C0 // 2012-May-22 15:30:00
			// 003 [000039BA86FABE80]  Long   : 000039BA86FABE80 // 2012-May-22 15:48:00

			creature.Client.Send(packet);
		}
	}
}
