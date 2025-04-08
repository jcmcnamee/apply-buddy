using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBuddy.Application.Utilities;

public class Mapper //: IMapper<TSource, TDestination>
{

    // Loop through source and match properties
    public TDestination Map<TDestination>(object source)
    {
        TDestination destination = Activator.CreateInstance<TDestination>();


        foreach (var sourceProperty in source.GetType().GetProperties())
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
