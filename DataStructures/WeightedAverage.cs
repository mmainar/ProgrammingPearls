using System;
using System.Collections.Generic;
using System.Linq;
using static DataStructures.WeightedAverage;

namespace DataStructures
{
    public static class WeightedAverage
    {


        public static double Calculate<TWeight, TValue>(this IEnumerable<WeightValue<TWeight, TValue>> values)
            where TWeight : IComparable, IFormattable, IConvertible, IComparable<Double>, IEquatable<Double>
            where TValue : IComparable, IFormattable, IConvertible, IComparable<Double>, IEquatable<Double>
        {
            double sum = 0;

            //foreach (var val in values)
            //{
            //    sum += val.Value * val.Weight;
            //}

            //return sum / values.Sum(v => v.Weight);
            return sum;
        }
    }
}
