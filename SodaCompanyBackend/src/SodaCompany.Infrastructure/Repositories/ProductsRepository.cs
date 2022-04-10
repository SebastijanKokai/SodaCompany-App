using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories;
using SodaCompany.Infrastructure.Data;
using SodaCompany.Infrastructure.Repositories.Base;

namespace SodaCompany.Infrastructure.Repositories
{
    public class ProductsRepository : Repository<Product>, IProductsRepository
    {
        public ProductsRepository(SodaCompanyContext sodaCompanyContext) : base(sodaCompanyContext)
        {
        }
    }
}
