using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("AmazonInsightsSDK.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, IsCxx = true, LinkerFlags="-lsqlite3.0 -lstdc++", Frameworks = "AdSupport GameKit MessageUI CoreTelephony SystemConfiguration Security ExternalAccessory Foundation")]
