using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.MVVM.Interaction.Editors.ViewModels {
    public abstract class ScalarEditorViewModel<T> : EditorViewModel<T>, IScalarEditorViewModel<T> {

        public string Placeholder {
            get; set;
        }

        public string Prompt {
            get; set;
        }

        public string Title {
            get; set;
        }
    }
}
