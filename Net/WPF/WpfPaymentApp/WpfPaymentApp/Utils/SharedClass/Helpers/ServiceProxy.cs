using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;

namespace WpfPaymentApp.ViewModel.SharedClass.Helpers
{
    internal class ServerProxy<T> : IDisposable
    {
        private T _service = default;

        private readonly ChannelFactory<T> _factory = default;
        private Configuration _config = default;
        private ServiceModelSectionGroup _srvMdlGrp = default;
        private ChannelEndpointElement _endPoint = default;

        public ServerProxy()
        {
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _srvMdlGrp = ServiceModelSectionGroup.GetSectionGroup(_config);
            Type tInterface = typeof(T);
            IEnumerable<ChannelEndpointElement> endPoints = _srvMdlGrp.Client.Endpoints.Cast<ChannelEndpointElement>();
            _endPoint = endPoints.Where(r => r.Contract == tInterface.FullName).FirstOrDefault();

            if (_endPoint == default)
                throw new ConfigurationErrorsException("The specified endpoint is not found.");
            if (string.IsNullOrEmpty(_endPoint.Name))
                throw new ConfigurationErrorsException("The specified endpoint has not defined name.");
            
            _factory = new ChannelFactory<T>(_endPoint.Name);

            this._service = _factory.CreateChannel();
        }

        public T Service { get => _service; set => _service = value; }

        public void Dispose()
        {
            _config = default;
            _srvMdlGrp = default;
            _endPoint = default;

            if (_factory != null && !_factory.State.HasFlag(CommunicationState.Closed))
            {
                _factory.Close();
            }

        }
    }
}
