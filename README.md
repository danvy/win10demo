#Windows 10 SDK Demo

##Introduction
I couldn't wait for the release of all the official demos of the Windows 10 SDK. Of course there are some of them already available https://github.com/Microsoft/Windows-universal-samples but some are missing. The purpose of this project is very simple :
- give everyone the opportunity to play with the APIs right now
- share my enthusiasm for the new platform
So this project is more a playground than a reference. Use it as sandbox to quickly test an API, to edit the code, evaluate some options or parameters.

##What's in ?
100% of the source code is available. It's full C# & XAML.

You will find a Visual Studio solution (Win10Demo.sln) including 3 projects
- Main app (Win10Demo.csproj)
- Secondary app for the app to app communication scenarii (Win10Demo2.csproj)
- AppService project (Win10DemoService.csproj)
- Universal Windows App running on Windows Phone, Windows & Windows IoT (Raspberry PI 2) (Win10DemoRPI.csproj)

Each feature is illustrated in a single file. Ex : RelativePanelView.xaml for RelativePanel)

There no external dependency or third party library.

Here are the APIs/features used :
- SplitView (Menu with hamburger)
- CalendarView (Calendar with decade, year and month view)
- AdaptiveTriggers (Change VisualState without code behind)
- InkCanvas (Pen, mouse and touch strokes canvas)
- KeyAccelerators (Shortcut defined in XAML)
- LaunchFolderAsync (Open a folder in Winodws Explorer)
- QueryUriSupportAsync (Check if an app is installed)
- LaunchUriForResultsAsync (Launch an app and wait for some result)
- AppService (Like micro webservice for modern apps)
- MapControl (Graphical maps)
- AdaptiveMediaStream (HLS & MPEG DASH video support)
- RelativePanel (New layout control that define relation between controls)
- SpeechSynthesizer (Text to speech)
- Battery (Battery information)
- MemoryManager (Memory information)
- TitleBar (Title bar can match your theme)

##Requirements
A machine with
- Windows 10 Technical Preview Build >=10041
- Visual Studio 2015 CTP 6
- Windows 10 Technical Preview Tools

##What's new?
04/22/2015 Initial release

##Q&A
#### Q: Hum, a sample doesn't work on my machine :S
A: The code was written on Windows 10 build 10061 with Visual Studio 2015 CTP 6. It is still a work in progress project. Your feedback is very welcome. Create an issue or a pull request on Github :)
#### Q: Are those example better that the official samples ?
A: No, they are different. Microsoft is investing a lot of energy to create awesome samples.
#### Q: Source code is great but do you have some videos ?
A: Yes, they are videos in English http://channel9.msdn.com/Series/Developers-Guide-to-Windows-10-Preview and in French http://channel9.msdn.com/Blogs/Microsoft-D-veloppeurs-France/01-Plateforme-et-outils

If you have any problem with the scripts, use GitHub or contact me on Twitter @danvy

##Special thanks
To Sébastien Pertus @sebastienpertus for his contribution to the SplitView demo
