using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blue.MVVM.IoC;
using Blue.MVVM.Navigation;
using Xamarin.Forms;
using Blue.MVVM.Navigation.ViewLocators;

namespace Blue.MVVM.Interaction.Editors.Views {
    [DefaultViewFor(typeof(string))]
    [DefaultViewFor(typeof(Uri))]
    public partial class StringEditor : ContentView  {

        public StringEditor() {
            InitializeComponent();
        }
    }
}
