﻿using System.ComponentModel.DataAnnotations;
using rm = Resources.WebsiteModels.Application;

namespace ApartmentWeb.Enums
{
    public enum YesSomeNo
    {
        [Display(Name = nameof(rm.ENUM_YESNO_NO), ResourceType = typeof(rm))]
        No = 1,
        [Display(Name = nameof(rm.ENUM_YESNO_YES), ResourceType = typeof(rm))]
        Yes = 2,
        [Display(Name = nameof(rm.ENUM_YESNO_SOME), ResourceType = typeof(rm))]
        Some = 3
    }
}
