using CopaFilmes.InjectionDependency;
using CopaFilmes.ViewModels.InterfacesCommon;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CopaFilmes.Navigation
{
    public class NavigationContext<TPage> where TPage : class
    {
        #region Fields
        private Page _page; 
        #endregion

        #region Properties
        public INavigation _navigation;
        public Page Page => _page;
        #endregion

        #region Constructor
        public NavigationContext()
        {
            _page = App.Current.CurrentPage;
            _page.Appearing += _page_Appearing;
        }
        #endregion

        #region Events Page 
        protected void _page_Appearing(object sender, System.EventArgs e) { }
        #endregion

        #region Methods Publics 
        public async Task PushAsync<TNewPage, TViewModel>()
            where TNewPage : class
            where TViewModel : class
        {
            var page = IoCApp.Container.GetInstance<TNewPage>() as Page;
            var viewModel = IoCApp.Container.GetInstance<TViewModel>();

            page.BindingContext = viewModel;

            await _page.Navigation.PushAsync(page as Page);
        }

        public async Task PushAsync<TNewPage, TViewModel>(Expression<Func<TViewModel, object>> property, object value)
           where TNewPage : class
           where TViewModel : class
        {
            if (value != null)
            {
                var page = IoCApp.Container.GetInstance<TNewPage>() as Page;
                var viewModel = IoCApp.Container.GetInstance<TViewModel>();

                page.BindingContext = viewModel;

                SetPropertyValue<TViewModel>(property.Body, viewModel, value);

                ((IBindingViewModel)viewModel).AfterBinding();

                await _page.Navigation.PushAsync(page as Page);
            }
        }

        public async Task PushModalAsync<TNewPage, TViewModel>()
            where TNewPage : class
            where TViewModel : class
        {
            var page = IoCApp.Container.GetInstance<TNewPage>() as Page;
            var viewModel = IoCApp.Container.GetInstance<TViewModel>();

            page.BindingContext = viewModel;

            await _page.Navigation.PushModalAsync(page as Page);
        }

        public async Task PushModalAsync<TNewPage, TViewModel>(Expression<Func<TViewModel, object>> property, object value)
            where TNewPage : class
            where TViewModel : class
        {
            if (value != null)
            {
                var page = IoCApp.Container.GetInstance<TNewPage>() as Page;
                var viewModel = IoCApp.Container.GetInstance<TViewModel>();

                page.BindingContext = viewModel;

                SetPropertyValue<TViewModel>(property.Body, viewModel, value);

                ((IBindingViewModel)viewModel).AfterBinding();

                await _page.Navigation.PushModalAsync(page as Page);
            }
        }

        public async Task NavigateTo<TPage>()
            where TPage: class
        {
            var reverseStack = _page.Navigation.NavigationStack.Reverse();
            foreach (var navPage in reverseStack)
            {
                if (navPage.GetType() == _page.GetType())
                    continue;
                if (typeof(TPage).GetTypeInfo().IsAssignableFrom(navPage.GetType().GetTypeInfo()))
                    break;
                else
                {
                    _page.Navigation.RemovePage(navPage);
                }

            }
            await _page.Navigation.PopAsync();
        }


        public async Task PopAsync()
        {
            await _page.Navigation.PopAsync();
        }
        #endregion

        #region Methods Privates
        private void SetPropertyValue<T>(Expression property, object root, object value)
        {
            var member = property as MemberExpression;
            var propertyInfo = member.Member as PropertyInfo;

            if (propertyInfo != null)
            {
                var propertySetter = root.GetType().GetTypeInfo()
                                    .DeclaredProperties
                                    .First(c => c.Name.Equals(propertyInfo.Name, StringComparison.OrdinalIgnoreCase));

                if (propertySetter != null)
                    propertySetter.SetValue(root, value);
            }
        } 
        #endregion

    }
}
