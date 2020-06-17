#define TEST_URI

using System;
using static System.Console;

namespace AnyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #if TEST_URI
                Uri
                    baseUri = new Uri("http://base.com"),
                    relativeUri = new Uri("api/db", UriKind.Relative),
                    uri = new Uri(baseUri, relativeUri);

                WriteLine($"{baseUri} + {relativeUri} = {uri}");

                baseUri = uri;
                relativeUri = new Uri("5eea19fd24e4610001a083ef", UriKind.Relative);
                uri = new Uri(baseUri, relativeUri);
                WriteLine($"{baseUri} + {relativeUri} = {uri}");

                relativeUri = new Uri("/5eea19fd24e4610001a083ef", UriKind.Relative);
                uri = new Uri(baseUri, relativeUri);
                WriteLine($"{baseUri} + {relativeUri} = {uri}");
                
                baseUri = new Uri("http://base.com/api/db/");
                relativeUri = new Uri("5eea19fd24e4610001a083ef", UriKind.Relative);
                uri = new Uri(baseUri, relativeUri);
                WriteLine($"{baseUri} + {relativeUri} = {uri}");
            #endif
        }
    }
}
