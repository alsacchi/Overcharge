using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Exiled.API.Features;

namespace OverchargePlugin {
	public class OverchargeEvent {
		private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

		public async void fire()
		{
			await semaphore.WaitAsync();
			try
			{
				await overcharge();
				Log.Info("Done Overcharging");
			}
			catch (Exception e)
			{
				Log.Error(e.Message);
			}
			finally
			{
				semaphore.Release();
			}
				
			
		}
		//cassie automatic over charge in tminus 10 seconds. security systems will be deactivated
		private async Task overcharge()
		{
            int overchargeTimer = OverchargePlugin.Instance.Config.overchargeTimer * 60000;
			int timer = new Random().Next(overchargeTimer, overchargeTimer * 4);
            int minimun = OverchargePlugin.Instance.Config.overchargeDurationMin;
            int maximum = OverchargePlugin.Instance.Config.overchargeDurationMax;
			int overchargeTime = new Random().Next(minimun, maximum);
			Log.Info($"OverchargeEvent in {timer/60000}, event duration {overchargeTime}");
			await Task.Delay(timer);
			Cassie.Message("bell_start automatic over charge in tminus .g4 second .g1 pitch_0.5 security systems will be pitch_0.45 deactivated bell_end");
			await Task.Delay(15000);
			Log.Info("Overcharge in progess!");
			Map.TurnOffAllLights(overchargeTime, false);
			foreach (TeslaGate tesla in Map.TeslaGates) { tesla.sizeOfTrigger = -1; }
			foreach (Lift lift in Map.Lifts) { lift.operative = false; }
			await Task.Delay(overchargeTime * 1000);
			foreach (TeslaGate tesla in Map.TeslaGates) { tesla.sizeOfTrigger = 5.5f; }
			foreach (Lift lift in Map.Lifts) { lift.operative = true; }
			fire();
		}
	}
}
