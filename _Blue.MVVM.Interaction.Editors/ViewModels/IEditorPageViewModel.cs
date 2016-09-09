using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blue.MVVM.Interaction.Editors.ViewModels {

    public interface IEditorViewModel {
        object Content { get; }
        Type ContentType { get; }
    }

    public interface IEditorViewModel<T> : IEditorViewModel {
        T Value { get; set; }

        Task<T> GetResultAsync();
    }
}
