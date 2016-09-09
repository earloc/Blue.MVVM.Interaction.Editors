using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Blue.MVVM.Interaction.Editors;
using Blue.MVVM.Navigation;
using Blue.MVVM.Interaction.Editors.ViewModels;
using Blue.MVVM.IoC;
using Blue.MVVM.Navigation.ViewLocators;

namespace Blue.MVVM.Interaction.Editors.Views {
    public partial class Editor : ContentPage, INavigationAwareView {

        private readonly IViewLocator _ViewLocator;
        private readonly ITypeResolver _TypeResolver;

        public Editor(IViewLocator viewLocator, ITypeResolver typeResolver) {
            InitializeComponent();

            if (viewLocator == null)
                throw new ArgumentNullException(nameof(viewLocator), "must not be null");
            _ViewLocator = viewLocator;
            if (typeResolver == null)
                throw new ArgumentNullException(nameof(typeResolver), "must not be null");
            _TypeResolver = typeResolver;

            _PrimaryButton.Clicked += _PrimaryButton_Clicked;
            _SecondaryButton.Clicked += _SecondaryButton_Clicked;
        }

        public static readonly BindableProperty EditorContentProperty = BindableProperty.Create(nameof(EditorContent), typeof(View), typeof(Editor), null);

        public View EditorContent {
            get { return (View)GetValue(EditorContentProperty); }
            set { SetValue(EditorContentProperty, value); }
        }

        protected async override void OnBindingContextChanged() {
            base.OnBindingContextChanged();

            if (EditorContent != null) {
                _ContentView.Content = EditorContent;
                return;
            }

            if (BindingContext == null) {
                var label = new Label();
                _ContentView.Content = null;
                return;
            }

            var editViewModel = BindingContext as IEditorViewModel;
            if (editViewModel == null) {
                var label = new Label();
                _ContentView.Content = null;
                return;
            }

            var contentViewType = await _ViewLocator.ResolveViewTypeForAsync(editViewModel.ContentType);

            if (contentViewType == null) {
                _ContentView.Content = new Label() { Text = editViewModel.Content?.ToString()??$"<NULL> ({editViewModel.ContentType.AssemblyQualifiedName}" };
                return;
            }

            var view = _TypeResolver.ResolveAs<View>(contentViewType);

            _ContentView.Content = view;
        }


        private TaskCompletionSource<bool> _Result = new TaskCompletionSource<bool>();
        private void _SecondaryButton_Clicked(object sender, EventArgs e) {
            _Result.SetResult(false);
        }

        private void _PrimaryButton_Clicked(object sender, EventArgs e) {
            _Result.SetResult(true);
        }

        public async Task AppearingAsync() {
            _Content.TranslationY = -1000;
            _Content.TranslationX = 0;
            await Task.Yield();
        }

        public async Task AppearedAsync() {
            await Task.Delay(250);
            await _Content.SlideIn();
        }

        public async Task DisappearingAsync() {
            if (await _Result.Task)
                await _Content.SlideOut(SlideOut.ToRight);
            else
                await _Content.SlideOut(SlideOut.ToLeft);
        }

        public async Task DisappearedAsync() {
            await Task.Yield();
        }
    }
}
