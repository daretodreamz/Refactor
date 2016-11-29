using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactorMe
{
    public class ProductDataConsolidator
    {
        private IDictionary<State, IRate> MappingDollars { get; set; }
        public ProductDataConsolidator()
        {
            MappingDollars = new Dictionary<State, IRate>
                     { { State.NZ, new InNZDollars() }, { State.US, new InUSDollars() }, { State.EURO, new InEuros() } };
        }
        private double GetRate(State shipToState)
        {
            return MappingDollars[shipToState].Rate();
        }
        private IQueryable<Lawnmower> GetLawnmower()
        {
            return new LawnmowerRepository().GetAll();
        }
        private IQueryable<PhoneCase> GetPhoneCase()
        {
            return new PhoneCaseRepository().GetAll();
        }
        private IQueryable<TShirt> GetTShirt()
        {
            return new TShirtRepository().GetAll();
        }
        public List<Product> Get(State shipToState)
        {
            var ps = from item in GetLawnmower() select new Product { Id = item.Id, Name = item.Name, Price = item.Price * GetRate(shipToState), Type = "Lawnmower" };
            ps = ps.Concat(from item in GetPhoneCase() select new Product { Id = item.Id, Name = item.Name, Price = item.Price * GetRate(shipToState), Type = "Phone Case" });
            ps = ps.Concat(from item in GetTShirt() select new Product { Id = item.Id, Name = item.Name, Price = item.Price * GetRate(shipToState), Type = "T-Shirt" });
            return ps.ToList();
        }        
    }
}
