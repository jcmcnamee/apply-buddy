using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Utilities;

public class Mapper<TSource, TDestination>
{
    // Create destination obj
    TDestination destination = Activator.CreateInstance<TDestination>();

    // Loop through source and match properties
    public TDestination Map(TSource source)
    {
        foreach (var sourceProperty in typeof(TSource).GetProperties())
        {
            var destinationProperty = typeof(TDestination).GetProperty(sourceProperty.Name);

            if (destinationProperty != null)
            {
                destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }

        return destination;
    }
}
