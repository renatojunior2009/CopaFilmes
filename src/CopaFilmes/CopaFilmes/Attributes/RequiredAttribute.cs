using System;

namespace CopaFilmes.Attributes
{    
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : ValidationBaseAttribute
    {
        #region Constructor
        public RequiredAttribute(string requiredMessage) : base(requiredMessage) { }
        #endregion
    }
}
