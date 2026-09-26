using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;
using TD.Utilities;

namespace Mining_Priority
{
	public class Settings : ModSettings
	{
		public bool qualityMining = true;
		public bool qualityDrilling = true;
		public bool qualityMiningIgnoreBusy = false;

		public bool priorityMining = true;
		public bool priorityDrilling = true;
		public bool continueWork = true;
		public bool finishUpDrills = true;
		public float qualityGoodEnough = 1.0f;
		public int refreshCacheTime = 2500;


		public void DoWindowContents(Rect wrect)
		{
			var options = new Listing_Standard();
			string refreshCacheBuffer = refreshCacheTime.ToString();
			options.Begin(wrect.LeftPart(0.7f));

			options.CheckboxLabeled("TD.MineValue".Translate(), ref priorityMining);
			options.CheckboxLabeled("TD.DrillValue".Translate(), ref priorityDrilling);
			options.CheckboxLabeled("TD.SettingPartialyMined".Translate(), ref continueWork);
			options.CheckboxLabeled("TD.SettingFinishUpDrills".Translate(), ref finishUpDrills);
			options.Gap();

			options.CheckboxLabeled("TD.RestrictBest".Translate(), ref qualityMining, "TD.RestrictBestDesc".Translate());
			options.CheckboxLabeled("TD.RestrictBestDrill".Translate(), ref qualityDrilling, "TD.RestrictBestDesc".Translate());
			if (qualityMining || qualityDrilling)
			{
				options.CheckboxLabeled("TD.SettingIgnoreBusy".Translate(), ref qualityMiningIgnoreBusy, "TD.SettingIgnoreBusyDesc".Translate());
				options.SliderLabeled("TD.SettingMinerGoodEnough".Translate(), ref qualityGoodEnough, "{0:P0}", 0, 1, "TD.SettingMinerGoodEnoughDesc".Translate());
				options.Label("TD.SettingRefreshCache".Translate());
				options.TextFieldNumeric( ref refreshCacheTime, ref refreshCacheBuffer);
			}
			options.Gap();

			options.End();
		}
		
		public override void ExposeData()
		{
			Scribe_Values.Look(ref qualityMining, "qualityMining", true);
			Scribe_Values.Look(ref qualityDrilling, "qualityDrilling", true);
			Scribe_Values.Look(ref qualityMiningIgnoreBusy, "qualityMiningIgnoreBusy", false);
			Scribe_Values.Look(ref priorityMining, "priorityMining", true);
			Scribe_Values.Look(ref priorityDrilling, "priorityDrilling", true);
			Scribe_Values.Look(ref continueWork, "continueWork", true);
			Scribe_Values.Look(ref finishUpDrills, "finishUpDrills", true);
			Scribe_Values.Look(ref qualityGoodEnough, "priorityGoodEnough", 1.0f);
			Scribe_Values.Look(ref refreshCacheTime, "refreshCacheTime", 2500);
		}
	}
}