﻿using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe
{
    public enum State
    { 
        NZ,
        US,
        EURO
    }
    public interface IRate
    {
        double Rate();
    }
    public class InNZDollars : IRate
    {
        public double Rate() => 1.00;
    }
    public class InUSDollars : IRate
    {
       public double Rate() => 0.76;
    }
    public class InEuros : IRate
    {        
        public double Rate() => 0.67;
    }
    public class ProductDataConsolidator
    {
        public IDictionary<State, IRate> MappingDollars { get; set; }
        public ProductDataConsolidator()
        {
            MappingDollars = new Dictionary<State, IRate>
                     { { State.NZ, new InNZDollars() }, { State.US, new InUSDollars() }, { State.EURO, new InEuros() } };
        }
        public double GetRate(State shipToState)
        {
            return MappingDollars[shipToState].Rate();
        }
        public IQueryable<Lawnmower> GetLawnmower()
        {
            return new LawnmowerRepository().GetAll();
        }
        public IQueryable<PhoneCase> GetPhoneCase()
        {
            return new PhoneCaseRepository().GetAll();
        }
        public IQueryable<TShirt> GetTShirt()
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
