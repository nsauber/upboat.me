﻿using GoogleAnalyticsTracker;
using System;
using System.Configuration;
using System.Web;

namespace UpboatMe.Utilities
{
    public class Analytics
    {
        public static void TrackMeme(HttpContextBase context, string meme)
        {
            if (string.Equals(ConfigurationManager.AppSettings["EnableGoogleAnalytics"], "true", StringComparison.OrdinalIgnoreCase)
                && !IsFromUpboatMe(context.Request.UrlReferrer))
            {

                using (var tracker = new Tracker("UA-41725429-1", "upboat.me"))
                {
                    tracker.TrackPageView(context, "Generate Meme", context.Request.RawUrl);
                }
            }
        }

        private static bool IsFromUpboatMe(Uri uri)
        {
            if (uri == null)
            {
                return false;
            }

            return string.Equals(uri.Host, "upboat.me", StringComparison.OrdinalIgnoreCase);
        }
    }
}