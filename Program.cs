using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDL3;



namespace RPG_Yuri {
    internal static class Test {
        [STAThread]
        private static void Main() {
            if (!SDL.Init(SDL.InitFlags.Video)) {
                SDL.LogError(SDL.LogCategory.Application, $"Error creating window and rendering: {SDL.GetError()}");
                return;
            }

            if (!SDL.CreateWindowAndRenderer("SDL3 Create Window", 800, 600, 0, out var window, out var renderer))
            {
                SDL.LogError(SDL.LogCategory.Application, $"Error creating window and rendering: {SDL.GetError()}");
                return;
            }

            //SDL.SetRenderVSync(renderer, 1);

            var loop = true;
            var startCounter = SDL.GetPerformanceCounter();
            var frequency = SDL.GetPerformanceFrequency();
            var fpsCounter = new FPSCounter();

            while (loop) {
                while (SDL.PollEvent(out var e))
                {
                    if (e.Type == (uint)SDL.EventType.Quit)
                    {
                        loop = false;
                    }
                }

                var currentCounter = SDL.GetPerformanceCounter();
                var elapsed = (currentCounter - startCounter) / (double)frequency;

                var r = (byte)(Math.Sin(elapsed) * 127 + 128);
                var g = (byte)(Math.Sin(elapsed + Math.PI / 2) * 127 + 128);
                var b = (byte)(Math.Sin(elapsed + Math.PI) * 127 + 128);

                fpsCounter.Update();

                SDL.SetRenderDrawColor(renderer, r, g, b, 255);
                SDL.RenderClear(renderer);

                SDL.SetRenderDrawColor(renderer, (byte)(255 - r), (byte)(255 - g), (byte)(255 - b), 255);
                SDL.RenderDebugText(renderer, 10, 10, $"FPS: {fpsCounter.FPS:N0}");

                SDL.RenderPresent(renderer);

            }

            SDL.DestroyRenderer(renderer);
            SDL.DestroyWindow(window);

            SDL.Quit();
        }
    }
}