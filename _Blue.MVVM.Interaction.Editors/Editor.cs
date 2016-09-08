using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blue.MVVM.Interaction.Editors.ViewModels;
using Blue.MVVM.Navigation;

namespace Blue.MVVM.Interaction.Editors {
    public abstract class Editor<T> : IEditor<T> {
        private readonly IModalNavigator _Navigator;

        public Editor(IModalNavigator navigator) {
            _Navigator = navigator;
        }

        public async Task<T> RunAsync(IEditorViewModel<T> p) {
            if (p == null)
                throw new ArgumentNullException(nameof(p), "must not be null");

            await _Navigator.TryShowModalAsync(p);
            var result = await p.GetResultAsync();
            await _Navigator.TryPopModalAsync();
            return result;
        }
    }
}
