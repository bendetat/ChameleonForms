﻿using ChameleonForms.Enums;

namespace ChameleonForms.Templates.TwitterBootstrap3
{
    /// <summary>
    /// Twitter Bootstrap alert/emphasis colors: http://getbootstrap.com/css/#type-emphasis
    /// </summary>
    public enum EmphasisStyle
    {
        /// <summary>
        /// Default styling.
        /// </summary>
        Default,
        /// <summary>
        /// Primary action styling.
        /// </summary>
        Primary,
        /// <summary>
        /// Success styling.
        /// </summary>
        Success,
        /// <summary>
        /// Information styling.
        /// </summary>
        Info,
        /// <summary>
        /// Warning styling.
        /// </summary>
        Warning,
        /// <summary>
        /// Danger styling.
        /// </summary>
        Danger
    }

    internal static class TwitterAlertTypeConversion
    {
        internal static EmphasisStyle ToTwitterAlertType(this MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Action: return EmphasisStyle.Primary;
                case MessageType.Success: return EmphasisStyle.Success;
                case MessageType.Failure: return EmphasisStyle.Danger;
                case MessageType.Information: return EmphasisStyle.Info;
                case MessageType.Warning: return EmphasisStyle.Warning;
                default: return EmphasisStyle.Default;
            }
        }
    }
}