﻿using HealthCatalystPeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCatalystPeopleSearch.Services
{
    public interface IPeopleManager
    {
        Persons GetAllPeople();
    }
}