using Microsoft.EntityFrameworkCore.Infrastructure;
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
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Forms
{
    public partial class DataEkleme : Form
    {
        private ProductionRepository _productionRepository;
        private OrderRepository _orderRepository;
        private UserRepository _userRepository;
        private ProductRepository _productRepository;
        private CustomerRepository _customerRepository;
        private MachineRepository _machineRepository;

        public DataEkleme()
        {
            InitializeComponent();

            _productionRepository = InstanceFactory.GetInstance<ProductionRepository>();
            _orderRepository = InstanceFactory.GetInstance<OrderRepository>();
            _userRepository = InstanceFactory.GetInstance<UserRepository>();
            _productRepository = InstanceFactory.GetInstance<ProductRepository>();
            _customerRepository = InstanceFactory.GetInstance<CustomerRepository>();
            _machineRepository = InstanceFactory.GetInstance<MachineRepository>();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var orderIdList = _orderRepository.GetAll().ToList();
            var productIdList = _productRepository.GetAll().ToList();
            var customerIdList = _customerRepository.GetAll().ToList();
            var machineIdList = _machineRepository.GetAll().ToList();
            var userIdList = _userRepository.GetWhere(u => u.IsOperator).ToList();

            dataGridView1.DataSource = orderIdList;
            dataGridView2.DataSource = userIdList;

            Random random = new Random();
            DateTime rastgeleBaslamaTarihi;
            DateTime rastgeleBitisTarihi;
            int randomOrderIndex;
            Guid randomOrderId;

            int randomProductIndex = random.Next(0, productIdList.Count);
            Guid randomProductId = productIdList[randomProductIndex].Id;

            int randomCustomerIndex = random.Next(0, customerIdList.Count);
            Guid randomCustomerId = customerIdList[randomCustomerIndex].Id;

            int randomMachineIndex = random.Next(0, machineIdList.Count);
            Guid randomMachineId = machineIdList[randomMachineIndex].Id;

            int randomUserIndex = random.Next(0, userIdList.Count);
            Guid randomUserId = userIdList[randomUserIndex].Id;

            //await _orderRepository.AddAsync(new()
            //{
            //    CreatedDate = DateTime.UtcNow,
            //    OrderCode = GenerateOrderCode(),
            //    Quantity = random.Next(30,500),
            //    DeliveryDate = DateTime.UtcNow.AddDays(random.Next(1,30)),
            //    Description = "deneme",
            //    IsReady = true,
            //    IsWaiting = false,
            //    FinishDate = DateTime.UtcNow.AddDays(random.Next(1, 10)),
            //    ProductId = randomProductId,
            //    CustomerId = randomCustomerId,  
            //    UserId = randomUserId,
            //    MachineId = randomMachineId,
            //});

            //_orderRepository.Save();

            for(int i = 0; i < 10; i++) 
            {
                rastgeleBaslamaTarihi = DateTime.UtcNow;

                int saatEkle = random.Next(1, 8);
                int dakikaEkle = random.Next(5, 55);
                rastgeleBitisTarihi = rastgeleBaslamaTarihi.AddHours(saatEkle).AddMinutes(dakikaEkle);

                randomOrderIndex = random.Next(0, orderIdList.Count);
                randomOrderId = orderIdList[randomOrderIndex].Id;

                randomUserIndex = random.Next(0, userIdList.Count);
                randomUserId = userIdList[randomUserIndex].Id;

                await _productionRepository.AddAsync(new()
                {
                    CreatedDate = rastgeleBaslamaTarihi,
                    FinishDate = rastgeleBitisTarihi,
                    Quantity = saatEkle * random.Next(20,40),
                    Wastage = saatEkle * random.Next(1, 6),
                    OrderId = randomOrderId,
                    UserId = randomUserId
                });
            }            

            _productionRepository.Save();

        }

        private string GenerateOrderCode()
        {
            int currentYear = DateTime.Now.Year;

            string lastProductCode = GetLastProductCodeFromDatabase();

            if (string.IsNullOrEmpty(lastProductCode) || !lastProductCode.StartsWith(currentYear.ToString()))
            {
                return currentYear.ToString() + "00001";
            }
            else
            {
                int lastCodeNumber = int.Parse(lastProductCode.Substring(4));
                int newCodeNumber = lastCodeNumber + 1;

                return currentYear.ToString() + newCodeNumber.ToString("D5");
            }
        }

        public string GetLastProductCodeFromDatabase()
        {
            var lastOrder = _orderRepository.GetAll()
                .OrderByDescending(o => o.CreatedDate)
                .Select(o => o.OrderCode)
                .FirstOrDefault();

            return lastOrder;
        }
    }
}
