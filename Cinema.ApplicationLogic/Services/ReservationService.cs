using Cinema.ApplicationLogic.Abstractions;
using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.ApplicationLogic.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public Reservation GetById(Guid id)
        {
            return reservationRepository.GetById(id);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return reservationRepository.GetAll();
        }

        public IEnumerable<Reservation> GetAllForEndUser(Guid customerId)
        {
            return reservationRepository.GetAll()
                                        .Where(reservation => reservation.Customer.Id == customerId);
        }

        public void Cancel(Guid id)
        {
            reservationRepository.Remove(id);
        }
    }
}
