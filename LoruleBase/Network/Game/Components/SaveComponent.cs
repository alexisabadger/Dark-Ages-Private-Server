﻿#region

using Darkages.Network.ServerFormats;
using Darkages.Types;
using System;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Darkages.Network.Game.Components
{
    public class SaveComponent : GameServerComponent
    {
        private readonly GameServerTimer _timer;

        public SaveComponent(GameServer server) : base(server)
        {
            _timer = new GameServerTimer(TimeSpan.FromSeconds(45));
        }

        public override UpdateType UpdateMethodType => UpdateType.Sync;

        public override Task Update(TimeSpan elapsedTime)
        {
            _timer.Update(elapsedTime);

            if (_timer.Elapsed)
            {
                ServerContextBase.SaveCommunityAssets();

                if (ServerContextBase.Game != null)
                    if (ServerContextBase.Game.Clients != null)
                        foreach (var client in ServerContextBase.Game.Clients)
                        {
                            client?.Save();
                        }

                _timer.Reset();
            }

            return Task.CompletedTask;
        }
    }
}