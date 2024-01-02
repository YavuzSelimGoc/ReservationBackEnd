using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class Reservation:IEntity
	{
		public int ReservationId  { get; set; }
		public string BusinessUserName { get; set; }
		public string Hour { get; set; }
        public string CustomerUserName { get; set; }
		public string ReservationDescription { get; set; }
		public bool isAccept { get; set; }
		public bool ReservationStatus { get; set; }
    }
}

