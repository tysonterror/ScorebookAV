using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorebookAV.Models;
using ScorebookAV.ViewModels;
using ScorebookAV.Views;

namespace ScorebookAV
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonServices(this IServiceCollection collection)
        {
            collection.AddDbContext<ScorebookDbContext>(options =>
            options.UseSqlite("Data Source=C:\\RFT\\ScoreBookAV\\ScoreBookDb.db"));
            collection.AddTransient<MainViewModel>();
            collection.AddTransient<HomeViewModel>();
            collection.AddTransient<CurriculumViewModel>();
            collection.AddTransient<ClassViewModel>();
            collection.AddTransient<EvaluationsViewModel>();
        }
    }
}
