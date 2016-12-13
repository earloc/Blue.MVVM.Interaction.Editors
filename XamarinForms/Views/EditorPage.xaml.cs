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
    [DefaultViewFor(typeof(EditorViewModel<>))]
    public abstract partial class EditorPage : ContentPage, INavigationAwareView {

        public EditorPage() {
            InitializeComponent();
            _Content.BackgroundColor = Device.OnPlatform(Color.White, Color.Black, Color.Black);
            _PrimaryButton.Clicked += _PrimaryButton_Clicked;
            _SecondaryButton.Clicked += _SecondaryButton_Clicked;
        }

        public static readonly BindableProperty EditorContentProperty = BindableProperty.Create(nameof(EditorContent), typeof(View), typeof(Editor), null);

        public View EditorContent {
            get { return (View)GetValue(EditorContentProperty); }
            set { SetValue(EditorContentProperty, value); }
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
