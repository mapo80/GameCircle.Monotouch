using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("AmazonInsightsSDK.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true)]
//[assembly: LinkWith ("AmazonInsightsSDK.a", LinkTarget.Simulator, ForceLoad = true)]
