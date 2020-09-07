using BizTalk.Monitor.Web.Models;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BizTalk.Monitor.Web.Views.Shared.Components.ChartJs
{

    [ViewComponent(Name ="chartjs")]
    public class ChartJsViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var chartData = @"{
                                type: 'bar',
                                data: {
                                    labels: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'],
                                    datasets: [{
                                        label: '# of Errors',
                                        data: [12, 19, 3, 5, 2, 3,8],
                                        backgroundColor: [
                                            'rgba(255, 99, 132, 0.2)',
                                            'rgba(54, 162, 235, 0.2)',
                                            'rgba(255, 206, 86, 0.2)',
                                            'rgba(75, 192, 192, 0.2)',
                                            'rgba(153, 102, 255, 0.2)',
                                            'rgba(255, 159, 64, 0.2)',
                                            'rgba(255, 59, 64, 0.2)'
                                        ],
                                        borderColor: [
                                            'rgba(255, 99, 132, 1)',
                                            'rgba(54, 162, 235, 1)',
                                            'rgba(255, 206, 86, 1)',
                                            'rgba(75, 192, 192, 1)',
                                            'rgba(153, 102, 255, 1)',
                                            'rgba(255, 159, 64, 1)',
                                            'rgba(255, 59, 64, 1)'
                                        ],
                                        borderWidth: 1
                                    }]
                                },
                                options: {
                                    scales: {
                                        yAxes: [{
                                            ticks: {
                                                beginAtZero: true
                                            }
                                        }]
                                    }
                                }
                            }";

            var chart = JsonConvert.DeserializeObject<BizTalk.Monitor.Web.Models.ChartTypes.ChartJs>(chartData);

            var chartModel = new ChartJsViewModel
            {
                Chart = chart,
                ChartJson = JsonConvert.SerializeObject(chart, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                })
            };

            return View(chartModel);
        }
    }
}
