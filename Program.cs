using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using SDL3;

namespace RPG_Yuri {
    internal static class Program {
        [STAThread]
        private static void Main() {
            //if (!SDL.Init(SDL.InitFlags.Video)) {
            //    SDL.LogError(SDL.LogCategory.Application, $"Error creating window and rendering: {SDL.GetError()}");
            //    return;
            //}

            //Tries to create a Window and Renderer
            //if (!SDL.CreateWindowAndRenderer("SDL3 Create Window", 800, 600, 0, out var window, out var renderer)) {
            //    SDL.LogError(SDL.LogCategory.Application, $"Error creating window and rendering: {SDL.GetError()}");
            //    return;
            //}

            RendererRunner.Run(
                "Yuri RPG",
                "ca.prismaticglace.yurirpg",
                "0.1",
                "Skyline over Scarlet Expanse",
                800,
                600,
                RenderFrame,
                Configure,
                Cleanup,
                HandleEvent,
                SDL.InitFlags.Video
            );
        }

        private static void Configure(SetRenderer context) {
            //Nothing here yet
            //Initialize game here
        }

        private static void Cleanup(SetRenderer context) {
            //Clean up things here
        }


        private static bool HandleEvent(SDL.Event sdlEvent) {
            switch ((SDL.EventType)sdlEvent.Type) {
                case SDL.EventType.KeyDown:
                    return HandleKey(sdlEvent.Key.Scancode);
            }
            
            return true;
        }

        private static bool HandleKey(SDL.Scancode scancode) {
            //Place a inCutscene bool before some
            switch (scancode) {
                case SDL.Scancode.Escape:
                    return false;
                case SDL.Scancode.A:
                    break;
                case SDL.Scancode.S:
                    break;
                case SDL.Scancode.D:
                    break;
                case SDL.Scancode.W:
                    break;
                case SDL.Scancode.E:
                    break;
            }
            return true;
        }

        private static void RenderFrame(SetRenderer context, double now) {
            //Render Frames
        }

    }
}