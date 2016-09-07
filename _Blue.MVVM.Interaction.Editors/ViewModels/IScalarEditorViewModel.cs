using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.MVVM.Interaction.Editors.ViewModels {
    public interface IScalarEditorViewModel<T> : IEditorViewModel<T>{
        
        string Title { get; set; }

        string Prompt { get; set; }

        string Placeholder { get; set; }

    }
}
