﻿using ApartmentWeb.Enums;
using ApartmentWeb.Validation;
using System.ComponentModel.DataAnnotations;
using rm = Resources.WebsiteModels.Application;
using vrm = Resources.WebsiteModels.ApplicationValidation;

namespace ApartmentWeb.Models.Application
{
    public class Automobile
    {
        public string DisplayName { get; set; }

        public bool AllowElectiveRequire { get; set; }

        [Display(Name = nameof(rm.APP_HAS_AUTO), ResourceType = typeof(rm))]
        [Range(1, 2, ErrorMessageResourceName = nameof(vrm.APP_HAS_AUTO), ErrorMessageResourceType = typeof(vrm))]
        public YesNo ElectiveRequireValue { get; set; }

        [Display(Name = nameof(rm.AUTO_MAKE), ResourceType = typeof(rm))]
        [RequireIfEnum(nameof(ElectiveRequireValue), YesNo.Yes, nameof(vrm.AUTO_MAKE), typeof(vrm))]
        public string Make { get; set; }

        [Display(Name = nameof(rm.AUTO_MODEL), ResourceType = typeof(rm))]
        [RequireIfEnum(nameof(ElectiveRequireValue), YesNo.Yes, nameof(vrm.AUTO_MODEL), typeof(vrm))]
        public string Model { get; set; }

        [Display(Name = nameof(rm.AUTO_YEAR), ResourceType = typeof(rm))]
        [RequireIfEnum(nameof(ElectiveRequireValue), YesNo.Yes, nameof(vrm.AUTO_YEAR), typeof(vrm))]
        public string Year { get; set; }

        [Display(Name = nameof(rm.AUTO_STATE), ResourceType = typeof(rm))]
        [RequireIfEnum(nameof(ElectiveRequireValue), YesNo.Yes, nameof(vrm.AUTO_STATE), typeof(vrm))]
        public string State { get; set; }

        [Display(Name = nameof(rm.AUTO_LICENSE_NUM), ResourceType = typeof(rm))]
        [RequireIfEnum(nameof(ElectiveRequireValue), YesNo.Yes, nameof(vrm.AUTO_LICENSE_NUM), typeof(vrm))]
        public string LicenseNum { get; set; }

        [Display(Name = nameof(rm.AUTO_COLOR), ResourceType = typeof(rm))]
        [RequireIfEnum(nameof(ElectiveRequireValue), YesNo.Yes, nameof(vrm.AUTO_COLOR), typeof(vrm))]
        public string Color { get; set; }

    }
}
