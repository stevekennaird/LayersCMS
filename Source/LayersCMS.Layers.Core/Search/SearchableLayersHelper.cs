using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LayersCMS.Layers.Core.Search
{
    public class SearchableLayersHelper
    {
        public IEnumerable<ISearchableLayer> GetSearchableLayers()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Layers")))
            {
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (typeof(ISearchableLayer).IsAssignableFrom(type) && !type.IsInterface)
                    {
                        yield return (ISearchableLayer)Activator.CreateInstance(type);
                    }
                }
            }
        }


    }
}
