﻿using System.Text.RegularExpressions;
using AngleSharp.Diffing.Core;
using AngleSharp.Dom;

namespace Microsoft.Fast.Components.FluentUI.Tests;

public class FluentAssertOptions
{
    /// <summary>
    /// Gets or sets default file extension used to identify an expected JSON file.
    /// </summary>
    public string VerifiedExtension { get; set; } = ".verified.html";

    /// <summary>
    /// Gets or sets default file extension used to save a Card generated JSON file.
    /// </summary>
    public string ReceivedExtension { get; set; } = ".received.html";

    /// <summary>
    /// Scrub lines with an optional replace.
    /// Can return the input to ignore the line, or return a a different string to replace it.
    /// </summary>
    public string ScrubLinesWithReplace(string content)
    {
        return content.ReplaceAttribute("id", "xxx")
                      .ReplaceAttribute("blazor:elementreference", "xxx")
                      .ReplaceAttribute("anchor", "xxx");
    }

    /// <summary>
    /// Check if the <paramref name="item"/> must be excluded from comparison errors.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool IsExcluded(IDiff item)
    {
        // Exclude Id attribute
        switch (item)
        {
            case AttrDiff attrDiff:
                return (attrDiff.Control.Attribute as Attr)?.IsId == true;

            case UnexpectedAttrDiff unexpectedAttrDiff:
                return (unexpectedAttrDiff.Test.Attribute as Attr)?.IsId == true;
        }

        return false;
    }
}