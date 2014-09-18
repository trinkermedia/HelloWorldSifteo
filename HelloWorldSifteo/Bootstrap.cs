// When debugging, it can sometimes be useful to launch your app directly,
// outside of Siftrunner's app harness. Because BaseApps are meant to be run
// inside Siftrunner, a bootstrapping process is required to kick off the
// program manually.


// All the classes in your app should share a namespace.
namespace HelloSifteo
{

  // The Bootstrap class is a simple wrapper with a Main() method that kicks
  // off your app. All of your app's logic should go into the app class.
	public class Bootstrap
	{

		public static void Main(string[] args) 
		{
      // Create the app and start it up.
			(new HelloSifteoApp()).Run();
		}
	}
}
