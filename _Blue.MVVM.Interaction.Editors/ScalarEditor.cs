using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blue.MVVM.Interaction.Editors.ViewModels;
using Blue.MVVM.Navigation;

namespace Blue.MVVM.Interaction.Editors {
    public abstract class ScalarEditor<T> : Editor<T>, IScalarEditor<T> {

        public ScalarEditor(IModalNavigator navigator) 
            : base(navigator) {
        }

        public Task<T> RunAsync(IScalarEditorViewModel<T> p) {
            return base.RunAsync(p);
        }
    }
}
