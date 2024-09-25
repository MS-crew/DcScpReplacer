namespace DcScpReplacer
{
    using System;
    using Exiled.API.Features;
    using PlayerHandlers = Exiled.Events.Handlers.Player;
    using ServerHandlers = Exiled.Events.Handlers.Server;
    public class Plugin : Plugin<Config, Translation>
    {
        private EventHandlers eventHandlers;
        public static Plugin Instance { get; private set; }

        public override string Author => "ZurnaSever";

        public override string Name => "DcScpReplacer";

        public override string Prefix => "DcScpReplacer";

        public override Version RequiredExiledVersion { get; } = new Version(8, 11, 0);

        public override Version Version { get; } = new Version(1, 2, 0);

        public override void OnEnabled()
        {
            Instance = this;
            eventHandlers = new EventHandlers(this);
            ServerHandlers.WaitingForPlayers += eventHandlers.OnWaitingForPlayers;
            PlayerHandlers.Left += eventHandlers.OnLeft;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            ServerHandlers.WaitingForPlayers -= eventHandlers.OnWaitingForPlayers;
            PlayerHandlers.Left -= eventHandlers.OnLeft;
            eventHandlers = null;
            Instance = null;
            base.OnDisabled();
        }
    }
}
