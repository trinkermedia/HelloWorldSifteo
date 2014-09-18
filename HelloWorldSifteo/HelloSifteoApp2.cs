
// This is a very simple demo app that runs on your Sifteo cubes. It
// illustrates the basic structure of an app, and demonstrates some of the ways
// you can draw graphics on a Cube.

// This introductory app is extremely simple; later demos will introduce more
// complex concepts and APIs, and show you how to make more interesting things.

// ----------------------------------------------------------------------------

// The System assembly contains core C# APIs.
using System;

// The Sifteo assembly contains all the APIs for communicating with your cubes.
using Sifteo;

// All the classes for your app should go into a shared namespace.
namespace HelloSifteo {

  // ## BaseApp ##
  // The main app for your application must subclass BaseApp. Siftrunner will
  // look for this class when it launches your app.
  public class HelloSifteoApp : BaseApp {

    int mFrameCount = 0;
    Random mRandomizer = new Random();

    // ## Setup ##
    // The Setup method is called when the game starts. Whatever logic you want
    // to do to initialize your app should go into this method. __Do not__
    // override the constructor on an instance of BaseApp. All logic for
    // starting up a game should go into Setup.
    public override void Setup() {

      // Log.Debug can be used instead of System.Console.WriteLine to print out
      // debugging information. It adds extra information that makes debugging
      // a little easier.
      Log.Debug("Hello, Sifteo!");

      // The CubeSet represents the set of all connected cubes.  Each Cube
      // object represents a physical cube. Here we iterate over all the cubes
      // and draw on the displays of each one.
      foreach (Cube cube in this.CubeSet) {

        // ### Color ###
        // A Color object represents an RGB color.
        Color color = new Color(182, 218, 85);

        // ### FillScreen ###
        // FillScreen paints the cube's entire screen the given color.
        cube.FillScreen(color);

        // ### FillRect ###
        // FillRect draws a rectangle on the cube's screen at a given location
        // in a given size and color. A cube's screen is 128x128 pixels. Here
        // we draw a big square in the center of the screen.
        int x = 24;
        int y = 24;
        int width = 80;
        int height = 80;
        color = new Color(36, 182, 255);
        cube.FillRect(color, x, y, width, height);

        // Here we draw a message for the user.
        DrawHelloWorld(cube);

        // ### Paint ###
        // Paint tells the cube to copy the frame buffer to the display.
        // Nothing we've drawn will actually show up on the cube's display
        // until we call its Paint() method. Don't forget to call this!
        cube.Paint();
      }

    }


    // ------------------------------------------------------------------------

    // ## Tick ##
    // The Tick method gets called every 1/20th of a second (the tick rate is
    // adjustable; see BaseApp.FrameRate). This is where the action happens!
    public override void Tick() {

      // Increment the frame counter so that we can keep track of how long
      // we've been running.
      this.mFrameCount += 1;

      // Pick a point on a circle based on the current frame counter. The
      // cube's screen is 128x128 pixels, so the center of our circle is at
      // (64,64), and it has a radius of 56 pixels.
      double theta = (double)this.mFrameCount / 30.0 * Math.PI;
      int x = 64 + (int)(56.0 * Math.Cos(theta)) - 2;
      int y = 64 + (int)(56.0 * Math.Sin(theta)) - 2;

      // Pick a random color to draw the dot.
      int r = mRandomizer.Next(256);
      int g = mRandomizer.Next(256);
      int b = mRandomizer.Next(256);
      Color color = new Color(r, g, b);

      // Iterate over our cubes again so that we can draw the dot onto each one.
      foreach (Cube cube in this.CubeSet) {

        // Draw the dot.
        cube.FillRect(color, x, y, 4, 4);

        // Remember to call Paint!
        cube.Paint();
      }

    }


    // In this method, we draw "HELLO WORLD" to the display of a cube using
    // rects.
    private void DrawHelloWorld(Cube cube) {

			Color color = new Color(255, 145, 0);

			// Draw the word "HELLO" to the cube's display.
			cube.FillRect(color, 1, 97, 23, 22);
			cube.FillRect(color, 5, 109, 6, 6);
			cube.FillRect(color, 14, 109, 6, 6);

			cube.FillRect(color, 5, 101, 15, 4);
			cube.FillRect(color, 8, 101, 3, 4);


    }

  }
}

// -----------------------------------------------------------------------
//
// HelloSifteoApp.cs
//
// Copyright &copy; 2011 Sifteo Inc.
//
// This program is "Sample Code" as defined in the Sifteo
// Software Development Kit License Agreement. By adapting
// or linking to this program, you agree to the terms of the
// License Agreement.
//
// If this program was distributed without the full License
// Agreement, a copy can be obtained by contacting
// support@sifteo.com.
//

