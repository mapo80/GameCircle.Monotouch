using System;

namespace AmazonGameCircle
{
	public enum AGErrorCode {
		Unknown = 1,
		InvalidInputFormat = 2,
		UnknownEntity = 3,
		FailedResourceAccess = 4,
		OutOfDiskSpace = 5,
		Initialization = 6,
		Authentication = 7,
		GameCenterAuthentication = 8,
		Network = 9,
		loudSubmission = 10,
		loudRetrieval = 11,
		GameCenterSubmission = 12
	}
	public enum AGOverlayState {
		ummary,
		Leaderboards,
		Achievements,
		ignIn
	}
	public enum AGToastLocation {
		TopLeft = 0,
		TopRight,
		BottomLeft,
		BottomRight,
		TopCenter,
		BottomCenter
	}

	public enum AGLogLevel{
		Off,
		Critical,
		Error,
		Warning
	}
}

