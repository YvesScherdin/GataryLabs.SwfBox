using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.Mvvm.ViewModels.Utils;
using GataryLabs.SwfBox.Domain.Abstractions;
using GataryLabs.SwfBox.Domain.Abstractions.Models;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.DataModel;
using MapsterMapper;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowViewModel : ObservableObject, IMainWindowViewModel
    {
        private readonly IMainWindowMenuBarViewModel mainWindowMenuBarViewModel;
        private readonly LazyInstance<IMainWindowContentNavigator> contentNavigatorLazy;
        private readonly LazyInstance<IMainWindowContextDataModel> contextDataModel;
        private readonly ISessionContext sessionContext;
        private readonly ISwfFileLibraryService libraryService;
        private readonly IMapper mapper;

        public MainWindowViewModel(
            IMainWindowMenuBarViewModel mainWindowMenuBarViewModel,
            LazyInstance<IMainWindowContentNavigator> contentNavigatorLazy,
            LazyInstance<IMainWindowContextDataModel> contextDataModel,
            ISwfFileLibraryService libraryService,
            ISessionContext sessionContext,
            IMapper mapper)
        {
            this.mainWindowMenuBarViewModel = mainWindowMenuBarViewModel;
            this.contentNavigatorLazy = contentNavigatorLazy;
            this.contextDataModel = contextDataModel;
            this.libraryService = libraryService;
            this.sessionContext = sessionContext;
            this.mapper = mapper;
        }

        public IMainWindowMenuBarViewModel MenuBarViewModel => mainWindowMenuBarViewModel;
        public IMainWindowContentNavigator ContentNavigator => contentNavigatorLazy.Value;
        
        public void OnLoaded()
        {
            Debug.WriteLine("On loaded");

            RefreshTotally();
        }

        public void OnUnloaded()
        {
            Debug.WriteLine("On unloaded");
        }

        private void RefreshTotally()
        {
            List<SwfFileBriefDataModel> detailsDataModelList = libraryService
                .GetFiles(x => true)
                .Select(x => mapper.Map<SwfFileBriefDataModel>(x))
                .ToList();

            contextDataModel.Value.RecentSwfFiles.Files.Clear();
            foreach (SwfFileBriefDataModel briefdataModel in detailsDataModelList)
                contextDataModel.Value.RecentSwfFiles.Files.Add(briefdataModel);

            if (libraryService.HasAnyFile(x => x.Id == sessionContext.History.RecentSwfFile))
            {
                SwfFileDetailsInfo detailsInfo = libraryService.GetSingleFileDetails(sessionContext.History.RecentSwfFile);
                SwfFileDetailsDataModel detailsDataModel = mapper.Map<SwfFileDetailsDataModel>(detailsInfo);

                sessionContext.History.RecentSwfFile = detailsInfo.Id;
                contextDataModel.Value.FileDetails = detailsDataModel;
                contentNavigatorLazy.Value.ContentViewModel = contentNavigatorLazy.Value.SwfDetailsContentViewModel;
            }
            else
            {
                contentNavigatorLazy.Value.ContentViewModel = contentNavigatorLazy.Value.OverviewContentViewModel;
            }
        }
    }
}
