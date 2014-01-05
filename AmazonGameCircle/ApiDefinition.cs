using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace AmazonGameCircle {

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

		[Export ("allAttributes")]
		NSDictionary AllAttributes { get; }

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

		[Export ("build")]
		AIEvent Build { get; }

		[Export ("isValid")]
		bool IsValid { get; }

		[Export ("initWithEventClient:")]
		IntPtr Constructor (AIEventClient theEventClient);

		[Export ("productId")]
		string ProductId { get; set; }

		[Export ("quantity")]
		int Quantity { get; set; }

		[Export ("itemPrice")]
		double ItemPrice { get; set; }

		[Export ("formattedItemPrice")]
		string FormattedItemPrice { get; set; }

		[Export ("transactionId")]
		string TransactionId { get; set; }

		[Export ("currency")]
		string Currency { get; set; }

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
		
	//GAMECIRCLE

	[BaseType (typeof (NSObject))]
	public partial interface AGAchievementDescription {

		[Export ("achievementID", ArgumentSemantic.Copy)]
		string AchievementID { get; }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; }

		[Export ("detailText", ArgumentSemantic.Copy)]
		string DetailText { get; }

		[Export ("index")]
		int Index { get; }

		[Export ("points")]
		int Points { get; }

		[Export ("hidden")]
		bool Hidden { get; }

		[Export ("progress")]
		float Progress { get; }

		[Export ("unlocked")]
		bool Unlocked { [Bind ("isUnlocked")] get; }

		[Export ("unlockedDate", ArgumentSemantic.Retain)]
		NSDate UnlockedDate { get; }

		[Export ("imageURL", ArgumentSemantic.Copy)]
		NSUrl ImageURL { get; }
	}

	public delegate void AllDescriptionsCallback (NSArray descriptions, NSError error);
	public delegate void DescriptionCallback (AGAchievementDescription description, NSError error);
	public delegate void UpdateWithProgressCallback (bool newlyUnlocked, NSError error);

	[BaseType (typeof (NSObject))]
	public partial interface AGAchievement {

		[Export ("achievementID", ArgumentSemantic.Copy)]
		string AchievementID { get; }

		[Static, Export ("achievementWithID:")]
		AGAchievement AchievementWithID (string achievementID);

		[Static, Export ("allDescriptionsWithCompletionHandler:")]
		void AllDescriptionsWithCompletionHandler (AllDescriptionsCallback completionHandler);

		[Export ("descriptionWithCompletionHandler:")]
		void DescriptionWithCompletionHandler (DescriptionCallback completionHandler);

		[Export ("updateWithProgress:completionHandler:")]
		void UpdateWithProgress (float percentComplete, UpdateWithProgressCallback completionHandler);

		[Field ("AGLeaderboardFilterFriendsAllTime", "__Internal")]
		NSString AGLeaderboardFilterFriendsAllTime { get; }

		[Field ("AGLeaderboardFilterGlobalAllTime", "__Internal")]
		NSString AGLeaderboardFilterGlobalAllTime { get; }

		[Field ("AGLeaderboardFilterGlobalDay", "__Internal")]
		NSString AGLeaderboardFilterGlobalDay { get; }

		[Field ("AGLeaderboardFilterGlobalWeek", "__Internal")]
		NSString AGLeaderboardFilterGlobalWeek { get; }

		[Field ("AGScoreFormatDuration", "__Internal")]
		NSString AGScoreFormatDuration { get; }

		[Field ("AGScoreFormatNumeric", "__Internal")]
		NSString AGScoreFormatNumeric { get; }

		[Field ("AGScoreFormatUnknown", "__Internal")]
		NSString AGScoreFormatUnknown { get; }
	}

//	[Model, BaseType (typeof (NSObject))]
//	public partial interface AGSyncableAccumulatingNumber {
//
//		[Export ("value", ArgumentSemantic.Retain)]
//		NSNumber Value { get; }
//
//		[Export ("incrementValue:")]
//		void IncrementValue (NSNumber delta);
//
//		[Export ("decrementValue:")]
//		void DecrementValue (NSNumber delta);
//	}
//
//	[Model, BaseType (typeof (NSObject))]
//	public partial interface AGSyncableDeveloperString {
//
//		[Export ("inConflict")]
//		bool InConflict { get; }
//
//		[Export ("isSet")]
//		bool IsSet { get; }
//
//		[Export ("cloudValue", ArgumentSemantic.Copy)]
//		string CloudValue { get; }
//
//		[Export ("value", ArgumentSemantic.Copy)]
//		string Value { get; set; }
//
//		[Export ("markAsResolved")]
//		void MarkAsResolved ();
//	}
//
//	[Model, BaseType (typeof (NSObject))]
//	public partial interface AGSyncableElement {
//
//		[Export ("timestamp", ArgumentSemantic.Retain)]
//		NSDate Timestamp { get; }
//
//		[Export ("metadata", ArgumentSemantic.Retain)]
//		NSDictionary Metadata { get; }
//	}
//
//	[Model]
//	public partial interface AGSyncableNumberElement : AGSyncableElement {
//
//		[Export ("value", ArgumentSemantic.Retain)]
//		NSNumber Value { get; }
//	}
//
//	[Model]
//	public partial interface AGSyncableNumber : AGSyncableNumberElement {
//
//		[Export ("isSet")]
//		bool IsSet { get; }
//
//		[Export ("value")]//]//, Verify ("ObjC method massaged into setter property", "/Users/matteo/Desktop/Headers/AGSyncableNumber.h", Line = 35)]
//		NSNumber Value { set; }
//
//		[Export ("setValue:withMetadata:")]
//		void SetValue (NSNumber value, NSDictionary metadata);
//	}
//
//	[Model, BaseType (typeof (NSObject))]
//	public partial interface AGSyncableList {
//
//		[Export ("isSet")]
//		bool IsSet { get; }
//
//		[Export ("capacity")]
//		int Capacity { get; set; }
//
//		[Export ("values")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGSyncableList.h", Line = 41)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGSyncableList.h", Line = 41)]
//		NSObject [] Values { get; }
//	}
//
//	[Model]
//	public partial interface AGSyncableNumberList : AGSyncableList {
//
//		[Export ("addValue:")]
//		void AddValue (NSNumber value);
//
//		[Export ("addValue:withMetadata:")]
//		void AddValue (NSNumber value, NSDictionary metadata);
//	}
//
//	[Model]
//	public partial interface AGSyncableStringElement : AGSyncableElement {
//
//		[Export ("value", ArgumentSemantic.Copy)]
//		string Value { get; }
//	}
//
//	[Model]
//	public partial interface AGSyncableString : AGSyncableStringElement {
//
//		[Export ("isSet")]
//		bool IsSet { get; }
//
//		[Export ("value")]//, Verify ("ObjC method massaged into setter property", "/Users/matteo/Desktop/Headers/AGSyncableString.h", Line = 31)]
//		string Value { set; }
//
//		[Export ("setValue:withMetadata:")]
//		void SetValue (string value, NSDictionary metadata);
//	}
//
//	[Model]
//	public partial interface AGSyncableStringList : AGSyncableList {
//
//		[Export ("addValue:")]
//		void AddValue (string value);
//
//		[Export ("addValue:withMetadata:")]
//		void AddValue (string value, NSMutableDictionary metadata);
//	}
//
//	[Model, BaseType (typeof (NSObject))]
//	public partial interface AGSyncableStringSet {
//
//		[Export ("isSet")]
//		bool IsSet { get; }
//
//		[Export ("addValue:")]
//		void AddValue (string value);
//
//		[Export ("addValue:withMetadata:")]
//		void AddValue (string value, NSMutableDictionary metadata);
//
//		[Export ("contains:")]
//		bool Contains (string value);
//
//		[Export ("valueWithName:")]
//		AGSyncableStringElement ValueWithName (string name);
//
//		[Export ("values")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGSyncableStringSet.h", Line = 70)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGSyncableStringSet.h", Line = 70)]
//		NSObject [] Values { get; }
//	}
//
//	[BaseType (typeof (NSObject))]
//	public partial interface AGGameDataMap {
//
//		[Export ("highestNumberForKey:")]
//		AGSyncableNumber HighestNumberForKey (string key);
//
//		[Export ("allHighestNumberKeys")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 57)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 57)]
//		NSObject [] AllHighestNumberKeys { get; }
//
//		[Export ("lowestNumberForKey:")]
//		AGSyncableNumber LowestNumberForKey (string key);
//
//		[Export ("allLowestNumberKeys")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 79)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 79)]
//		NSObject [] AllLowestNumberKeys { get; }
//
//		[Export ("latestNumberForKey:")]
//		AGSyncableNumber LatestNumberForKey (string key);
//
//		[Export ("allLatestNumberKeys")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 101)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 101)]
//		NSObject [] AllLatestNumberKeys { get; }
//
//		[Export ("highNumberListForKey:")]
//		AGSyncableNumberList HighNumberListForKey (string key);
//
//		[Export ("allHighNumberListKeys")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 124)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 124)]
//		NSObject [] AllHighNumberListKeys { get; }
//
//		[Export ("lowNumberListForKey:")]
//		AGSyncableNumberList LowNumberListForKey (string key);
//
//		[Export ("allLowNumberListKeys")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 147)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 147)]
//		NSObject [] AllLowNumberListKeys { get; }
//
//		[Export ("latestNumberListForKey:")]
//		AGSyncableNumberList LatestNumberListForKey (string key);
//
//		[Export ("allLatestNumberListKeys")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 171)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 171)]
//		NSObject [] AllLatestNumberListKeys { get; }
//
//		[Export ("accumulatingNumberForKey:")]
//		AGSyncableAccumulatingNumber AccumulatingNumberForKey (string key);
//
//		[Export ("allAccumulatingNumberKeys")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 193)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 193)]
//		NSObject [] AllAccumulatingNumberKeys { get; }
//
//		[Export ("latestStringForKey:")]
//		AGSyncableString LatestStringForKey (string key);
//
//		[Export ("allLatestStringKeys")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 215)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 215)]
//		NSObject [] AllLatestStringKeys { get; }
//
//		[Export ("developerStringForKey:")]
//		AGSyncableDeveloperString DeveloperStringForKey (string key);
//
//		[Export ("allDeveloperStringKeys")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 238)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 238)]
//		NSObject [] AllDeveloperStringKeys { get; }
//
//		[Export ("latestStringListForKey:")]
//		AGSyncableStringList LatestStringListForKey (string key);
//
//		[Export ("allLatestStringListKeys")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 262)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 262)]
//		NSObject [] AllLatestStringListKeys { get; }
//
//		[Export ("stringSetForKey:")]
//		AGSyncableStringSet StringSetForKey (string key);
//
//		[Export ("allStringSetKeys")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 284)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 284)]
//		NSObject [] AllStringSetKeys { get; }
//
//		[Export ("mapForKey:")]
//		AGGameDataMap MapForKey (string key);
//
//		[Export ("allMapKeys")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 306)]//, Verify ("NSArray may be reliably typed, check the documentation", "/Users/matteo/Desktop/Headers/AGGameDataMap.h", Line = 306)]
//		NSObject [] AllMapKeys { get; }
//
//		[Field ("AGLeaderboardFilterFriendsAllTime", "__Internal")]
//		NSString AGLeaderboardFilterFriendsAllTime { get; }
//
//		[Field ("AGLeaderboardFilterGlobalAllTime", "__Internal")]
//		NSString AGLeaderboardFilterGlobalAllTime { get; }
//
//		[Field ("AGLeaderboardFilterGlobalDay", "__Internal")]
//		NSString AGLeaderboardFilterGlobalDay { get; }
//
//		[Field ("AGLeaderboardFilterGlobalWeek", "__Internal")]
//		NSString AGLeaderboardFilterGlobalWeek { get; }
//
//		[Field ("AGScoreFormatDuration", "__Internal")]
//		NSString AGScoreFormatDuration { get; }
//
//		[Field ("AGScoreFormatNumeric", "__Internal")]
//		NSString AGScoreFormatNumeric { get; }
//
//		[Field ("AGScoreFormatUnknown", "__Internal")]
//		NSString AGScoreFormatUnknown { get; }
//	}
//
	[BaseType (typeof (NSObject))]
	public partial interface AGScore {

		[Export ("leaderboardID", ArgumentSemantic.Copy)]
		string LeaderboardID { get; }

		[Export ("player", ArgumentSemantic.Copy)]
		AGPlayer Player { get; }

		[Export ("rank")]
		int Rank { get; }

		[Export ("score")]
		long Score { get; }

		[Export ("scoreString", ArgumentSemantic.Copy)]
		string ScoreString { get; }

		[Export ("filter", ArgumentSemantic.Copy)]
		string Filter { get; }
	}
//
	[BaseType (typeof (NSObject))]
	public partial interface AGLeaderboardDescription {

		[Export ("leaderboardID", ArgumentSemantic.Copy)]
		string LeaderboardID { get; }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; }

		[Export ("scoreUnit", ArgumentSemantic.Copy)]
		string ScoreUnit { get; }

		[Export ("scoreFormat", ArgumentSemantic.Copy)]
		string ScoreFormat { get; }

		[Export ("imageURL", ArgumentSemantic.Copy)]
		NSUrl ImageURL { get; }
	}
//
	[BaseType (typeof (NSObject))]
	public partial interface AGLeaderboardPercentileItem {

		[Export ("percentile")]
		int Percentile { get; }

		[Export ("player", ArgumentSemantic.Copy)]
		AGPlayer Player { get; }

		[Export ("score")]
		long Score { get; }
	}

	public delegate void AGLeaderboardAllDescriptionsCallBack (NSArray descriptions, NSError error);
	public delegate void AGLeaderboardScoresCallBack (NSArray scores, AGLeaderboardDescription description, NSError error);
	public delegate void AGLeaderboardLocalPlayerScoreCallBack (AGScore score, NSError error);
	public delegate void AGLeaderboardLocalPercentileRanksCallBack (NSArray percentiles, int playerIndex, AGLeaderboardDescription description, NSError error);
	public delegate void AGLeaderboardSubmitCallBack (NSDictionary rank, NSDictionary rankImproved, NSError error);

	[BaseType (typeof (NSObject))]
	public partial interface AGLeaderboard {

		[Export ("leaderboardID", ArgumentSemantic.Copy)]
		string LeaderboardID { get; }

		[Static, Export ("leaderboardWithID:")]
		AGLeaderboard LeaderboardWithID (string leaderboardID);

		[Static, Export ("allDescriptionsWithCompletionHandler:")]
		void AllDescriptionsWithCompletionHandler (AGLeaderboardAllDescriptionsCallBack completionHandler);

		[Export ("scoresWithFilter:completionHandler:")]
		void ScoresWithFilter (string leaderboardFilter, AGLeaderboardScoresCallBack completionHandler);

		[Export ("localPlayerScoreWithFilter:completionHandler:")]
		void LocalPlayerScoreWithFilter (string leaderboardFilter, AGLeaderboardLocalPlayerScoreCallBack completionHandler);

		[Export ("percentileRanksWithFilter:completionHandler:")]
		void PercentileRanksWithFilter (string leaderboardFilter, AGLeaderboardLocalPercentileRanksCallBack completionHandler);

		[Export ("submitWithScore:completionHandler:")]
		void SubmitWithScore (long score, AGLeaderboardSubmitCallBack completionHandler);
	}
//
	//TODO
	[BaseType (typeof (NSObject))]
	public partial interface AGOverlay {

//		[Export ("willShowHandler", ArgumentSemantic.Copy)]
//		Delegate WillShowHandler { get; set; }
//
//		[Export ("didDismissHandler", ArgumentSemantic.Copy)]
//		Delegate DidDismissHandler { get; set; }

		[Static, Export ("sharedOverlay")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGOverlay.h", Line = 48)]
		AGOverlay SharedOverlay { get; }

		[Export ("showGameCircle:")]
		void ShowGameCircle (bool animated);

		[Export ("showWithState:animated:")]
		void ShowWithState (AGOverlayState state, bool animated);

		[Export ("showWithLeaderboardID:animated:")]
		void ShowWithLeaderboardID (string leaderboardID, bool animated);

		[Export ("dismiss:")]
		void Dismiss (bool animated);
	}

	public delegate void AGPlayerLocalPlayerCallBack (AGPlayer player, NSError error);

	[BaseType (typeof (NSObject))]
	public partial interface AGPlayer {

		[Export ("alias", ArgumentSemantic.Copy)]
		string Alias { get; }

		[Export ("playerID", ArgumentSemantic.Copy)]
		string PlayerID { get; }

		[Static, Export ("localPlayerWithCompletionHandler:")]
		void LocalPlayerWithCompletionHandler (AGPlayerLocalPlayerCallBack completionHandler);
	}

	[BaseType (typeof (NSObject))]
	public partial interface AGWhispersync {

//		[Export ("gameData", ArgumentSemantic.Retain)]
//		AGGameDataMap GameData { get; }

		[Export ("flush")]
		void Flush ();

		[Static, Export ("sharedInstance")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/AGWhispersync.h", Line = 46)]
		AGWhispersync SharedInstance { get; }

		[Export ("synchronize")]
		void Synchronize ();
	}
		
	public delegate void BeginWithFeaturesCallBack (NSError error);
	[BaseType (typeof (NSObject))]
	public partial interface GameCircle {

		[Static, Export ("toastLocation")]//, Verify ("ObjC method massaged into setter property", "/Users/matteo/Desktop/Headers/GameCircle.h", Line = 67)]
		AGToastLocation ToastLocation { set; }

		[Static, Export ("toastsEnabled")]//, Verify ("ObjC method massaged into setter property", "/Users/matteo/Desktop/Headers/GameCircle.h", Line = 74)]
		bool ToastsEnabled { set; }

		[Static, Export ("beginWithFeatures:completionHandler:")]
		void BeginWithFeatures (NSObject [] features, BeginWithFeaturesCallBack completionHandler);

		[Static, Export ("isInitialized")]//, Verify ("ObjC method massaged into getter property", "/Users/matteo/Desktop/Headers/GameCircle.h", Line = 87)]
		bool IsInitialized { get; }

		[Static, Export ("handleOpenURL:sourceApplication:")]
		bool HandleOpenURL (NSUrl url, string sourceApplication);

		[Static, Export ("enableGameCenterWithAchievementIDMappings:leaderboardIDMappings:completionHandler:")]
		void EnableGameCenterWithAchievementIDMappings (NSDictionary achievementIDMappings, NSDictionary leaderboardIDMappings, BeginWithFeaturesCallBack completionHandler);

		[Static, Export ("configureLoggingWithLevel:")]
		void ConfigureLoggingWithLevel (AGLogLevel logLevel);
	}
}
