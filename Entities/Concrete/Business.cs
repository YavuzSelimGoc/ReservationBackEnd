using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class Business:IEntity
	{
		public int BusinessId { get; set; }
		public int CategoryId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessAdress { get; set; }
        public string BusinessImage { get; set; }
        public decimal BusinessMinPrice { get; set; }
		public decimal BusinessMaxPrice { get; set; }
		public string BusinessShortDescription { get; set; }
		public string BusinessDescription { get; set; }
		public bool BusinessStatus { get; set; }

	}
}

