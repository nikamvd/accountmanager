﻿using System;
using System.Threading.Tasks;

namespace AccountManagement.Services.Dialog
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);
    }
}

