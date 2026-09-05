using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDL3;

namespace RPG_Yuri;

internal sealed class SetRenderer : IDisposable {
    private bool dispose;

    private SetRenderer(IntPtr window, IntPtr renderer, int width, int height) {
        Window = window;
        Renderer = renderer;
        Width = width;
        Height = height;
    }

    public IntPtr Window { get; }

    public IntPtr Renderer { get; }

    public int Width { get; }

    public int Height { get; }

    public static SetRenderer Create(
        string gameName,
        string gameIdentf,
        string windowTitle,
        string releaseVersion,
        int width,
        int height,
        SDL.InitFlags initFlags = SDL.InitFlags.Video,
        SDL.RendererLogicalPresentation presentation = SDL.RendererLogicalPresentation.Letterbox)
    {
        SDL.SetAppMetadata(gameName, releaseVersion, gameIdentf);

        if (!SDL.Init(initFlags)) {
            throw new InvalidOperationException($"SDL Couldn't Initialize: {SDL.GetError()}");
        }

        if (!SDL.CreateWindowAndRenderer(windowTitle, width, height, SDL.WindowFlags.Resizable, out var window, out var renderer)) {
            SDL.Quit();
            throw new InvalidOperationException($"Couldn't Create Window and/or Renderer: {SDL.GetError()}");
        }

        SDL.SetRenderLogicalPresentation(renderer, width, height, presentation);
        return new SetRenderer(window, renderer, width, height);
    }

    public bool PollEvents(Func<SDL.Event, bool>? handleEvent = null) {
        while (SDL.PollEvent(out var sdlEvent)) {
            if (sdlEvent.Type == (uint)SDL.EventType.Quit) {
                return false;
            }

            if (handleEvent?.Invoke(sdlEvent) == false) {
                return false;
            }
        }
        return true;
    }

    public void Dispose() {
        if (dispose) {
            return;
        }

        if (Renderer != IntPtr.Zero) {
            SDL.DestroyRenderer(Renderer);
        }
        
        if (Window != IntPtr.Zero) {
            SDL.DestroyWindow(Window);
        }

        SDL.Quit();
        dispose = true;
    }
}
