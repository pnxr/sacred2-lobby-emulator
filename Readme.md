# Sacred 2 Lobby Emulator

> **Disclaimer:** I am not the author of this codebase. This repository is meant to facilitate collaboration on code originally written and shared by cocomed (a user on the DarkMatters forum). You can find the original post [here](http://darkmatters.org/forums/index.php?/topic/23833-network-traffic-probes-for-sacred-2-available/&do=findComment&comment=7015188).

A near fully functional Sacred 2: Fallen Angel lobby emulator.

---

### Hosting a Custom Lobby

**Requirements:**

- MySQL 5.6.51
- Mono

**Steps:**

```bash
git clone https://github.com/pnxr/sacred2-lobby-emulator.git
cd sacred2-lobby-emulator
msbuild S2Lobby.sln /p:Configuration=Release
cd ./S2Lobby/bin/Release
mono S2Lobby.exe
```

---

### Joining Your Custom Lobby

1. Open File Explorer and go to:

   ```
   %LOCALAPPDATA%\Ascaron Entertainment\Sacred 2
   ```

2. Create a new file named `optionsDefault.txt`.

3. Add the following content (modify `lobby_ip` and `lobby_port` as needed):

   ```ini
   network = {
       lobby_ip = "localhost",
       lobby_port = 6800,
   }
   ```

4. Optional, you can also add these additional values to network to remember your login credentials:

```ini
lobby_name = "username",
lobby_password= "password",
```

---

### Hosting Options

#### Option 1: Dedicated Server

1. Place `starts2gs.cmd` into your game’s `system` directory.
2. Follow the [**Account Creation**](https://github.com/Ki-Tan2934/sacred2-lobby-emulator/edit/2025-revival/Readme.md#account-creation)
 guide below. You'll need for the following launch parameters inside `starts2gs.cmd`:

   ```
   lobby_name=USERNAME -lobby_pwd=PASSWORD
   ```

3. Configure the `starts2gs.cmd` to match your lobby IP/port.
4. Forward necessary ports on your router.
5. Open Command Prompt, navigate to the directory containing `starts2gs.cmd`, and run:

   ```cmd
   starts2gs.cmd
   ```

#### Option 2: In-Game Server

1. Port forward as needed.
2. Log into the lobby server and press create a game.

---

### Account Creation

These are throwaway accounts. Do **not** use real credentials. If you forget your login, just make a new one.

1. Go to the **Multiplayer** screen in Sacred 2.
2. Click `New Account`.
3. Fill out the form:
   - **Username:** `bob`
   - **Password:** `12345`
   - **Email:** Any fake one (e.g., `sacred@is.fun`)
   - **Activation code:** Just enter random numbers.

You’re now ready to host, join, and explore Ancaria with friends!

---

## 🙌 Credits

Original code and research by cocomed on DarkMatters. This repository is for collaborative improvement and testing.

- **pnxr** – Long-time server host and maintainer  
- **sinokon** & **ki_Tan** – 2025 server revival, bug fixes and additional features
