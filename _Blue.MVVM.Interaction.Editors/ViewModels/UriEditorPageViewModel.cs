using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.MVVM.Interaction.Editors.ViewModels {
    public class UriEditorPageViewModel : ScalarEditorViewModel<Uri> {

        protected override bool IsValidCore(Uri value) {
            return value != null;
        }
    }
}
