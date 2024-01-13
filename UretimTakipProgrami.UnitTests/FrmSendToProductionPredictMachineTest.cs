using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;
using UretimTakipProgrami.Forms;

namespace UretimTakipProgrami.UnitTests
{
    public class FrmSendToProductionPredictMachineTest
    {
        private OrderRepository _orderRepository;
        private string orderId;
        private FrmSendToProduction _frmSendToProduction;

        public FrmSendToProductionPredictMachineTest()
        {
            _orderRepository = InstanceFactory.GetInstance<OrderRepository>();
            orderId = _orderRepository.GetWhere(u => u.Machine == null).FirstOrDefault().Id.ToString();
            _frmSendToProduction = new FrmSendToProduction(orderId);
        }

        [Test]
        public void FrmSendToPrediction_NotNull_PredictionParameters()
        {
            // Arrange
            List<object> prediction;
            int dataOfPastMonths = 3;
            string predictionString = string.Empty;
            List<Dictionary<string, string>> pr = new List<Dictionary<string, string>>();

            // Act
            for (int i = 1; i < 11; i++)
            {
                var stopwatch = Stopwatch.StartNew();
                prediction = _frmSendToProduction.PredictMachine(0.01f, i * 10, dataOfPastMonths, false);
                stopwatch.Stop();

                TimeSpan elapsedTime = stopwatch.Elapsed;

                string predictMachine = prediction.ElementAtOrDefault(0).ToString();
                string predictRate = (Convert.ToSingle(prediction.ElementAtOrDefault(1)) * 100).ToString("F3");

                predictionString = "Prediction: " + string.Join(" / ", prediction
                    .Where(item => item != null)  // Null olanları filtrele
                    .Select(item => item.ToString()));

                Dictionary<string, string> dictionary = new Dictionary<string, string>
                {
                    { "Iter ", i.ToString("D2") },
                    { "Elapsed Time (s) ", elapsedTime.TotalSeconds.ToString("F3") },
                    { "Number of Iteration ", (i * 10).ToString("D3").TrimStart('0').PadLeft(3, ' ') },
                    { "Prediction" , predictRate + " / " + predictMachine }
                };

                pr.Add(dictionary);
            }


            // Assert

            string prString = string.Join(Environment.NewLine, pr.Select(dict =>
            {
                return string.Join(", ", dict.Select(kv => $"{kv.Key}: {kv.Value}"));
            }));

            Assert.Pass(prString);

        }
    }
}
