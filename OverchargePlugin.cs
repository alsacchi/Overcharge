using Smod2;
using Smod2.API;
using Smod2.Attributes;
using Smod2.Config;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.Lang;
using Smod2.Piping;

namespace OverchargePlugin
{
	[PluginDetails(
		author = "Matteo",
		name = "Overcharge",
		description = "Fire overcharge randomly over time",
		id = "com.matteo.overcharge",
		configPrefix = "ov",
		langFile = "overcharge_lang",
		version = "1.0",
		SmodMajor = 3,
		SmodMinor = 4,
		SmodRevision = 0
		)]
	public class OverchargePlugin : Plugin
	{
		public OverchargeEvent overchargeEvent;
		public override void OnDisable()
		{
			this.Info(this.Details.name + " was disabled ):");
		}

		public override void OnEnable()
		{
			this.Info(this.Details.name + " has loaded :)");
			overchargeEvent = new OverchargeEvent(this);

		}

		public override void Register()
		{
			// Register multiple events
			this.AddEventHandlers(new RoundEventHandler(this));
		}

	}
}
