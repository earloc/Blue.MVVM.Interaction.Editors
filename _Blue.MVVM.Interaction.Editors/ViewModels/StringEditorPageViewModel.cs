using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.MVVM.Interaction.Editors.ViewModels {
    public class StringEditorPageViewModel : ScalarEditorViewModel<string> {
       
        protected override bool IsValidCore(string value) {
            return !string.IsNullOrEmpty(value);
        }
    }
}
