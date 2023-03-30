
    //// metodos de reproduccion de videos 
    function reproducir(id) {
        player.loadVideoById({
            videoId: id
        });
    }
function YTPlay() {
    player.playVideo();
}
function YTPause() {
    player.pauseVideo();
}
function YTMute() {
    if (player.isMuted()) {
        player.unMute()
    } else
    {
        player.mute();
    }
        
}
   
   
// 2. This code loads the IFrame Player API code asynchronously.
var tag = document.createElement('script');

tag.src = "https://www.youtube.com/iframe_api";
var firstScriptTag = document.getElementsByTagName('script')[0];
firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

// 3. This function creates an <iframe> (and YouTube player)
//    after the API code downloads.
   
function onYouTubeIframeAPIReady() {
    player = new YT.Player('player', {
        height: '360',
        width: '640',
        videoId: videoReproduccion,
        modestbranding:0,
        playerVars: { 'autoplay': 0, 'controls': 0,'rel':0,'showinfo':0,'modestbranding':1, 'iv_load_policy':3,'disablekb':1},
        events: {
            'onReady': onPlayerReady,
            'onStateChange': onPlayerStateChange
        }
    });
        
}

// 4. The API will call this function when the video player is ready.
function onPlayerReady(event) {
    if (videoReproduccion!='') {

    }
    event.target.playVideo();
}

// 5. The API calls this function when the player's state changes.
//    The function indicates that when playing a video (state=1),
//    the player should play for six seconds and then stop.
var done = false;
function onPlayerStateChange(event) {
    /*
    if (event.data == YT.PlayerState.PLAYING && !done) {
        setTimeout(stopVideo, 6000);
        done = true;
    }*/
}
function stopVideo() {
    player.stopVideo();
}

   
