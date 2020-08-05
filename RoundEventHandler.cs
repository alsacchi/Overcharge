using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;

namespace OverchargePlugin
{
	class RoundEventHandler : IEventHandlerWaitingForPlayers, IEventHandlerRoundStart, IEventHandlerRoundEnd
	{
		private readonly OverchargePlugin plugin;

		public RoundEventHandler(OverchargePlugin plugin) => this.plugin = plugin; //Expression bodies can also be used
		
		public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
		{

		}

		public void OnRoundEnd(RoundEndEvent ev)
		{
			plugin.Info("ROUND END EVENT CALLER");
		}

		public void OnRoundStart(RoundStartEvent ev)
		{
			plugin.Info("ROUND START EVENT CALLER");
			plugin.overchargeEvent.fire();
		}
	}
}
