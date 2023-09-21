﻿using CookLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Service.Favorites
{
    public interface IFavoriteService
    {
        Favorite Create(Favorite favorite);
        Favorite Retrieve(int id);
        List<Favorite> RetrieveAll();
        Favorite Update(Favorite favorite);
        void Delete(int id);
    }
}
