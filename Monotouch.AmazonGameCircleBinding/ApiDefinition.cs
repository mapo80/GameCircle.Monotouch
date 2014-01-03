using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Monotouch.AmazonGameCircleBinding
{
	[Model, BaseType (typeof (NSObject))]
	public partial interface AIVariation {

		[Export ("projectName")]
		string ProjectName { get; }

		[Export ("name")]
		string Name { get; }

		[Export ("variableAsInt:withDefault:")]
		int VariableAsInt (string variableName, int defaultValue);

		[Export ("variableAsLongLong:withDefault:")]
		long VariableAsLongLong (string variableName, long defaultValue);

		[Export ("variableAsFloat:withDefault:")]
		float VariableAsFloat (string variableName, float defaultValue);

		[Export ("variableAsDouble:withDefault:")]
		double VariableAsDouble (string variableName, double defaultValue);

		[Export ("variableAsBool:withDefault:")]
		bool VariableAsBool (string variableName, bool defaultValue);

		[Export ("variableAsString:withDefault:")]
		string VariableAsString (string variableName, string defaultValue);

		[Export ("containsVariable:")]
		bool ContainsVariable (string variableName);
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface AIInsightsCredentials {

		[Export ("applicationKey")]
		string ApplicationKey { get; }

		[Export ("privateKey")]
		string PrivateKey { get; }
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface AIInsightsOptions {

		[Export ("allowEventCollection")]
		bool AllowEventCollection { get; }

		[Export ("allowWANDelivery")]
		bool AllowWANDelivery { get; }
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface AIEvent {

		[Export ("eventType")]
		string EventType { get; }

		[Export ("addAttribute:forKey:")]
		void AddAttribute (string theValue, string theKey);

		[Export ("addMetric:forKey:")]
		void AddMetric (NSNumber theValue, string theKey);

		[Export ("attributeForKey:")]
		string AttributeForKey (string theKey);

		[Export ("metricForKey:")]
		NSNumber MetricForKey (string theKey);

		[Export ("hasAttributeForKey:")]
		bool HasAttributeForKey (string theKey);

		[Export ("hasMetricForKey:")]
		bool HasMetricForKey (string theKey);

		//[Export ("allAttributes"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/AIEvent.h", Line = 113)]
		[Export ("allAttributes")]
		NSDictionary AllAttributes { get; }

		//[Export ("allMetrics"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/AIEvent.h", Line = 120)]
		[Export ("allMetrics")]
		NSDictionary AllMetrics { get; }
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface AIEventClient {

		[Export ("addGlobalAttribute:forKey:")]
		void AddGlobalAttribute (string theValue, string theKey);

		[Export ("addGlobalAttribute:forKey:forEventType:")]
		void AddGlobalAttribute (string theValue, string theKey, string theEventType);

		[Export ("addGlobalMetric:forKey:")]
		void AddGlobalMetric (NSNumber theValue, string theKey);

		[Export ("addGlobalMetric:forKey:forEventType:")]
		void AddGlobalMetric (NSNumber theValue, string theKey, string theEventType);

		[Export ("removeGlobalAttributeForKey:")]
		void RemoveGlobalAttributeForKey (string theKey);

		[Export ("removeGlobalAttributeForKey:forEventType:")]
		void RemoveGlobalAttributeForKey (string theKey, string theEventType);

		[Export ("removeGlobalMetricForKey:")]
		void RemoveGlobalMetricForKey (string theKey);

		[Export ("removeGlobalMetricForKey:forEventType:")]
		void RemoveGlobalMetricForKey (string theKey, string theEventType);

		[Export ("recordEvent:")]
		void RecordEvent (AIEvent theEvent);

		[Export ("createEventWithEventType:")]
		AIEvent CreateEventWithEventType (string theEventType);

		[Export ("submitEvents")]
		void SubmitEvents ();
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface AIUserProfile {

		[Export ("dimensions")]
		NSDictionary Dimensions { get; }

		[Export ("addDimensionAsNumber:forName:")]
		AIUserProfile AddDimensionAsNumber (NSNumber theValue, string theName);

		[Export ("addDimensionAsString:forName:")]
		AIUserProfile AddDimensionAsString (string theValue, string theName);
	}

	[BaseType (typeof (NSObject))]
	public partial interface AIAmazonInsights {

//		[Export ("abTestClient")]
//		AIABTestClient AbTestClient { get; }

		[Export ("eventClient")]
		AIEventClient EventClient { get; }

		[Export ("userProfile")]
		AIUserProfile UserProfile { get; }

		[Static, Export ("credentialsWithApplicationKey:withPrivateKey:")]
		AIInsightsCredentials CredentialsWithApplicationKey (string theApplicationKey, string thePrivateKey);

		//[Static, Export ("defaultOptions"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/AIAmazonInsights.h", Line = 134)]
		[Static, Export ("defaultOptions")]
		AIInsightsOptions DefaultOptions { get; }

		[Static, Export ("optionsWithAllowEventCollection:withAllowWANDelivery:")]
		AIInsightsOptions OptionsWithAllowEventCollection (bool allowEventCollection, bool allowWANDelivery);

		[Static, Export ("insightsWithCredentials:")]
		AIAmazonInsights InsightsWithCredentials (AIInsightsCredentials theCredentials);

		[Static, Export ("insightsWithCredentials:withOptions:")]
		AIAmazonInsights InsightsWithCredentials (AIInsightsCredentials theCredentials, AIInsightsOptions theOptions);

//		[Static, Export ("insightsWithCredentials:withOptions:withCompletionBlock:")]
//		AIAmazonInsights InsightsWithCredentials (AIInsightsCredentials theCredentials, AIInsightsOptions theOptions, AIInitializationCompletionBlock completionBlock);
	}

	[BaseType (typeof (NSObject))]
	public partial interface AIMonetizationEventBuilder {

		//[Export ("build"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 37)]
		[Export ("build")]
		AIEvent Build { get; }

		//[Export ("isValid"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 43)]
		[Export ("isValid")]
		bool IsValid { get; }

		[Export ("initWithEventClient:")]
		IntPtr Constructor (AIEventClient theEventClient);

		//[Export ("productId"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 55), Verify ("Backing setter method to ObjC property removed: setProductId:", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 61)]
		[Export ("productId")]
		string ProductId { get; set; }

		//[Export ("quantity"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 67), Verify ("Backing setter method to ObjC property removed: setQuantity:", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 73)]
		[Export ("quantity")]
		int Quantity { get; set; }

		//[Export ("itemPrice"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 79), Verify ("Backing setter method to ObjC property removed: setItemPrice:", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 85)]
		[Export ("itemPrice")]
		double ItemPrice { get; set; }

		//[Export ("formattedItemPrice"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 91), Verify ("Backing setter method to ObjC property removed: setFormattedItemPrice:", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 97)]
		[Export ("formattedItemPrice")]
		string FormattedItemPrice { get; set; }

		//[Export ("transactionId"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 103), Verify ("Backing setter method to ObjC property removed: setTransactionId:", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 109)]
		[Export ("transactionId")]
		string TransactionId { get; set; }

		//[Export ("currency"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 115), Verify ("Backing setter method to ObjC property removed: setCurrency:", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 121)]
		[Export ("currency")]
		string Currency { get; set; }

		//[Export ("store"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 128), Verify ("Backing setter method to ObjC property removed: setStore:", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIMonetizationEventBuilder.h", Line = 134)]
		[Export ("store")]
		string Store { get; set; }
	}

	[BaseType (typeof (AIMonetizationEventBuilder))]
	public partial interface AIAppleMonetizationEventBuilder {

		[Static, Export ("builderWithEventClient:")]
		AIAppleMonetizationEventBuilder BuilderWithEventClient (AIEventClient theEventClient);

		[Export ("withProductId:")]
		void WithProductId (string theProductId);

		[Export ("withItemPrice:andPriceLocale:")]
		void WithItemPrice (double theItemPrice, NSLocale thePriceLocale);

		[Export ("withQuantity:")]
		void WithQuantity (int theQuantity);

		[Export ("withTransactionId:")]
		void WithTransactionId (string theTransactionId);

		//[Export ("build"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIAppleMonetizationEventBuilder.h", Line = 129)]
		[Export ("build")]
		AIEvent Build { get; }
	}

	[BaseType (typeof (AIMonetizationEventBuilder))]
	public partial interface AIVirtualMonetizationEventBuilder {

		[Static, Export ("builderWithEventClient:")]
		AIVirtualMonetizationEventBuilder BuilderWithEventClient (AIEventClient theEventClient);

		[Export ("withProductId:")]
		void WithProductId (string theProductId);

		[Export ("withItemPrice:")]
		void WithItemPrice (double theItemPrice);

		[Export ("withQuantity:")]
		void WithQuantity (int theQuantity);

		[Export ("withCurrency:")]
		void WithCurrency (string theCurrency);

		//[Export ("build"), Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/AmazonInsights/AmazonInsightsSDK.framework/Headers/monetization/AIVirtualMonetizationEventBuilder.h", Line = 85)]
		[Export ("build")]
		AIEvent Build { get; }
	}
}

