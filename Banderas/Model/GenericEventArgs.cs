using System;
using System.Collections.Generic;

namespace Banderas.Model
{
    public class GenericEventArgs<T> : EventArgs
    {
        public IList<T> Result { get; set; }
        public GenericEventArgs(IList<T> resul)
        {
            Result = resul;
        }
    }
}