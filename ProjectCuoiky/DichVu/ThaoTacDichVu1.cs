using ProjectCuoiky.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCuoiky.Services
{
    public interface ThaoTacDichVu1
    {
        void SaveUserToDB(RegisterViewModel model);
        bool IsValidUser(LogonViewModel model);
    }
}