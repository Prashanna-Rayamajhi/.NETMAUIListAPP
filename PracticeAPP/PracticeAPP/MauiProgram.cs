﻿using Microsoft.Extensions.Logging;
using PracticeAPP.ViewModels;
using PracticeAPP.Views;

namespace PracticeAPP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

            builder.Services.AddTransient<DetailsPage>();
            builder.Services.AddTransient<DetailsViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
