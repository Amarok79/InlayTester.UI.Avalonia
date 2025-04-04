﻿// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using CommunityToolkit.Mvvm.ComponentModel;
using InlayTester.Domain;


namespace InlayTester.UI.Pages.Home.Home;


partial class HomeViewModel
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RunTestCommand))]
    [NotifyCanExecuteChangedFor(nameof(ManageSubstratesCommand))]
    [NotifyCanExecuteChangedFor(nameof(ManageChipsCommand))]
    [NotifyCanExecuteChangedFor(nameof(ManageDistancesCommand))]
    [NotifyCanExecuteChangedFor(nameof(ManageDriveWheelCommand))]
    [NotifyCanExecuteChangedFor(nameof(AdministerUsersCommand))]
    [NotifyCanExecuteChangedFor(nameof(AdministerSettingsCommand))]
    public partial User? CurrentUser { get; set; }
}
