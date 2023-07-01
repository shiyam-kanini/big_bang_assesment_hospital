﻿using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.ProfileDto;

namespace Hospital_Management_API.Models_Response_.ProfileResponses
{
    public class EmployeeProfileResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public EmployeeProfileGetDTO? EmployeeProfile { get; set; }
        public EmployeeProfileUpdateDTO? EmployeeProfileUpdate { get; set; }
    }
}
