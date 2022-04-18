using CodeHollow.FeedReader;

static class Program
{
    /// <summary>
    /// メインメソッド
    /// </summary>
    static void Main()
    {
        string url = @"https://kyoko-np.net/index.xml";
        var feedTask = FeedReader.ReadAsync(url);
        var feed = feedTask.Result;

        // ヘッダー情報
        Console.WriteLine("Feed Title: " + feed.Title);
        Console.WriteLine("Feed Description: " + feed.Description);
        Console.WriteLine("Feed Images: " + feed.ImageUrl);

        // 明細情報
        foreach (var item in feed.Items)
        {
            Console.WriteLine(item.Title + " - " + item.Link);
        }
    }
}