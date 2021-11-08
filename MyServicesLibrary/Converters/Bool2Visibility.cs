﻿#nullable enable
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using MyServicesLibrary.Converters.Base;

namespace MyServicesLibrary.Converters;

[ValueConversion(typeof(bool?), typeof(Visibility))]
[MarkupExtensionReturnType(typeof(Bool2Visibility))]
public class Bool2Visibility : Converter
{
    public bool Inverted { get; set; }

    public bool Collapsed { get; set; }

    protected override object? Convert(object? v, Type? t, object? p, CultureInfo? c) =>
        v switch
        {
            null => null,
            Visibility => v,
            true => !Inverted ? Visibility.Visible : Collapsed ? Visibility.Collapsed : Visibility.Collapsed,
            false => Inverted ? Visibility.Visible : Collapsed ? Visibility.Collapsed : Visibility.Collapsed,
            _ => throw new NotSupportedException()
        };

    protected override object? ConvertBack(object? v, Type? t, object? p, CultureInfo? c) =>
        v switch
        {
            null => null,
            bool => v,
            Visibility.Visible => !Inverted,
            Visibility.Hidden => Inverted,
            Visibility.Collapsed => Inverted,
            _ => throw new NotSupportedException()
        };
}
