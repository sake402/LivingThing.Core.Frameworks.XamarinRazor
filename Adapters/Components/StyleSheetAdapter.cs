using System;
using System.IO;
using XF = Xamarin.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components
{
    internal class StyleSheetAdapter : IComponentAdapter<StyleSheet>
    {
        public object Adapt(StyleSheet sheet, IComponentAdapterController rootAdapter)
        {
            rootAdapter.VisualElement.ContinueWith(task =>
            {
                var _parentVisualElement = task.Result;
                // TODO: Add logic to ensure same resource isn't added multiple times
                if (sheet.Resource != null)
                {
                    if (sheet.Assembly == null)
                    {
                        throw new InvalidOperationException($"Specifying a '{nameof(sheet.Resource)}' property value '{sheet.Resource}' requires also specifying the '{nameof(sheet.Assembly)}' property to indicate the assembly containing the resource.");
                    }
                    var styleSheet = XF.StyleSheets.StyleSheet.FromResource(resourcePath: sheet.Resource, assembly: sheet.Assembly);
                    _parentVisualElement.Resources.Add(styleSheet);
                }
                if (sheet.Text != null)
                {
                    using var reader = new StringReader(sheet.Text);
                    var styleSheet = XF.StyleSheets.StyleSheet.FromReader(reader);
                    _parentVisualElement.Resources.Add(styleSheet);
                }
            });
            return null;
        }
    }
}
