using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blue.MVVM.Interaction.Editors.ViewModels;
using Blue.MVVM.Navigation;
using System.Linq;


namespace Blue.MVVM.Interaction.Editors {
    public class Picker<T> : IPicker<T> {
        public async Task<IEnumerable<T>> RunAsync(IPickerViewModel<T> p = null) {
            if (p == null)
                throw new ArgumentNullException(nameof(p), "must not be null");

            await _Navigator.TryShowModalAsync(p);
            var result = await p.GetResultAsync();
            await _Navigator.TryPopModalAsync();
            return result;
        }

        private readonly IModalNavigator _Navigator;

        public Picker(IModalNavigator navigator) {
            _Navigator = navigator;
        }
    }
}
