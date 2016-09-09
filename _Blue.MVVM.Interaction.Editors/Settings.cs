using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.MVVM.Interaction.Editors {
    public class Settings {

        public static Settings Default { get; } = new Settings();


        public string PrimaryCommandText { get; set; } = "Ok";
        public string SecondaryCommandText { get; set; } = "Cancel";



    }
}
