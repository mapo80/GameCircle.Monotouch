GameCircle.Monotouch
====================

GameCircle Amazon for Xamarin.iOS (aka Monotouch)

To solve this error:
error MT5212: Native linking failed, duplicate symbol: '_MD5'. error MT5213: Duplicate symbol

Do:
- lipo thin for all platform ex. lipo -thin i386 -output GameCircle-x86.a GameCircle.a
- ar -r GameCircle-x86.a *.o
- remove md5_one.o
- libtool -static -o GameCircle-x86.a *.o
- Create new universal library lipo -create GameCircle-x86.a GameCircle-armv7.a GameCircle-armv7s.a -o GameCircle-MD5.a

In this project I've uploaded resulting library GameCircle-MD5.a

Hope this help!!
