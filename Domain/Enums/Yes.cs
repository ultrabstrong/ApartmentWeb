﻿using System.ComponentModel.DataAnnotations;
using rm = Resources.BusinessLayer.Application;

namespace Domain.Enums
{
    public enum Yes
    {
        [Display(Name = nameof(rm.ENUM_YESNO_YES), ResourceType = typeof(rm))]
        Yes = 1
    }
}