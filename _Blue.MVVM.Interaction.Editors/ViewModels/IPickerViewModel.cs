using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blue.MVVM.Interaction.Editors.ViewModels {
    public interface IPickerViewModel<T> {
        IEnumerable<ISelectableViewModel<T>> Context { get; set; }
        Task<IEnumerable<T>> GetResultAsync();

        string Prompt {
            get; set;
        }

        string Title {
            get; set;
        }

        
    }
}
