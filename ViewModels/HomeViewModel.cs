using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScorebookAV.ViewModels
{
    public partial class HomeViewModel : ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider;
        [ObservableProperty]
        private bool loadingCurrentViewModel;
        [ObservableProperty]
        private ViewModelBase? currentViewModel;
        public HomeViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            //SetCurrentViewModel();
        }
        [CommunityToolkit.Mvvm.Input.RelayCommand]
        private async void SetCurriculumViewModel()
        {
            await Task.Run(() =>
            {
                LoadingCurrentViewModel = true;
                CurrentViewModel = _serviceProvider.GetRequiredService<CurriculumViewModel>();
                LoadingCurrentViewModel = false;
            });
        }
        [CommunityToolkit.Mvvm.Input.RelayCommand]
        private async void SetClassViewModel()
        {
            await Task.Run(() =>
            {
                LoadingCurrentViewModel = true;
                CurrentViewModel = _serviceProvider.GetRequiredService<ClassViewModel>();
                LoadingCurrentViewModel = false;
            });
        }
        [CommunityToolkit.Mvvm.Input.RelayCommand]
        private async void SetEvaluationsViewModel()
        {
            await Task.Run(() =>
            {
                LoadingCurrentViewModel = true;
                CurrentViewModel = _serviceProvider.GetRequiredService<EvaluationsViewModel>();
                LoadingCurrentViewModel = false;
            });
        }

    }
}
