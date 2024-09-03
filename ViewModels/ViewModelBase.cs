using CommunityToolkit.Mvvm.ComponentModel;

namespace ScorebookAV.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        private bool busyLoading;
    }
}
