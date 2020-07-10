namespace MessagesApplicationLogic.Models
{
    public class Message
    {
        public string Text { get; set; }

        // I've done it this way because I'd expect the image to be served from a content service (cdn, blob storage, s3, etc)
        // In this solution it's comming from wwwroot but you get the idea
        public string ImageUri { get; set; }
    }
}
