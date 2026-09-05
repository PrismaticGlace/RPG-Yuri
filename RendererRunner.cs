using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDL3;

namespace RPG_Yuri;
internal static class RendererRunner {
    public static int Run(
        string gameName,
        string gameIdentf,
        string releaseVersion,
        string windowTitle,
        int windowWidth,
        int windowHeight,
        Action<SetRenderer, double> renderFrame,
        Action<SetRenderer>? configure = null,
        Action<SetRenderer>? cleanup = null,
        Func<SDL.Event, bool>? handleEvent =  null,
        SDL.InitFlags initFlags = SDL.InitFlags.Video, 
        SDL.RendererLogicalPresentation presentation = SDL.RendererLogicalPresentation.Letterbox)
    {
        SetRenderer? context = null;
        
        try {
            context = SetRenderer.Create(gameName, gameIdentf, releaseVersion, windowTitle, windowWidth, windowHeight, initFlags, presentation);
            configure?.Invoke(context);

            while (context.PollEvents(handleEvent)) {
                renderFrame(context, SDL.GetTicks() / 1000.0);
                SDL.Delay(1);
            }
            return 0;
        }
        catch (Exception ex) {
            SDL.LogError(SDL.LogCategory.Application, ex.Message);
            return 1;
        }
        finally {
            if (context is not null) {
                cleanup?.Invoke(context);
                context.Dispose();
            }
        }
    }
}
