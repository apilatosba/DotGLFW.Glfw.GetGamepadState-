using DotGLFW;
using System;

using static DotGL.GL;

namespace Main {
   class Program {
      static void Main() {
         if (!Glfw.Init()) {
            Console.Error.WriteLine("Failed to initialize GLFW");
            Environment.Exit(1);
         }

         Glfw.SetErrorCallback((errorCode, description) => {
            Console.Error.WriteLine($"GLFW Error: {errorCode} - {description}");
         });

         Glfw.WindowHint(Hint.ContextVersionMajor, GetProjectOpenGLVersionMajor());
         Glfw.WindowHint(Hint.ContextVersionMinor, GetProjectOpenGLVersionMinor());
         Glfw.WindowHint(Hint.OpenGLProfile, OpenGLProfile.CoreProfile);
         Glfw.WindowHint(Hint.Samples, 4);

         Window window = Glfw.CreateWindow(640, 480, "FeelsDankMan", Monitor.NULL, Window.NULL);

         if (window == null) {
            Console.Error.WriteLine("Failed to create GLFW window");
            Glfw.Terminate();
            Environment.Exit(1);
         }

         Glfw.MakeContextCurrent(window);
         Import(Glfw.GetProcAddress);

         // This line crashes the program
         Glfw.GetGamepadState(Joystick.Joystick1, out GamepadState state);

         while (!Glfw.WindowShouldClose(window)) {
            Glfw.PollEvents();
            glClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            glClear(GL_COLOR_BUFFER_BIT);

            Glfw.SwapBuffers(window);
         }
      }
   }
}