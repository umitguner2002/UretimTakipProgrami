using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UretimTakipProgrami.Predictions
{
    public class MachineData
    {
        [LoadColumn(0)]
        public float Performance { get; set; }

        [LoadColumn(1)]
        public float WorkTime { get; set; }
        
        [LoadColumn(2), ColumnName("ProductId")]
        public string? ProductId { get; set; }

        [LoadColumn(3)]
        public float OrderQuantity { get; set; }

        [LoadColumn(4)]
        public float DeliveryTime { get; set; }

        [LoadColumn(5), ColumnName("MachineId")]
        public string? MachineId { get; set; }
    }
}
