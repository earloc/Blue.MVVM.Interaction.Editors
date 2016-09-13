using Blue.MVVM.Interaction.Editors.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blue.MVVM.Interaction.Editors {
    public interface IBoolEditor : IScalarEditor<bool> {
    }

    public static class IBoolEditorExtensions {
        public static async Task<bool> TryRunAsync(this IScalarEditor<bool> source, string title = "", string prompt = "", string primaryText = "", string secondaryText = "") {
            if (source == null)
                return false;
            var vm = new BoolEditorPageViewModel() {
                Title = title,
                Prompt = prompt,
                PrimaryCommandText = primaryText ?? Settings.Default.PrimaryCommandText,
                SecondaryCommandText = secondaryText ?? Settings.Default.SecondaryCommandText
            };
            return await source.TryRunAsync(vm);
        }
    }
}
