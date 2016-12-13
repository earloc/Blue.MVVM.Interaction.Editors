using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.MVVM.Interaction.Editors.ViewModels {
    public interface ISelectableViewModel<T> {
        T Item { get; set; }
        bool IsSelected { get; set; }

        event EventHandler IsSelectedChanged;

        bool IsSelectable { get; set; }
    }
}
