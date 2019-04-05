using CopaFilmes.Model.Base;
using CopaFilmes.Navigation;
using CopaFilmes.ViewModels.InterfacesCommon;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace CopaFilmes.ViewModels.Base
{

    public abstract class ViewModelBase<TPage, TVModel> : NavigationContext<TPage>, INotifyPropertyChanged, IBindingViewModel
       where TPage : class
       where TVModel : ModelBase
    {
        #region Fields

        private TVModel _vModel;
        private bool _isBusy;
        private string _textoApresentacaoCarregamento;       
        #endregion

        #region Properties

        public TVModel VModel
        {
            get { return _vModel; }
            set
            {
                _vModel = value;
                RaisedPropertyChanged(() => VModel);
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisedPropertyChanged(() => IsBusy);
            }
        }
             
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

        #region Methods
        public virtual void AfterBinding()
        {

        }
        #endregion

    }
}
