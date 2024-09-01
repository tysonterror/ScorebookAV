using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using ScorebookAV.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorebookAV.ViewModels
{
    public partial class CurriculumViewModel :ViewModelBase
    {
        [ObservableProperty]
        public ObservableCollection<CurriculumObjective> curriculumObjectives;
        public CurriculumViewModel(ScorebookDbContext scorebookDbContext)
        {
            CurriculumObjectives = new ObservableCollection<CurriculumObjective>(scorebookDbContext.CurriculumObjectives.ToList());
           
        }

        
    }
}
