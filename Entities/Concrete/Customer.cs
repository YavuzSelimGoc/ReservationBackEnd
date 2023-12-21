using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class Customer:IEntity
	{
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string UserName { get; set; }
        public string CustomerPhoneNumber { get; set; }
		public string CustomerAdress { get; set; }
		public string CustomerDescription { get; set; }
		public string CustomerImage { get; set; }
		public bool CustomerStatus { get; set; }
    }
}

