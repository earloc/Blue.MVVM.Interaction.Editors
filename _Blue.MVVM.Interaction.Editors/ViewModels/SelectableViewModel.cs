using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.MVVM.Interaction.Editors.ViewModels {
    class SelectableViewModel<T> : NotifyPropertyChangedBase, ISelectableViewModel<T> {


        public bool IsSelected {
            get {
                return _IsSelected;
            }
            set {
                this.Set(ref _IsSelected, value, nameof(IsSelected));
                IsSelectedChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private bool _IsSelected = default(bool);

        public T Item {
            get {
                return _Item;
            }
            set {
                this.Set(ref _Item, value, nameof(Item));
            }
        }
        private T _Item = default(T);

        public event EventHandler IsSelectedChanged;

        public bool IsSelectable {
            get {
                return _IsSelectable;
            }
            set {
                this.Set(ref _IsSelectable, value, nameof(IsSelectable));
            }
        }
        private bool _IsSelectable = default(bool);



    }
}
