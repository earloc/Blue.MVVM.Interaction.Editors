using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.MVVM.Interaction.Editors.ViewModels {
    public class BoolEditorPageViewModel : ScalarEditorViewModel<bool> {

        public BoolEditorPageViewModel() {
            PrimaryCommand.Executing += (sender, e) => Value = true;
            SecondaryCommand.Executing += (sender, e) => Value = false;
        }
    }
}
