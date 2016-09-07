using Blue.MVVM.Interaction.Editors.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blue.MVVM.Interaction.Editors {
    public static class IStringEditorExtensions {

        public static async Task<string> TryRunAsync(this IStringEditor source, string value, string title = "", string prompt = "", string placeholder = "") {
            if (source == null)
                return null;
            var vm = new StringEditorPageViewModel() {
                Value = value,
                Title = title,
                Prompt = prompt,
                Placeholder = placeholder
            };
            return await source.TryRunAsync(vm);
        }
    }
}
