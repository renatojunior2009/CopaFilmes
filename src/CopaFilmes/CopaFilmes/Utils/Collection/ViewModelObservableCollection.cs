using CopaFilmes.Model.Base;
using CopaFilmes.ViewModels.InterfacesCommon;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CopaFilmes.Utils.Collection
{
    
    public class ViewModelObservableCollection<T> : ObservableCollection<T> where T : ModelBase
    {
        #region Fields 
        private IDisplayCommand _interfaceCommand;
        #endregion

        #region Constructores 
        public ViewModelObservableCollection()
            : base()
        {

        }

        public ViewModelObservableCollection(IEnumerable<T> collection, IDisplayCommand interfaceCommand)
            : base(collection)
        {
            _interfaceCommand = interfaceCommand;
            SetInterfaceCollection(Items);
        }
        #endregion

        #region Methods Privates 
        private void SetInterfaceCollection(IList<T> collection)
        {
            foreach (var item in collection)
            {
                item.InternalCommand = _interfaceCommand;
            }
        }
        #endregion

    }
}
