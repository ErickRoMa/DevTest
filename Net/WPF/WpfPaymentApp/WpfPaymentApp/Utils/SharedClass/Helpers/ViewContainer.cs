using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace WpfPaymentApp.ViewModel.SharedClass.Helpers
{
    internal class ViewContainer : IDisposable
    {
        private static ViewContainer _instance = default;

        private readonly Dictionary<String, object> _viewCollector = default;

        private ViewContainer()
        {
            _viewCollector = new Dictionary<string, object>();
        }

        public static ViewContainer GetContainerView { get { return _instance = _instance ?? new ViewContainer(); } }

        public object AddNewViewIntance(string viewIdentifier, Assembly assembly)
        {
            if (_viewCollector.ContainsKey(viewIdentifier))
            {
                return GetViewInstance(viewIdentifier);
            }

            Type typeObject = assembly.GetTypes()
                                      .Where(r => r.FullName == viewIdentifier).FirstOrDefault();
            object selectedView = Activator.CreateInstance(typeObject);

            _viewCollector.Add(viewIdentifier, selectedView);

            return selectedView;
        }

        public void RemoveViewInstance(string viewIdentifier)
        {
            if (!_viewCollector.ContainsKey(viewIdentifier))
            {
                return;
            }

            _viewCollector.Remove(viewIdentifier);
        }

        public object GetViewInstance(string viewIdentifier)
        {
            if (!_viewCollector.ContainsKey(viewIdentifier))
            {
                return null;
            }
            return _viewCollector[viewIdentifier];
        }

        public bool ContainsView(string viewIdentifier)
        {
            return _viewCollector.ContainsKey(viewIdentifier);
        }

        public void Dispose()
        {
            _viewCollector.Clear();
        }
    }
}
