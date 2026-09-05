using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDL3;

namespace RPG_Yuri {
    public class FPSCounter {
        private ulong lastTime = SDL.GetPerformanceCounter();
        private int frameCount;
        private double fps;

        public void Update() {
            frameCount++;
            var currentTime = SDL.GetPerformanceCounter();
            var elapsedTime = (currentTime - lastTime) / (double)SDL.GetPerformanceFrequency();

            if (!(elapsedTime >= 0.1)) return;

            fps = frameCount / elapsedTime;
            frameCount = 0;
            lastTime = currentTime;
        }

        public double FPS => fps;
    }
}