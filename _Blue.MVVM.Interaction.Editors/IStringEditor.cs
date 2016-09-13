﻿using Blue.MVVM.Interaction;
using Blue.MVVM.Interaction.Editors.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blue.MVVM.Interaction.Editors {
    public interface IStringEditor : IScalarEditor<string> {
    }

    public static class IStringEditorExtensions {
        public static async Task<string> TryRunAsync(this IScalarEditor<string> source, string value, string title = "", string prompt = "", string placeholder = "", string primaryText = "", string secondaryText = "") {
            if (source == null)
                return null;
            var vm = new StringEditorPageViewModel() {
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
