using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Reform
{
    public static class TransformLoader
    {
        private static Dictionary<Type, object> _transformers;

        static TransformLoader()
        {
            _transformers = Assembly.GetEntryAssembly()
                .GetTypes()
                .Where(type => type.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ITransformer<,>)) && type.IsClass)
                .Select(Activator.CreateInstance)
                .ToDictionary(a => a.GetType().GetInterfaces().First(x => x.Name.Contains("ITransformer")).GetGenericArguments().First(), b => b);
        }
        
        public static TTo Transform<TFrom, TTo>(this TFrom obj)
        {
            var transformer = _transformers[typeof(TTo)] as ITransformer<TTo, TFrom>;

            return transformer.Transform(obj);
        }

        public static bool TryTransform<TFrom, TTo>(this TFrom obj, out TTo to)
        {
            if (!_transformers.TryGetValue(typeof(TFrom), out var possibleTransformer))
            {
                to = default;
                return false;
            }
            var transformer = possibleTransformer as ITransformer<TTo, TFrom>;

            return transformer.TryTransform(obj, out to);
        }
    }
}