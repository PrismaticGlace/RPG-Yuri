using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDL3;

namespace RPG_Yuri {
    public class FPSCounter {
        private ulong _lastTime = SDL.GetPerformanceCounter();
        private int _frameCount;
        private double _fps;

        public void Update() {
            _frameCount++;
            var currentTime = SDL.GetPerformanceCounter();
            var elapsedTime = (currentTime - _lastTime) / (double)SDL.GetPerformanceFrequency();

            if (!(elapsedTime >= 0.1)) return;

            _fps = _frameCount / elapsedTime;
            _frameCount = 0;
            _lastTime = currentTime;
        }

        public double FPS => _fps;
    }
}