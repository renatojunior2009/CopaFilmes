using AutoMapper;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Model;
using CopaFilmes.Pages.Interfaces;
using CopaFilmes.Services.Interfaces.Intern;
using CopaFilmes.Utils.Collection;
using CopaFilmes.ViewModels.Base;
using CopaFilmes.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CopaFilmes.ViewModels
{    
    public class ResultViewModel : ViewModelBaseList<IMoviePage, MovieModel>, IResultViewModel
    {
        #region Fields                  
        private readonly IResultCompetitionApi _resultApi;
        #endregion

        #region Properties         
       
        #endregion

        #region Constructor
        public ResultViewModel(IResultCompetitionApi resultApi)
        {
            _resultApi = resultApi;
            GetResultApi();           
        }
        #endregion

        #region Methods Privates
        private async Task GetResultApi()
        {
            try
            {
                IsBusy = true;
                //var result = await _resultApi.GetResult();
               
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }       
        #endregion

        #region Methods Publics 
        public  override void AfterBinding()
        {
         
        }
        #endregion

        #region Commands
       
        #endregion
    }
}
