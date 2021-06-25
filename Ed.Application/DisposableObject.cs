using System;
using System.Collections.Generic;
using System.Text;

namespace ED.Application
{
    public abstract class DisposableObject : IDisposable
    {
        private bool disposedValue = false;

        private List<IDisposable> _compositions;

        protected DisposableObject(IEnumerable<IDisposable> compositions)
        {
            _compositions =
                new List<IDisposable>(compositions ?? throw new ArgumentNullException(nameof(compositions)));
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if(disposing)
                {
                    foreach (var item in _compositions)
                    {
                        item.Dispose();
                    }
                }

                _compositions?.Clear();
                _compositions = null;
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~DisposableObject()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
