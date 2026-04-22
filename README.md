# Create a Custom TimePicker in WPF

This sample demonstrates how to create a **custom TimePicker control in WPF** using a `UserControl`. It shows how to design a lightweight time selection UI that supports keyboard navigation, increment and decrement buttons, and input validation for hours and minutes.

## Overview
WPF does not include a built‑in TimePicker control with extensive keyboard and selection behavior. This example illustrates how to build a custom TimePicker by combining text input with arrow buttons and handling user interaction manually.

The custom control enables users to select hours and minutes independently, restricts invalid input, and provides a smooth editing experience similar to a conventional time picker.

## What This Sample Demonstrates
- How to create a custom TimePicker using a UserControl
- How to manage hour and minute selection independently
- How to handle keyboard navigation and input validation
- How to increment and decrement time values using arrow buttons
- How to restrict invalid time input programmatically

## Key Components Used
- **UserControl**: Hosts the custom TimePicker implementation
- **SfTextBoxExt**: Allows formatted and controlled time input
- **Buttons**: Provide up and down arrow controls for time adjustment
- **Keyboard events**: Handle navigation and validation logic
- **Selection logic**: Ensures intuitive editing of hours and minutes

## How It Works
1. The custom TimePicker initializes the time in `HH:mm` format.
2. Text selection logic ensures only hour or minute portions are editable at a time.
3. Arrow buttons increment or decrement the selected value.
4. Keyboard input is validated to prevent invalid hour or minute values.
5. The control dynamically updates the displayed time based on user interaction.

## Benefits
- Provides a customizable TimePicker solution for WPF applications
- Supports keyboard‑friendly time editing
- Prevents invalid time input without additional controls
- Easy to integrate into existing applications
- Suitable for scenarios requiring precise time selection

This approach is ideal for WPF applications that require a flexible and lightweight TimePicker without relying on third‑party time selection controls.
