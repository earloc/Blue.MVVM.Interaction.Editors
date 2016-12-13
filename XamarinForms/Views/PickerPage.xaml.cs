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
    public abstract partial class PickerPage : EditorPage {

        public PickerPage() {
            InitializeComponent();
        }

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(PickerPage), null);

        public DataTemplate ItemTemplate {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }
    }
}
