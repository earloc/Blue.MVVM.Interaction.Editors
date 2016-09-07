using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.MVVM.Interaction.Editors.ViewModels {
    public class StringEditorPageViewModel : EditorViewModel<string>, IScalarEditorViewModel<string> {
        public string Placeholder {
            get; set;
        }

        public string Prompt {
            get; set;
        }

        public string Title {
            get; set;
        }

        protected override bool IsValidCore(string value) {
            return !string.IsNullOrEmpty(value);
        }
    }
}
