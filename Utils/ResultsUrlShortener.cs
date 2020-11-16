using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Utils
{
    // TODO: Can this class be made static?
    public class ResultsUrlShortener
    {
        // TODO: can it happen that ShortenUrl will be called multiple times concurrently? If so, should this be ConcurrentDictionary?
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
            catch (ArgumentException)
            {
                // TODO-someday: In the future log this error somewhere
                // ignore
            }

            return shortenedUrl;
        }
    }
}