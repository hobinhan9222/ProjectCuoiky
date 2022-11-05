using ProjectCuoiky.Models;
using ProjectCuoiky.Services;
using ProjectCuoiky.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCuoiky.DichVu
{
    public class ThaoTacDichVu: ThaoTacDichVu1

    {
        private FriendsForeverEntities1 _context = null;
        public ThaoTacDichVu()
        {
            _context = new FriendsForeverEntities1();
        }
        public void SaveUserToDB(RegisterViewModel model)
        {
            UserDetails userDetails = new UserDetails();
            userDetails.Email = model.Email;
            userDetails.FristName = model.FristName;
            userDetails.LastName = model.LastName;
            userDetails.Password = model.Password;

            _context.UserDetails.Add(userDetails);
            _context.SaveChanges();
        }

        public bool IsValidUser(LogonViewModel model)
        {
            UserDetails user = null;
            user = _context.UserDetails.SingleOrDefault(c => c.Email.Equals(model.Username) && c.Password.Equals(model.Password));
            if (user == null)
            {
                return false;
            }
            else
                return true;
        }
    }
}