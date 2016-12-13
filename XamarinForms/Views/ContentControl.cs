using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Blue.MVVM.Interaction.Editors.Views {
    public class ItemControl : ContentView {
        public ItemControl() {
            
        }

        public static readonly BindableProperty ItemProperty = BindableProperty.Create(nameof(Item), typeof(object), typeof(ItemControl), null, propertyChanged: OnItemChanged);

        public object Item {
            get { return (object)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        private static void OnItemChanged (BindableObject bindable, object oldValue, object newValue) {
            var that = (ItemControl)bindable;
            if (that == null)
                return;
            
            var content = that.ItemTemplate?.CreateContent() as View;
            if (content == null) {
                that.Content = null;
                return;
            }
            content.BindingContext = that.Item;

            that.Content = content;
        }

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(ItemControl), null, propertyChanged: OnItemTemplateChanged);

        public DataTemplate ItemTemplate {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        private static void OnItemTemplateChanged(BindableObject bindable, object oldValue, object newValue) {
            var that = (ItemControl)bindable;
            if (that == null)
                return;

            var template = newValue as DataTemplate;
            if (template == null) {
                that.Content = null;
                return;
            }

            var content = template.CreateContent() as View;
            if (content == null) {
                that.Content = null;
                return;
            }

            content.BindingContext = that.Item;

            that.Content = content;
        }

    }
}
