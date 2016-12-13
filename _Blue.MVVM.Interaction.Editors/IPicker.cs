using Blue.MVVM.Interaction.Editors.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue.MVVM.Interaction.Editors {
    public interface IPicker<T> : IInteraction<IPickerViewModel<T>, IEnumerable<T>> {
    }

    public static class IPickerExtensions {
        public static async Task<IEnumerable<T>> TryRunAsync<T>(this IPicker<T> source, IEnumerable<T> context, IEnumerable<T> selected = null, string title = "", string prompt = "", string primaryText = "", string secondaryText = "", bool freezeSelected = false) {
            if (source == null)
                return Enumerable.Empty<T>();

            var vm = new PickerViewModel<T>(context, selected, title, prompt, primaryText, secondaryText, freezeSelected);

            return await source.RunAsync(vm);
        }
    }
}
