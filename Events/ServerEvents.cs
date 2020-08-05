using System;
using Exiled.API;
using Exiled.API.Features;
namespace OverchargePlugin.Events {

    class ServerEvents {
        OverchargeEvent overchargeEvent = new OverchargeEvent();
        public void onWaitingForPlayers() {
            Log.Info("Waiting for players!");
        }

        public void onRoundStarted() {
            Log.Info("Round started handler");
            overchargeEvent.fire();
        }
    }

}