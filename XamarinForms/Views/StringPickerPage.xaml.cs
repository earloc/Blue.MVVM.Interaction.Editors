using Blue.MVVM.Interaction.Editors.ViewModels;
using Blue.MVVM.Navigation.ViewLocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Blue.MVVM.Interaction.Editors.Views {
    [DefaultViewFor(typeof(PickerViewModel<string>))]
    public partial class StringPickerPage : PickerPage {
        public StringPickerPage() {
            InitializeComponent();

        }
    }
}
