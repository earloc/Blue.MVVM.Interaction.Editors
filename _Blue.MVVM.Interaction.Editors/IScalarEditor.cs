using Blue.MVVM.Interaction.Editors.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blue.MVVM.Interaction.Editors {
    public interface IScalarEditor<T> : IInteraction<IScalarEditorViewModel<T>, T> {
    }

    public static class IScalarEditorExtensions {
        public static async Task<string> TryRunAsync(this IScalarEditor<string> source, string value, string title = "", string prompt = "", string placeholder = "", string primaryText = "", string secondaryText = "") {
            if (source == null)
                return null;
            var vm = new StringEditorPageViewModel() {
                Value = value,
                Title = title,
                Prompt = prompt,
                Placeholder = placeholder,
                PrimaryCommandText = primaryText ?? Settings.Default.PrimaryCommandText,
                SecondaryCommandText = secondaryText ?? Settings.Default.SecondaryCommandText
            };
            return await source.TryRunAsync(vm);
        }
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

        public static async Task<Uri> TryRunAsync(this IScalarEditor<Uri> source, Uri value, string title = "", string prompt = "", string placeholder = "", string primaryText = "", string secondaryText = "") {
            if (source == null)
                return null;
            var vm = new UriEditorPageViewModel() {
                Value = value,
                Title = title,
                Prompt = prompt,
                Placeholder = placeholder,
                PrimaryCommandText = primaryText ?? Settings.Default.PrimaryCommandText,
                SecondaryCommandText = secondaryText ?? Settings.Default.SecondaryCommandText
            };
            return await source.TryRunAsync(vm);
        }
    }


}
