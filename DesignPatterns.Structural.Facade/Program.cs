namespace DesignPatterns.Structural.Facade;

class Program
{
    static void Main(string[] args)
    {
        var playerFacade = new PlayerFacade();

        playerFacade.Play("kaan.mp3");
        playerFacade.Play("kaan.mp4");

        Console.ReadKey();
    }

    interface IPlayer
    {
        void Play(string name);
    }

    class AudioPlayer : IPlayer
    {
        public void Play(string name)
        {
            Console.WriteLine($"Audio player working => {name}");
        }
    }

    class VideoPlayer : IPlayer
    {
        public void Play(string name)
        {
            Console.WriteLine($"Video player working => {name}");
        }
    }

    class PlayerFacade : IPlayer
    {
        AudioPlayer _audioPlayer;
        VideoPlayer _videPlayer;

        public PlayerFacade()
        {
            _audioPlayer = new AudioPlayer();
            _videPlayer = new VideoPlayer();
        }

        public void Play(string name)
        {
            if (name.EndsWith(".mp3"))
                _audioPlayer.Play(name);

            if (name.EndsWith(".mp4"))
                _videPlayer.Play(name);
        }
    }
}
