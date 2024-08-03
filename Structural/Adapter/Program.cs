
IMediaPlayer player = new AudioPlayer();

player.Play("song.mp3");
player.Play("video.vlc");

Console.ReadKey();

interface IMediaPlayer
{
    void Play(string fileName);
}

interface IVLCPlayer
{
    void PlayVLC(string fileName);
}

class VLCPlayer : IVLCPlayer
{
    public void PlayVLC(string fileName)
    {
        Console.WriteLine("Playing VLC file => " + fileName);
    }
}

class MediaPlayerAdapter : IMediaPlayer
{
    private readonly IVLCPlayer _vlcPlayer;

    public MediaPlayerAdapter(IVLCPlayer vlcPlayer)
    {
        _vlcPlayer = vlcPlayer;
    }

    public void Play(string fileName)
    {
        _vlcPlayer.PlayVLC(fileName);
    }
}

class AudioPlayer : IMediaPlayer
{
    private IMediaPlayer _mediaAdapter;

    public void Play(string fileName)
    {
        if (fileName.EndsWith(".vlc"))
        {
            _mediaAdapter = new MediaPlayerAdapter(new VLCPlayer());
            _mediaAdapter.Play(fileName);
        }
        else
        {
            Console.WriteLine("Playing file: " + fileName);
        }
    }
}