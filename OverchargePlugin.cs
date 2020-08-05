using System;
using Exiled.API.Features;
using Exiled.API.Enums;

namespace OverchargePlugin {    
    public class OverchargePlugin : Plugin<Config> {
        private static readonly Lazy<OverchargePlugin> lazyInstance = new Lazy<OverchargePlugin>(() => new OverchargePlugin());
        public static OverchargePlugin Instance => lazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;
        
        private Events.ServerEvents serverEvents;
        private OverchargePlugin() {}

        public override void OnEnabled() {
            registerEvents();
        }

        public override void OnDisabled() {
            unregisterEvents();
        }

        private void registerEvents() {
            serverEvents = new Events.ServerEvents();
            Exiled.Events.Handlers.Server.WaitingForPlayers += serverEvents.onWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted += serverEvents.onRoundStarted;
        }

        private void unregisterEvents() {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= serverEvents.onWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted -= serverEvents.onRoundStarted;

            serverEvents = null;
        }
    }
}