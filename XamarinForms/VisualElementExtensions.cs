using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Blue.MVVM.Interaction.Editors {
    public static class VisualElementExtensions {

        public static async Task SlideIn(this VisualElement element, SlideIn direction = Editors.SlideIn.FromTop, uint linearLength = 250, uint springLength = 50, int springiness = 20) {
            if (element == null)
                throw new ArgumentNullException(nameof(element), "must not be null");
            var springX = 0;
            var springY = 0;

            switch (direction) {
                case Editors.SlideIn.FromLeft:
                    springX = springiness;
                    springY = 0;
                    break;
                case Editors.SlideIn.FromTop:
                    springX = 0;
                    springY = springiness;
                    break;
                case Editors.SlideIn.FromRight:
                    springX = -springiness;
                    springY = 0;
                    break;
                case Editors.SlideIn.FromBottom:
                    springX = 0;
                    springY = springiness;
                    break;
               
            }

            await element.TranslateTo(0, 0, linearLength, Easing.Linear);
            await element.TranslateTo(springX, springY, springLength, Easing.CubicOut);
            await element.TranslateTo(0, 0, springLength, Easing.CubicIn);
        }

        public static async Task SlideOut(this VisualElement element, SlideOut direction = Editors.SlideOut.ToTop, uint linearLength = 250, uint springLength = 50, int springiness = 20) {
            if (element == null)
                throw new ArgumentNullException(nameof(element), "must not be null");
            var destX = 0;
            var destY = 0;
            var springX = 0;
            var springY = 0;

            switch (direction) {
                
                case Editors.SlideOut.ToLeft:
                    destX = -1000;
                    springX = springiness;
                    destY = 0;
                    springY = 0;
                    break;
                case Editors.SlideOut.ToTop:
                    destX = 0;
                    springX = 0;
                    destY = -1000;
                    springY = springiness;
                    break;
                case Editors.SlideOut.ToRight:
                    destX = 1000;
                    springX = -springiness;
                    destY = 0;
                    springY = 0;
                    break;
                case Editors.SlideOut.ToBottom:
                    destX = 0;
                    springX = 0;
                    destY = 1000;
                    springY = springiness;
                    break;
                
                
            }


            await element.TranslateTo(springX, springY, springLength, Easing.CubicOut);
            await element.TranslateTo(0, 0, springLength, Easing.CubicIn);
            await element.TranslateTo(destX, destY, linearLength, Easing.Linear);
        }
    }
}
