using System;
using Core.Entities;

namespace Entities.DTOs
{
	public class ReservationDto:IDto
	{
        public int ReservationId { get; set; }
        public string BusinessUserName { get; set; }
        public string BusinessName { get; set; }
        public string CustomerUserName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerDescription { get; set; }
        public string ReservationDescription { get; set; }
        public bool isAccept { get; set; }
        public bool ReservationStatus { get; set; }
    }
}

