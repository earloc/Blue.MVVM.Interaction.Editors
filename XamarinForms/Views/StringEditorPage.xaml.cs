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
    public partial class StringEditorPage : Editor {


        public StringEditorPage(IViewLocator viewLocator, ITypeResolver typeResolver)
            : base(viewLocator, typeResolver) {
            InitializeComponent();
        }
    }
}
