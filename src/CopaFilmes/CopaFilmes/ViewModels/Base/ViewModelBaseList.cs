using CopaFilmes.Model.Base;
using CopaFilmes.ViewModels.InterfacesCommon;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using CopaFilmes.Navigation;
using CopaFilmes.Utils.Collection;

namespace CopaFilmes.ViewModels.Base
{
 
    public abstract class ViewModelBaseList<TPage, TModel> : NavigationContext<TPage>, INotifyPropertyChanged, IBindingViewModel
        where TPage : class
        where TModel : ModelBase
    {

        #region Fields
        private bool _isBusy;
        private string _textoApresentacaoCarregamento;
        #endregion

        #region Properties
        public ViewModelObservableCollection<TModel> Items { get; set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisedPropertyChanged(() => IsBusy);
            }
        }

        public string TextoApresentacaoCarregamento
        {
            get { return _textoApresentacaoCarregamento; }
            set
            {
                _textoApresentacaoCarregamento = value;
                RaisedPropertyChanged(() => TextoApresentacaoCarregamento);
            }
        }

        #endregion

        #region Constructor

        public ViewModelBaseList()
        {
            Items = new ViewModelObservableCollection<TModel>();
        }

        #endregion

        #region Methods        
        public virtual void AfterBinding() { }
        #endregion

        #region INotifyProperty Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisedPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression != null)
            {
                var pInfo = memberExpression.Member as PropertyInfo;

                if (pInfo != null)
                {
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs(pInfo.Name));
                }

            }
        }

        #endregion

    }
}
