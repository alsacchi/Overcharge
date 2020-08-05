using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Smod2;


namespace OverchargePlugin
{
	public class OverchargeEvent
	{

		private Plugin plugin;
		private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
		public OverchargeEvent(Plugin plugin)
		{
			this.plugin = plugin;
			
		}

		public async void fire()
		{
			await semaphore.WaitAsync();
			try
			{
				await overcharge();
				plugin.Info("Done Overcharging");
			}
			catch (Exception e)
			{
				plugin.Error(e.Message);
			}
			finally
			{
				semaphore.Release();
			}
				
			
		}
		//cassie automatic over charge in tminus 10 seconds. security systems will be deactivated
		private async Task overcharge()
		{
			int timer = 10000;// new Random().Next(300000, 300000 * 4);
			int overchargeTime = new Random().Next(10, 90);
			plugin.Info($"OverchargeEvent in {timer}, event duration {overchargeTime}");
			await Task.Delay(timer);
			plugin.Server.Map.AnnounceCustomMessage(" bell_start automatic over charge in tminus .g4 second .g1 pitch_0.5 security systems will be pitch_0.25 deactivated bell_end");
			await Task.Delay(15000);
			plugin.Info("Overcharge in progess!");
			plugin.Server.Map.OverchargeLights(overchargeTime, false);
			plugin.Server.Map.GetTeslaGates().ForEach((tesla) => { tesla.TriggerDistance = -1; });
			plugin.Server.Map.GetElevators().ForEach((elevator) => { elevator.Locked = true; });
			await Task.Delay(overchargeTime * 1000);
			plugin.Server.Map.GetTeslaGates().ForEach((tesla) => { tesla.TriggerDistance = 5.5f; });
			plugin.Server.Map.GetElevators().ForEach((elevator) => { elevator.Locked = false; });
			fire();
		}
	}
}
