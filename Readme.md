## Sacred 2 Lobby Emulator

*Disclaimer: I am not the author of the codebase, this repository is just ment to be used to work together on code written and supplied by darkmatters board user cocomed which you can find [here](http://darkmatters.org/forums/index.php?/topic/23833-network-traffic-probes-for-sacred-2-available/&do=findComment&comment=7015188).*

In it's current state, this solution allows to host a basic Open Net Sacred2 Lobby.

### Usage

In optionsDefault.txt:

network = {  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lobby_ip = "localhost",  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lobby_port = 6800  
}

In the directory of the executable write the public IP of the lobby server into ip.cfg file.

1. run game
2. go multi player
3. create account
4. log in
5. make nickname
6. make charactor
7. enter lobby
8. run server, example in starts2gs.cmd file
9. refresh server list in lobby
10. join game
11. play

The server hosting needs an account, but may use the same credentials like the player accounts.
