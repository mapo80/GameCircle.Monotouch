using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("GameCircle-MD5.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true, IsCxx = true, Frameworks = "AdSupport GameKit MessageUI CoreTelephony SystemConfiguration Security ExternalAccessory Foundation", LinkerFlags="-lsqlite3.0 -lstdc++" )]