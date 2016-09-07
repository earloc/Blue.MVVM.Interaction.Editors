using Blue.MVVM.Interaction.Editors;
using Blue.MVVM.Interaction.Editors.ViewModels;
using Blue.MVVM.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blue.MVVM.Interaction.Editors {
    public class StringEditor : ScalarEditor<string>, IStringEditor {
        public StringEditor(IModalNavigator navigator) : base (navigator) {

        }
    }
}
