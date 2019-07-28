using System;
using System.Collections.Generic;
using System.Linq;

namespace FileFormats.Formats
{
    public abstract class FileFormat
    {
        private readonly ILookup<Type, object> _Traits;

        protected FileFormat(IEnumerable<object> traits)
        {
            if (traits == null)
                throw new ArgumentNullException(nameof(traits));

            _Traits = traits.ToLookup(trait => trait.GetType());
        }

        public IEnumerable<object> AllTraits() => _Traits.SelectMany(g => g.ToList());
        public IEnumerable<T> Traits<T>() => _Traits[typeof(T)].OfType<T>();
        public IEnumerable<object> Traits(Type type) => _Traits[type];
    }
}