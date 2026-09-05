using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using SDL3;

namespace RPG_Yuri {
    internal static class Program {
        public static FPSCounter fpsCounter = new FPSCounter();

        [STAThread]
        
        private static void Main() {

            RendererRunner.Run(
                "Yuri RPG",
                "ca.prismaticglace.yurirpg",
                "Skyline over Scarlet Expanse",
                "0.1",
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
                    var buttons = new SDL.MessageBoxButtonData[] {
                        new() {ButtonID = 0, Flags = SDL.MessageBoxButtonFlags.EscapekeyDefault, Text = "Escape"},
                        new() {ButtonID = 1, Flags = SDL.MessageBoxButtonFlags.ReturnkeyDefault, Text = "Return"},
                        new() {ButtonID = 2, Flags = SDL.MessageBoxButtonFlags.ReturnkeyDefault, Text = "Retry"}
                    };
                    var buttonsPtr = SDL.StructureArrayToPointer(buttons);
                    
                    try {
                        var messageBoxData = new SDL.MessageBoxData() {
                            Buttons = buttonsPtr,
                            NumButtons = buttons.Length,
                            Flags = SDL.MessageBoxFlags.Error,
                            Title = "Yuri",
                            Message = "I LOVE YURI WOOOO"
                        };

                        SDL.ShowMessageBox(messageBoxData, out var resButton);
                        SDL.LogInfo(SDL.LogCategory.Application, $"MessageBox Result button ID: {resButton}");
                    }
                    finally {
                        Marshal.FreeHGlobal(buttonsPtr);
                    }
                    break;
            }
            return true;
        }

        private static void RenderFrame(SetRenderer context, double now) {            

            var r = (byte)(SDL.Rand(255) + 1);
            var g= (byte)(SDL.Rand(255) + 1);
            var b = (byte)(SDL.Rand(255) + 1);

            fpsCounter.Update();

            SDL.SetRenderDrawColor(context.Renderer, r, g, b, 255);
            SDL.RenderClear(context.Renderer);
            SDL.SetRenderDrawColor(context.Renderer, 100, 100, 100, 255);
            SDL.RenderDebugText(context.Renderer, 10, 10, $"FPS: {fpsCounter.FPS:N0}");
            SDL.RenderPresent(context.Renderer);
        }

    }
}