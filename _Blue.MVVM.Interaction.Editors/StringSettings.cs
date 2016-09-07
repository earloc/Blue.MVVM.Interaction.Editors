using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.MVVM.Interaction.Editors {
    //public class StringSettings : PromptSettings<string> {

    //    public StringSettings(string initialvalue = default(string), string prompt = default(string), string title = default(string), string placeholder = default(string))
    //        : base (initialvalue, prompt, title, placeholder) {
    //    }
    //}

    //public static class StringSettingsExtensions {
    //    public static StringSettings NotNullOrEmpty(this StringSettings source) {
    //        return source.And(x => !string.IsNullOrEmpty(x));
    //    }

    //    public static StringSettings And(this StringSettings source, Func<string, bool> validation) {
    //        var prev = source.Validate;
    //        source.Validate = (x) => {
    //            if (!validation(x))
    //                return false;
    //            return prev?.Invoke(x) ?? true;
    //        };
    //        return source;
    //    }
    //}
}
