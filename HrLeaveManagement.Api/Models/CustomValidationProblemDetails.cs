﻿using Microsoft.AspNetCore.Mvc;

namespace HrLeaveManagement.Api.Models;

public class CustomValidationProblemDetails : ProblemDetails
{
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}