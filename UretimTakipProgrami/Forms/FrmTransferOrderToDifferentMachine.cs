using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmTransferOrderToDifferentMachine : Form
    {
        private MachineRepository _machineRepository;
        private OrderRepository _orderRepository;
        private Order order;
        private int _productionQuantity;

        public FrmTransferOrderToDifferentMachine(string orderId, int productionQuantity)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Text = string.Empty;
            this.ControlBox = false;

            _machineRepository = InstanceFactory.GetInstance<MachineRepository>();
            _orderRepository = InstanceFactory.GetInstance<OrderRepository>();

            order = _orderRepository.GetWhere(x => x.Id == Guid.Parse(orderId)).FirstOrDefault();
            _productionQuantity = productionQuantity;
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_productionQuantity == 0)
            {
                await _orderRepository.AddAsync(new()
                {
                    CreatedDate = order.CreatedDate,
                    OrderCode = order.OrderCode,
                    Quantity = order.Quantity,
                    Description = order.Description,
                    DeliveryDate = order.DeliveryDate,
                    IsUrgent = order.IsUrgent,
                    IsWaiting = order.IsWaiting,
                    IsProduction = order.IsProduction,
                    IsReady = order.IsReady,
                    FinishDate = order.FinishDate,
                    ProductId = order.ProductId,
                    CustomerId = order.CustomerId,
                    UserId = order.UserId,
                    MachineId = Guid.Parse(listTezgah.SelectedValue.ToString())
                });

                _orderRepository.Delete(order.Id.ToString());
            }
            else
            {
                await _orderRepository.AddAsync(new()
                {
                    CreatedDate = order.CreatedDate,
                    OrderCode = order.OrderCode,
                    Quantity = order.Quantity - _productionQuantity,
                    Description = order.Description,
                    DeliveryDate = order.DeliveryDate,
                    IsUrgent = order.IsUrgent,
                    IsWaiting = order.IsWaiting,
                    IsProduction = order.IsProduction,
                    IsReady = order.IsReady,
                    FinishDate = order.FinishDate,
                    ProductId = order.ProductId,
                    CustomerId = order.CustomerId,
                    UserId = order.UserId,
                    MachineId = Guid.Parse(listTezgah.SelectedValue.ToString())
                });

                order.Quantity = _productionQuantity;
                order.IsReady = true;
                order.IsProduction = false;
                order.FinishDate = DateTime.UtcNow;                
            }

            _orderRepository.Save();
            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTransferOrderToDifferentMachine_Load(object sender, EventArgs e)
        {
            GetMachineList();

            if (listTezgah.Items.Count > 0)
                listTezgah.SelectedIndex = 0;
        }

        private void GetMachineList()
        {
            try
            {
                var machineList = _machineRepository.GetWhere(machine => machine.Id != order.MachineId)
                .Select(machine => new
                {
                    machine.Id,
                    machine.Name
                })
                .ToList();

                if (machineList != null)
                {
                    listTezgah.DataSource = machineList;
                    listTezgah.DisplayMember = "Name";
                    listTezgah.ValueMember = "Id";
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.ToString()}");
            }
        }
    }
}
