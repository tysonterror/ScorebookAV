using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScorebookAV.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;

namespace ScorebookAV.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        public MainViewModel(HomeViewModel homeViewModel)
        {
            HomeViewModel = homeViewModel;
        }

        public HomeViewModel HomeViewModel { get; }
    }
}
