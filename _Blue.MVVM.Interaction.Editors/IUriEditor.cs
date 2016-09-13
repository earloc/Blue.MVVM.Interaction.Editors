using Blue.MVVM.Interaction;
using Blue.MVVM.Interaction.Editors.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blue.MVVM.Interaction.Editors {
    public interface IUriEditor : IScalarEditor<Uri> {
    }

    public static class IUriEditorExtensions {
        public static async Task<Uri> TryRunAsync(this IScalarEditor<Uri> source, Uri value, string title = "", string prompt = "", string placeholder = "", string primaryText = "", string secondaryText = "") {
            if (source == null)
                return null;
            var vm = new UriEditorPageViewModel() {
                Value = value,
                Title = title,
                Prompt = prompt,
                Placeholder = placeholder,
                PrimaryCommandText = primaryText??Settings.Default.PrimaryCommandText,
                SecondaryCommandText = secondaryText ?? Settings.Default.SecondaryCommandText
            };
            return await source.TryRunAsync(vm);
        }
    }
}
