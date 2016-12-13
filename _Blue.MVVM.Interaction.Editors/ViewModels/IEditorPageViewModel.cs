using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blue.MVVM.Interaction.Editors.ViewModels {

    public interface IEditorViewModel<T> {
        T Value { get; set; }

        Task<T> GetResultAsync();
    }
}
