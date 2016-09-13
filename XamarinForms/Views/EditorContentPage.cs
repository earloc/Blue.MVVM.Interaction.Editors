using Blue.MVVM.Interaction.Editors.ViewModels;
using Blue.MVVM.IoC;
using Blue.MVVM.Navigation.ViewLocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Blue.MVVM.Interaction.Editors.Views {
    public class EditorContentPage : EditorPage {
        public EditorContentPage(IViewLocator viewLocator, ITypeResolver typeResolver) {
            if (viewLocator == null)
                throw new ArgumentNullException(nameof(viewLocator), "must not be null");
            _ViewLocator = viewLocator;
            if (typeResolver == null)
                throw new ArgumentNullException(nameof(typeResolver), "must not be null");
            _TypeResolver = typeResolver;
        }
        private readonly IViewLocator _ViewLocator;
        private readonly ITypeResolver _TypeResolver;

        protected async override void OnBindingContextChanged() {
            base.OnBindingContextChanged();

            if (BindingContext == null) {
                var label = new Label();
                EditorContent = null;
                return;
            }

            var editViewModel = BindingContext as IEditorViewModel;
            if (editViewModel == null) {
                var label = new Label();
                EditorContent = null;
                return;
            }

            var contentViewType = await _ViewLocator.ResolveViewTypeForAsync(editViewModel.ContentType);

            if (contentViewType == null) {
                EditorContent = new Label() { Text = editViewModel.Content?.ToString() ?? $"<NULL> ({editViewModel.ContentType.AssemblyQualifiedName}" };
                return;
            }

            var view = _TypeResolver.ResolveAs<View>(contentViewType);

            EditorContent = view;
        }
    }
}
