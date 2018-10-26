using Projeto_NFe.Application.Features.Products.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.SoldProducts.ViewModels
{
    public class SoldProductViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double UnitaryValue { get; set; }
    }
}
