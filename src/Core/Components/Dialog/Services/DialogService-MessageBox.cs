﻿using Microsoft.AspNetCore.Components;

namespace Microsoft.Fast.Components.FluentUI;

public partial class DialogService
{
    /// <summary>
    /// Shows a success message box. Does not have a callback function.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title to display on the dialog.</param>
    public void ShowSuccess(string message, string? title = null) => ShowMessageBox(new DialogParameters<MessageBoxContent>()
    {
        Content = new MessageBoxContent()
        {
            Title = string.IsNullOrWhiteSpace(title) ? "Success" /*DialogResources.TitleError*/ : title,
            Intent = MessageBoxIntent.Success,
            Icon = new CoreIcons.Filled.Size24.CheckmarkCircle(),
            IconColor = Color.Success,
            Message = message,
        },
        DialogType = DialogType.MessageBox,
        PrimaryAction = "OK", /*DialogResources.ButtonOK,*/
        SecondaryAction = string.Empty,
    });

    /// <summary>
    /// Shows a warning message box. Does not have a callback function.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title to display on the dialog.</param>
    public void ShowWarning(string message, string? title = null) => ShowMessageBox(new DialogParameters<MessageBoxContent>()
    {
        Content = new MessageBoxContent()
        {
            Title = string.IsNullOrWhiteSpace(title) ? "Warning" /*DialogResources.TitleError*/ : title,
            Intent = MessageBoxIntent.Warning,
            Icon = new CoreIcons.Filled.Size24.Warning(),
            IconColor = Color.Warning,
            Message = message,
        },
        DialogType = DialogType.MessageBox,
        PrimaryAction = "OK", /*DialogResources.ButtonOK,*/
        SecondaryAction = string.Empty,
    });

    /// <summary>
    /// Shows an error message box. Does not have a callback function.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title to display on the dialog.</param>
    public void ShowError(string message, string? title = null) => ShowMessageBox(new DialogParameters<MessageBoxContent>()
    {
        Content = new MessageBoxContent()
        {
            Title = string.IsNullOrWhiteSpace(title) ? "Error" /*DialogResources.TitleError*/ : title,
            Intent = MessageBoxIntent.Error,
            Icon = new CoreIcons.Filled.Size24.DismissCircle(),
            IconColor = Color.Error,
            Message = message,
        },
        DialogType = DialogType.MessageBox,
        PrimaryAction = "OK", /*DialogResources.ButtonOK,*/
        SecondaryAction = string.Empty,
    });

    /// <summary>
    /// Shows an information message box. Does not have a callback function.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title to display on the dialog.</param>
    public void ShowInfo(string message, string? title = null) => ShowMessageBox(new DialogParameters<MessageBoxContent>()
    {
        Content = new MessageBoxContent()
        {
            Title = string.IsNullOrWhiteSpace(title) ? "Information" /*DialogResources.TitleInformation*/ : title,
            Intent = MessageBoxIntent.Info,
            Icon = new CoreIcons.Filled.Size24.Info(),
            IconColor = Color.Info,
            Message = message,
        },
        DialogType = DialogType.MessageBox,
        PrimaryAction = "OK", /*DialogResources.ButtonOK,*/
        SecondaryAction = string.Empty,
    });

    /// <summary>
    /// Shows a confirmation message box. Has a callback function which returns boolean 
    /// (true=PrimaryAction clicked, false=SecondaryAction clicked).
    /// </summary>
    /// <param name="receiver">The component that receives the callback function.</param>
    /// <param name="callback">The callback function.</param>
    /// <param name="message">The message to display.</param>
    /// <param name="primaryText">The text to display on the primary button.</param>
    /// <param name="secondaryText">The text to display on the secondary button.</param>
    /// <param name="title">The title to display on the dialog.</param>
    public void ShowConfirmation(object receiver, Func<DialogResult, Task> callback, string message, string primaryText = "Yes", string secondaryText = "No", string? title = null)
        => ShowMessageBox(new DialogParameters<MessageBoxContent>()
        {
            Content = new MessageBoxContent()
            {
                Title = string.IsNullOrWhiteSpace(title) ? "Confirmation" /*DialogResources.TitleConfirmation*/ : title,
                Intent = MessageBoxIntent.Confirmation,
                Icon = new CoreIcons.Regular.Size24.QuestionCircle(),
                IconColor = Color.Success,
                Message = message,
            },
            DialogType = DialogType.MessageBox,
            PrimaryAction = primaryText, /*DialogResources.ButtonYes,*/
            SecondaryAction = secondaryText, /*DialogResources.ButtonNo,*/
            OnDialogResult = EventCallback.Factory.Create(receiver, callback)
        });

    /// <summary>
    /// Shows a custom message box. Has a callback function which returns boolean
    /// (true=PrimaryAction clicked, false=SecondaryAction clicked).
    /// </summary>
    /// <param name="parameters">Parameters to pass to component being displayed.</param>
    public void ShowMessageBox(DialogParameters<MessageBoxContent> parameters)
    {
        DialogParameters dialogParameters = new()
        {
            DialogType = DialogType.MessageBox,
            Alignment = HorizontalAlignment.Center,
            Title = parameters.Content.Title,
            Modal = string.IsNullOrEmpty(parameters.SecondaryAction),
            ShowDismiss = false,
            PrimaryAction = parameters.PrimaryAction,
            SecondaryAction = parameters.SecondaryAction,
            Width = parameters.Width,
            Height = parameters.Height,
            AriaLabel = $"{parameters.Content.Title}",
            OnDialogResult = parameters.OnDialogResult,
        };

        ShowDialog(typeof(MessageBox), parameters.Content, dialogParameters);
    }

    /// <summary>
    /// Shows a success message box. Does not have a callback function.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title to display on the dialog.</param>
    public async Task<IDialogReference> ShowSuccessAsync(string message, string? title = null)
        => await ShowMessageBoxAsync(new DialogParameters<MessageBoxContent>()
        {
            Content = new MessageBoxContent()
            {
                Title = string.IsNullOrWhiteSpace(title) ? "Success" /*DialogResources.TitleError*/ : title,
                Intent = MessageBoxIntent.Success,
                Icon = new CoreIcons.Filled.Size24.CheckmarkCircle(),
                IconColor = Color.Success,
                Message = message,
            },
            DialogType = DialogType.MessageBox,
            PrimaryAction = "OK", /*DialogResources.ButtonOK,*/
            SecondaryAction = string.Empty,
        });

    /// <summary>
    /// Shows a warning message box. Does not have a callback function.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title to display on the dialog.</param>
    public async Task<IDialogReference> ShowWarningAsync(string message, string? title = null)
        => await ShowMessageBoxAsync(new DialogParameters<MessageBoxContent>()
        {
            Content = new MessageBoxContent()
            {
                Title = string.IsNullOrWhiteSpace(title) ? "Warning" /*DialogResources.TitleError*/ : title,
                Intent = MessageBoxIntent.Warning,
                Icon = new CoreIcons.Filled.Size24.Warning(),
                IconColor = Color.Warning,
                Message = message,
            },
            DialogType = DialogType.MessageBox,
            PrimaryAction = "OK", /*DialogResources.ButtonOK,*/
            SecondaryAction = string.Empty,
        });

    /// <summary>
    /// Shows an error message box. Does not have a callback function.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title to display on the dialog.</param>
    public async Task<IDialogReference> ShowErrorAsync(string message, string? title = null)
        => await ShowMessageBoxAsync(new DialogParameters<MessageBoxContent>()
        {
            Content = new MessageBoxContent()
            {
                Title = string.IsNullOrWhiteSpace(title) ? "Error" /*DialogResources.TitleError*/ : title,
                Intent = MessageBoxIntent.Error,
                Icon = new CoreIcons.Filled.Size24.DismissCircle(),
                IconColor = Color.Error,
                Message = message,
            },
            DialogType = DialogType.MessageBox,
            PrimaryAction = "OK", /*DialogResources.ButtonOK,*/
            SecondaryAction = string.Empty,
        });

    /// <summary>
    /// Shows an information message box. Does not have a callback function.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title to display on the dialog.</param>
    public async Task<IDialogReference> ShowInfoAsync(string message, string? title = null)
        => await ShowMessageBoxAsync(new DialogParameters<MessageBoxContent>()
        {
            Content = new MessageBoxContent()
            {
                Title = string.IsNullOrWhiteSpace(title) ? "Information" /*DialogResources.TitleInformation*/ : title,
                Intent = MessageBoxIntent.Info,
                Icon = new CoreIcons.Filled.Size24.Info(),
                IconColor = Color.Info,
                Message = message,
            },
            DialogType = DialogType.MessageBox,
            PrimaryAction = "OK", /*DialogResources.ButtonOK,*/
            SecondaryAction = string.Empty,
        });

    /// <summary>
    /// Shows a confirmation message box. Has a callback function which returns boolean 
    /// (true=PrimaryAction clicked, false=SecondaryAction clicked).
    /// </summary>
    /// <param name="receiver">The component that receives the callback function.</param>
    /// <param name="callback">The callback function.</param>
    /// <param name="message">The message to display.</param>
    /// <param name="primaryText">The text to display on the primary button.</param>
    /// <param name="secondaryText">The text to display on the secondary button.</param>
    /// <param name="title">The title to display on the dialog.</param>
    public async Task<IDialogReference> ShowConfirmationAsync(object receiver, Func<DialogResult, Task> callback, string message, string primaryText = "Yes", string secondaryText = "No", string? title = null)
        => await ShowMessageBoxAsync(new DialogParameters<MessageBoxContent>()
        {
            Content = new MessageBoxContent()
            {
                Title = string.IsNullOrWhiteSpace(title) ? "Confirm" /*DialogResources.TitleConfirmation*/ : title,
                Intent = MessageBoxIntent.Confirmation,
                Icon = new CoreIcons.Regular.Size24.QuestionCircle(),
                IconColor = Color.Success,
                Message = message,
            },
            DialogType = DialogType.MessageBox,
            PrimaryAction = primaryText, /*DialogResources.ButtonYes,*/
            SecondaryAction = secondaryText, /*DialogResources.ButtonNo,*/
            OnDialogResult = EventCallback.Factory.Create(receiver, callback)
        });

    /// <summary>
    /// Shows a confirmation message box. Has no callback function
    /// (true=PrimaryAction clicked, false=SecondaryAction clicked).
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="primaryText">The text to display on the primary button.</param>
    /// <param name="secondaryText">The text to display on the secondary button.</param>
    /// <param name="title">The title to display on the dialog.</param>
    public async Task<IDialogReference> ShowConfirmationAsync(string message, string primaryText = "Yes", string secondaryText = "No", string? title = null)
        => await ShowMessageBoxAsync(new DialogParameters<MessageBoxContent>()
        {
            Content = new MessageBoxContent()
            {
                Title = string.IsNullOrWhiteSpace(title) ? "Confirm" /*DialogResources.TitleConfirmation*/ : title,
                Intent = MessageBoxIntent.Confirmation,
                Icon = new CoreIcons.Regular.Size24.QuestionCircle(),
                IconColor = Color.Success,
                Message = message,
            },
            DialogType = DialogType.MessageBox,
            PrimaryAction = primaryText, /*DialogResources.ButtonYes,*/
            SecondaryAction = secondaryText, /*DialogResources.ButtonNo,*/
        });

    /// <summary>
    /// Shows a custom message box. Has a callback function which returns boolean
    /// (true=PrimaryAction clicked, false=SecondaryAction clicked).
    /// </summary>
    /// <param name="parameters">Parameters to pass to component being displayed.</param>
    public async Task<IDialogReference> ShowMessageBoxAsync(DialogParameters<MessageBoxContent> parameters)
    {
        DialogParameters dialogParameters = new()
        {
            DialogType = DialogType.MessageBox,
            Alignment = HorizontalAlignment.Center,
            Title = parameters.Content.Title,
            Modal = string.IsNullOrEmpty(parameters.SecondaryAction),
            ShowDismiss = false,
            PrimaryAction = parameters.PrimaryAction,
            SecondaryAction = parameters.SecondaryAction,
            Width = parameters.Width,
            Height = parameters.Height,
            AriaLabel = $"{parameters.Content.Title}",
            OnDialogResult = parameters.OnDialogResult,
        };

        return await ShowDialogAsync(typeof(MessageBox), parameters.Content, dialogParameters);
    }

}
