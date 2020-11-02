using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Utils
{
    public class ResultsUrlShortener
    {
        private readonly Dictionary<Uri, Uri> _shortenedUrls = new Dictionary<Uri, Uri>();

        public Uri ShortenUrl(Uri uri)
        {
            if (_shortenedUrls.ContainsValue(uri)) return uri;

            if (_shortenedUrls.ContainsKey(uri) && _shortenedUrls.TryGetValue(uri, out var shortenedUri))
            {
                return shortenedUri;
            }

            using var httpClient = new HttpClient();
            var shortenedUrlTask =
                httpClient.GetStringAsync(
                    $"https://is.gd/create.php?format=simple&url={WebUtility.UrlEncode(uri.ToString())}");

            shortenedUrlTask.Wait(1000);

            var shortenedUrl = new Uri(shortenedUrlTask.Result);
            try
            {
                _shortenedUrls.Add(uri, shortenedUrl);
            }
            catch (ArgumentException e)
            {
                // ignore
            }

            return shortenedUrl;
        }
    }
}