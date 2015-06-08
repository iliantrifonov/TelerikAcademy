namespace WCF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;

    using Data;
    using Model;

    public class AlertsService : IAlertsService
    {

        private AlertsData data;

        public AlertsService()
        {
            this.data = new AlertsData();
        }

        public IEnumerable<AlertModel> GetAlerts()
        {
            var alerts = this.data.Alerts.All()
                .Where(a => a.DateOfExpiration <= DateTime.Now)
                .OrderBy(a => a.DateOfExpiration)
                .Select(a => new AlertModel()
                {
                    Content = a.Content,
                    Id = a.Id
                })
                .ToArray();

            return alerts;
        }
    }
}
