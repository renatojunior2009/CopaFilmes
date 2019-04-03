using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Attributes
{    
    public abstract class ValidationBaseAttribute : Attribute
    {
        #region Properties
        public string ValidationMessage { get; private set; }
        #endregion

        #region Constructor
        protected ValidationBaseAttribute(string validationMessage)
        {
            ValidationMessage = validationMessage;
        }
        #endregion
    }
}
