using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.Products;

namespace Projeto_NFe.Domain.Features.SoldProducts
{
    public class SoldProduct
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Amount => GetAmount();
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        private double GetAmount()
        {
            return Quantity * Product.UnitaryValue;
        }

        public void CalculateTax()
        {
            Product.Tax.CalculateIpi(Amount);
            Product.Tax.CalculateIcms(Amount);
        }
    }
}
