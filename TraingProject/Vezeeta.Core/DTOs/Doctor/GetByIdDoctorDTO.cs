﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Core.Dtos
{
    public class GetByIdDoctorDTO : GetAllDoctorDTO
    {
        public string DateOfBirth { get; set; }

    }
}
