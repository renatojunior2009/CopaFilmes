using CopaFilmes.Attributes;
using CopaFilmes.ViewModels.InterfacesCommon;
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CopaFilmes.Model.Base
{  
    public abstract class ModelBase : INotifyPropertyChanged
    {

        #region Fields
        private long _id;
        #endregion

        #region Properties
        public IDisplayCommand InternalCommand { get; set; }
        public long Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisedPropertyChanged(() => Id);
            }
        }
        #endregion

        #region Events 
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
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

        public void RaisedPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        public bool IsValid()
        {
            var type = this.GetType();
            var properties = type.GetTypeInfo().DeclaredProperties;

            foreach (var prop in properties)
            {
                var attributes = prop.GetCustomAttributes(false);
                var requiredAttribute = (attributes.FirstOrDefault(c => c is RequiredAttribute) as RequiredAttribute);

                var value = prop.GetValue(this, null);

                if (string.IsNullOrEmpty(Convert.ToString(value)) && requiredAttribute != null)
                    throw new Exception(requiredAttribute.ValidationMessage);
            }

            return true;
        }
        #endregion
    }
}
