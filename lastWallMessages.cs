/**
 * A program that reads five last posts from Alex Lisovoy's wall and puts them
 * in five files.
 */
using System;
using System.Net;
using Newtonsoft.Json;

public class LastWallMessages
{
    public static void Main(String[] args)
    {
        String domain = "kaneua"; // short address of a user
        int messageCount = 5; // amount of messages to read
        String requestString = String.Format(
                    "https://api.vk.com/method/wall.get?domain={0}&count={1}",
                    domain,
                    messageCount);
        using (WebClient wc = new WebClient())
        {
            String json = wc.DownloadString(requestString);
            var responseDefinition = new { response = new { count = 0 } };
            var result = JsonConvert.DeserializeAnonymousType(json, responseDefinition);
            Console.WriteLine(result.response.count);
        }
    }
}
