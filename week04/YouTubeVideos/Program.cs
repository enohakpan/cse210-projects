using System;

class Program
{
    static void Main(string[] args)
    {
        Videos firstVideo = new Videos("Life", "Enoh Akpan", 100);
        Videos secondVideo = new Videos("Anger", "Enoh Akpan", 1000);
        Videos thirdVideo = new Videos("The fear of God", "Enoh Akpan", 2500);
        Videos forthVideo = new Videos("The love of God", "Enoh Akpan", 1200);
        Videos fifthVideo = new Videos("Jesus the Savior", "Enoh Akpan", 3600);

        firstVideo.AddComments(new Comments("Lionel", "These basics are worth telling. Thank you so much..."));
        firstVideo.AddComments(new Comments("Christabel", "I love this..."));
        firstVideo.AddComments(new Comments("Stanley", "Thank you for this..."));
        firstVideo.AddComments(new Comments("Smith", "Very rich content"));

        secondVideo.AddComments(new Comments("Lionel", "These basics are worth telling. Thank you so much..."));
        secondVideo.AddComments(new Comments("Christabel", "I love this..."));
        secondVideo.AddComments(new Comments("Stanley", "Thank you for this..."));
        secondVideo.AddComments(new Comments("Smith", "Very rich content"));

        thirdVideo.AddComments(new Comments("Lionel", "These basics are worth telling. Thank you so much..."));
        thirdVideo.AddComments(new Comments("Christabel", "I love this..."));
        thirdVideo.AddComments(new Comments("Stanley", "Thank you for this..."));
        thirdVideo.AddComments(new Comments("Smith", "Very rich content"));

        forthVideo.AddComments(new Comments("Lionel", "These basics are worth telling. Thank you so much..."));
        forthVideo.AddComments(new Comments("Christabel", "I love this..."));
        forthVideo.AddComments(new Comments("Stanley", "Thank you for this..."));
        forthVideo.AddComments(new Comments("Smith", "Very rich content"));

        fifthVideo.AddComments(new Comments("Lionel", "These basics are worth telling. Thank you so much..."));
        fifthVideo.AddComments(new Comments("Christabel", "I love this..."));
        fifthVideo.AddComments(new Comments("Stanley", "Thank you for this..."));
        fifthVideo.AddComments(new Comments("Smith", "Very rich content"));

        List<Videos> videos = new List<Videos> {firstVideo, secondVideo, thirdVideo, forthVideo, fifthVideo};

        foreach (var video in videos)
        {
            video.DisplayVideo();
        }
    }
}