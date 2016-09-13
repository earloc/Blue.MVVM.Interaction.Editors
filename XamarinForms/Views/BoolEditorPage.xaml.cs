using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blue.MVVM.IoC;
using Blue.MVVM.Navigation;
using Xamarin.Forms;
using Blue.MVVM.Navigation.ViewLocators;
using Blue.MVVM.Interaction.Editors.ViewModels;

namespace Blue.MVVM.Interaction.Editors.Views {
    [DefaultViewFor(typeof(EditorViewModel<Uri>))]
    public partial class BoolEditorPage : EditorPage {
        public BoolEditorPage() {
            InitializeComponent();
        }
    }
}
