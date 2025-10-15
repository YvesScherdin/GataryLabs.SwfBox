using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Abstractions.DataModels;
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
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddTransient(typeof(LazyInstance<>));

            services.AddScoped<IMainWindowViewModel, MainWindowViewModel>();
            services.AddScoped<IMainWindowSwfDetailsContentViewModel, MainWindowSwfDetailsContentViewModel>(CreateSwfDetailsViewModel);
            services.AddScoped<IMainWindowOverviewContentViewModel, MainWindowOverviewContentViewModel>();
            services.AddScoped<IMainWindowErrorContentViewModel, MainWindowErrorContentViewModel>();
            services.AddScoped<IMainWindowMenuBarViewModel, MainWindowMenuBarViewModel>();

            services.AddSingleton<IRecentSwfFileLibraryDataModel, RecentSwfFileLibraryDataModel>(CreateRecentSwfs);

            return services;
        }

        private static MainWindowSwfDetailsContentViewModel CreateSwfDetailsViewModel(IServiceProvider provider)
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

        private static RecentSwfFileLibraryDataModel CreateRecentSwfs(IServiceProvider provider)
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
