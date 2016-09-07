using Blue.MVVM.Interaction.Editors.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.MVVM.Interaction.Editors {
    public interface IScalarEditor<T> : IInteraction<IScalarEditorViewModel<T>, T> {
    }
}
