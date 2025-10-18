using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
using GataryLabs.SwfBox.ViewModels.Commands;
using GataryLabs.SwfBox.ViewModels.Constants;
using GataryLabs.SwfBox.ViewModels.DataModel;
using GataryLabs.SwfBox.ViewModels.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace GataryLabs.SwfBox.ViewModels.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMvvm(this IServiceCollection services)
        {
            services.AddTransient(typeof(LazyInstance<>));

            services.AddDataModels();
            services.AddCommands();
            services.AddViewModels();

            return services;
        }

        private static IServiceCollection AddDataModels(this IServiceCollection services)
        {
            services.AddSingleton<IRecentSwfFileLibraryDataModel, RecentSwfFileLibraryDataModel>(CreateRecentSwfsForDebugging);

            return services;
        }
        
        private static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddTransient<ISelectSwfFileCommand, SelectSwfFileCommand>();

            return services;
        }
        
        private static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddScoped<IMainWindowViewModel, MainWindowViewModel>();
            services.AddScoped<IMainWindowSwfDetailsContentViewModel, MainWindowSwfDetailsContentViewModel>(CreateSwfDetailsViewModelForDebugging);
            services.AddScoped<IMainWindowOverviewContentViewModel, MainWindowOverviewContentViewModel>();
            services.AddScoped<IMainWindowErrorContentViewModel, MainWindowErrorContentViewModel>();
            services.AddScoped<IMainWindowMenuBarViewModel, MainWindowMenuBarViewModel>();

            return services;
        }

        private static MainWindowSwfDetailsContentViewModel CreateSwfDetailsViewModelForDebugging(IServiceProvider provider)
        {
            return new MainWindowSwfDetailsContentViewModel
            {
                Details = new SwfFileDetailsDataModel
                {
                    Path = "path/to/somewhere",
                    FileName = "file.swf"
                }
            };
        }

        private static RecentSwfFileLibraryDataModel CreateRecentSwfsForDebugging(IServiceProvider provider)
        {
            return new RecentSwfFileLibraryDataModel
            {
                Files = new List<ISwfFileBriefDataModel>
                {
                    new SwfFileBriefDataModel
                    {
                        Id = Guid.NewGuid(),
                        Title = "SomeFile.swf",
                        Description = "Blah",
                        Image = FallbackFilePathes.SwfDefaultIconSmall,
                        Path = "path/to/SomeFile.swf"
                    },
                    new SwfFileBriefDataModel
                    {
                        Id = Guid.NewGuid(),
                        Title = "SomeFile1.swf",
                        Description = "Blah",
                        Image = FallbackFilePathes.SwfDefaultIconSmall,
                        Path = "path/to/SomeFile1.swf"
                    },
                    new SwfFileBriefDataModel
                    {
                        Id = Guid.NewGuid(),
                        Title = "SomeFile1.swf",
                        Description = "Blah",
                        Image = FallbackFilePathes.SwfDefaultIconSmall,
                        Path = "path/to/SomeFile1.swf"
                    },
                    new SwfFileBriefDataModel
                    {
                        Id = Guid.NewGuid(),
                        Title = "SomeFile1.swf",
                        Description = "Blah",
                        Image = FallbackFilePathes.SwfDefaultIconSmall,
                        Path = "path/to/SomeFile1.swf"
                    },
                    new SwfFileBriefDataModel
                    {
                        Id = Guid.NewGuid(),
                        Title = "SomeFile1.swf",
                        Description = "Blah",
                        Image = FallbackFilePathes.SwfDefaultIconSmall,
                        Path = "path/to/SomeFile1.swf"
                    },
                    new SwfFileBriefDataModel
                    {
                        Id = Guid.NewGuid(),
                        Title = "SomeFile1.swf",
                        Description = "Blah",
                        Image = FallbackFilePathes.SwfDefaultIconSmall,
                        Path = "path/to/SomeFile1.swf"
                    },
                    new SwfFileBriefDataModel
                    {
                        Id = Guid.NewGuid(),
                        Title = "SomeFile1.swf",
                        Description = "Blah",
                        Image = FallbackFilePathes.SwfDefaultIconSmall,
                        Path = "path/to/SomeFile1.swf"
                    },
                    new SwfFileBriefDataModel
                    {
                        Id = Guid.NewGuid(),
                        Title = "SomeFile1.swf",
                        Description = "Blah",
                        Image = FallbackFilePathes.SwfDefaultIconSmall,
                        Path = "path/to/SomeFile1.swf"
                    }
                }
            };
        }
    }
}
