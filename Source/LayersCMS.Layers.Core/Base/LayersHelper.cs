using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LayersCMS.Layers.Core.Base
{
    public class LayersHelper
    {
        /// <summary>
        /// Get a collection of enabled layers
        /// </summary>
        public IEnumerable<Layer> GetEnabledLayers()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Layers")))
            {
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.IsSubclassOf(typeof(Layer)))
                    {
                        Layer layer = (Layer)Activator.CreateInstance(type);

                        if (layer.Enabled)
                            yield return layer;
                    }
                }
            }
        }

        /// <summary>
        /// Get an enabled layer by its Name property
        /// </summary>
        public Layer GetEnabledLayerByName(string name)
        {
            if (name == null) throw new ArgumentNullException("name");

            return
                GetEnabledLayers()
                    .FirstOrDefault(
                        layer => string.Compare(layer.Name, name, StringComparison.InvariantCultureIgnoreCase) == 0);
        }

        /// <summary>
        /// Returns true if an enabled layer is found by this name
        /// </summary>
        public bool LayerIsEnabled(string name)
        {
            if (name == null) throw new ArgumentNullException("name");

            return GetEnabledLayerByName(name) != null;
        }
    }
}
