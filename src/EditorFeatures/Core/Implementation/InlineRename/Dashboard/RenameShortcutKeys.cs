﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.CodeAnalysis.Editor.Implementation.InlineRename
{
    internal class RenameShortcutKey
    {
        public static string RenameOverloads { get; private set; }
        public static string SearchInStrings { get; private set; }
        public static string SearchInComments { get; private set; }
        public static string PreviewChanges { get; private set; }
        public static string Apply { get; private set; }

        static RenameShortcutKey()
        {
            RenameOverloads = ExtractAccessKey(EditorFeaturesResources.RenameOverloads, "O");
            SearchInStrings = ExtractAccessKey(EditorFeaturesResources.SearchInStrings, "S");
            SearchInComments = ExtractAccessKey(EditorFeaturesResources.SearchInComments, "C");
            PreviewChanges = ExtractAccessKey(EditorFeaturesResources.RenamePreviewChanges, "P");
            Apply = ExtractAccessKey(EditorFeaturesResources.ApplyRename, "A");
        }

        /// <summary>
        /// Given a localized label, searches for _ and extracts the accelerator key. If none found,
        /// returns defaultValue.
        /// </summary>
        private static string ExtractAccessKey(string localizedLabel, string defaultValue)
        {
            int underscoreIndex = localizedLabel.IndexOf('_');

            if (underscoreIndex >= 0 && underscoreIndex < localizedLabel.Length - 1)
            {
                return new string(new char[] { char.ToUpperInvariant(localizedLabel[underscoreIndex + 1]) });
            }

            Debug.Fail("Could not locate accelerator for " + localizedLabel + " for the rename dashboard");
            return defaultValue;
        }
    }
}
