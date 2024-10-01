// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;


namespace Amarok.Fabric.Avalonia;


public class DummyView : UserControl
{
}

[View<DummyView>]
public class DummyViewModel : ObservableObject
{
}
