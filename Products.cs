using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public abstract class Products
    {
        public string Name { get; set; }
        public int Price { get; set; }


        
        
        public  virtual void MachineInfo() { }



        public virtual void ProductS() { }


        public virtual void Purchase(string n) { }


        public virtual void ProductPriceInfo(string name, int num) { }


        public virtual void ProdcutUserGuide(string name) { }




    }
}
