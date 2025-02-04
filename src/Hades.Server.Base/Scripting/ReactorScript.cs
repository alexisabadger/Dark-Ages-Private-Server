﻿#region

using Darkages.Types;

#endregion

namespace Darkages.Scripting
{
    public abstract class ReactorScript : IScriptBase
    {
        protected ReactorScript(Reactor reactor)
        {
            Reactor = reactor;
        }

        public Reactor Reactor { get; set; }

        public abstract void OnBack(Aisling aisling);

        public abstract void OnClose(Aisling aisling);

        public abstract void OnNext(Aisling aisling);

        public abstract void OnTriggered(Aisling aisling);
    }
}