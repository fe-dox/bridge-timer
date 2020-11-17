using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http;

namespace Utils
{
    public static class ResultsUrlShortener
    {
        private static readonly ConcurrentDictionary<Uri, Uri> ShortenedUrls = new ConcurrentDictionary<Uri, Uri>();

        public static Uri ShortenUrl(Uri uri)
        {
            if (ShortenedUrls.ContainsKey(uri) && ShortenedUrls.TryGetValue(uri, out var shortenedUri))
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
                ShortenedUrls.TryAdd(uri, shortenedUrl);
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