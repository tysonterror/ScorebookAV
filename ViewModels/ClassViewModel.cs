using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using ScorebookAV.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorebookAV.ViewModels
{
    public partial class ClassViewModel: ViewModelBase
    {

        [ObservableProperty]
        private ObservableCollection<Class> classes;
        public ClassViewModel(ScorebookDbContext scorebookDbContext) 
        {
            Classes = new ObservableCollection<Class>(scorebookDbContext.Classes.Include(i => i.ClassStudents).ThenInclude(i => i.Student));
        }
    }
}
