using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using ScorebookAV.Models;
using ScorebookAV.Models.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScorebookAV.ViewModels
{
    public partial class EvaluationsViewModel : ViewModelBase
    {
        private readonly DbContextOptions<ScorebookDbContext> _scorebookDbContextOptions;
        [ObservableProperty]
        private ObservableCollection<ClassEvaluation> classEvaluations;
        [ObservableProperty]
        private ObservableCollection<ClassStudentEvaluation> selectedClassStudentEvaluations;
        [ObservableProperty]
        private ClassEvaluation selectedClassEvaluation;
        //public ClassEvaluation SelectedClassEvaluation { get { return selectedClassEvaluation; } set { SetProperty(ref selectedClassEvaluation, value); GetSelectedClassStudentEvaluations(value); } }
        public EvaluationsViewModel(DbContextOptions<ScorebookDbContext> scorebookDbContext)
        {
            _scorebookDbContextOptions = scorebookDbContext;
            ClassEvaluations = new ObservableCollection<ClassEvaluation>();
            SelectedClassStudentEvaluations = new ObservableCollection<ClassStudentEvaluation>();

            GetData();
            PropertyChanged += EvaluationsViewModel_PropertyChanged;
        }

        private void EvaluationsViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            if (e.PropertyName == nameof(SelectedClassEvaluation))
            {
                GetSelectedClassStudentEvaluations(SelectedClassEvaluation);
            }
        }

        private void GetData()
        {
            ClassEvaluations.Clear();
            using (var ctx = new ScorebookDbContext(_scorebookDbContextOptions))
            {
                var newItems =
                     ctx
                     .ClassEvaluations
                     .Include(i => i.EvaluationType)
                     .ThenInclude(i => i.PEvaluationTypeParams)
                     .Include(i => i.Class).ToList();

                foreach (var item in newItems)
                {
                    ClassEvaluations.Add(item);
                }
            }

        }

        private void GetSelectedClassStudentEvaluations(ClassEvaluation classEvaluation)
        {

            if (classEvaluation != null)
            {
                SelectedClassStudentEvaluations.Clear();
                using (var ctx = new ScorebookDbContext(_scorebookDbContextOptions))
                {
                    var newItems = ctx.ClassStudentEvaluations
                   .Include(i => i.Student)
                   .Include(i => i.ClassEvaluation).ThenInclude(i => i.EvaluationType).ThenInclude(i => i.PEvaluationTypeParams)
                   .Where(w => w.ClassEvaluationId == classEvaluation.ClassEvaluationId).ToList();
                    foreach (var item in newItems)
                    {
                        SelectedClassStudentEvaluations.Add(item);
                    }
                }
            }


        }



        [RelayCommand]
        private void SetCheckmark(ClassStudentEvaluationAdjustScore classStudentEvaluationAdjustScore)
        {

            var item = SelectedClassStudentEvaluations.FirstOrDefault(f => f.ClassStudentEvaluationId == classStudentEvaluationAdjustScore.ClassStudentEvaluation.ClassStudentEvaluationId);
            if (item != null)
            {
                using (var ctx = new ScorebookDbContext(_scorebookDbContextOptions))
                {
                    var index = SelectedClassStudentEvaluations.IndexOf(item);
                    var dbItem = ctx.ClassStudentEvaluations.Include(i => i.Student)
                   .Include(i => i.ClassEvaluation).ThenInclude(i => i.EvaluationType).ThenInclude(i => i.PEvaluationTypeParams).FirstOrDefault(f => item.ClassStudentEvaluationId == f.ClassStudentEvaluationId);
                    if (dbItem != null)
                    {
                        SelectedClassStudentEvaluations.RemoveAt(index);
                        dbItem.Score = classStudentEvaluationAdjustScore.NewScore.Score;
                        ctx.SaveChanges();
                        SelectedClassStudentEvaluations.Insert(index, dbItem);

                    }

                }
            }

        }

    }
}
