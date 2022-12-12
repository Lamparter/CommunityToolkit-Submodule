// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CommunityToolkit.Labs.Core.SourceGenerators.Attributes;

namespace CommunityToolkit.Labs.Core.SourceGenerators.Metadata;

/// <summary>
/// An INPC-enabled metadata container for data defined in an <see cref="ToolkitSampleSliderOptionAttribute"/>.
/// </summary>
public class ToolkitSampleSliderOptionMetadataViewModel : IGeneratedToolkitSampleOptionViewModel
{
    private string? _title;
    private object? _value;

    /// <summary>
    /// Creates a new instance of <see cref="ToolkitSampleSliderOptionMetadataViewModel"/>.
    /// </summary>
    public ToolkitSampleSliderOptionMetadataViewModel(string name, double initial = 0, double min = 0, double max = 10, double step = 1, string? title = null)
    {
        Name = name;
        _title = title;
        _value = initial;
        Max = max;
        Min = min;
        Step = step;;
    }

    /// <inheritdoc cref="INotifyPropertyChanged.PropertyChanged"/>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// A unique identifier for this option.
    /// </summary>
    /// <remarks>
    /// Used by the sample system to match up <see cref="ToolkitSampleSliderOptionMetadataViewModel"/> to the original <see cref="ToolkitSampleSliderOptionAttribute"/> and the control that declared it.
    /// </remarks>
    public string Name { get; }

    /// <summary>
    /// The available options presented to the user.
    /// </summary>
    /// <summary>
    /// The initial double value.
    /// </summary>
    public double Initial
    {
        get => (double)_value;
        set
        {
            _value = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }
    }

    /// <inheritdoc/>
    public object? Value
    {
        get => Initial;
        set
        {
            Initial = (double)(value ?? 0.0);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }
    }

    /// <summary>
    /// The Minimum value of the slider.
    /// </summary>
    public double Min { get; }

    /// <summary>
    /// The Maximum value of the slider.
    /// </summary>
    public double Max { get; }

    /// <summary>
    /// The StepFrequency value of the slider.
    /// </summary>
    public double Step { get; }

    /// <summary>
    /// A label to display along the slider.
    /// </summary>
    public string? Title
    {
        get => _title;
        set
        {
            _title = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
        }
    }
}
