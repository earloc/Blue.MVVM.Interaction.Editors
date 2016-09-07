using Blue.MVVM.Interaction.Editors.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.MVVM.Interaction.Editors {
    public interface IEditor<T> : IInteraction<IEditorViewModel<T>, T> {
    }
}
