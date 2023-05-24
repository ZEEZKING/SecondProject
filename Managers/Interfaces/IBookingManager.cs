using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Models.Entities;
using NewProject.Models.Enums;

namespace NewProject.Managers.Interfaces
{
    public interface IBookingManager
    {
        Booking CreateBooking(string roomName,int duration);
        Booking CheckIn(string referenceNo);
        Booking CheckOut(string referenceNo);
        Booking Get(string roomNumber);
        Booking Getby(string referenceNo);
       
        List<Booking> GetAll();
    }
}