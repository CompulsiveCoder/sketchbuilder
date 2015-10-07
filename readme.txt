# sketchbuilder

A browser based arduino sketch builder. Build and upload sketches remotely without touching the code.


Prerequisites

The following libraries are required and will be installed during the setup process...

- wget
- git
- mono-runtime 
- mono-xsp4 (web server)

The mono-runtime and mono-xsp4 libraries are quite large so they will take a while to install, especially on a slower machine such as Raspberry Pi.


Installation

To install on a ubuntu/debian machine...

1) Open a terminal window
  CTRL+ALT+T

2) Navigate to the desktop (or any location you choose)
  cd ~/Desktop

3) Install wget (if not already installed)
<<<<<<< HEAD
  sudo apt-get install -y wget

4) Use wget to download the install and run script:
  wget --no-cache --no-check-certificate https://raw.githubusercontent.com/CompulsiveCoder/sketchbuilder/master/run-from-git.sh
=======
  sudo apt-get install wget

4) Use wget to download the install and run script:
  wget https://raw.githubusercontent.com/CompulsiveCoder/sketchbuilder/master/run-from-git.sh
>>>>>>> files

5) Launch the install and run script
  sudo sh run-from-git.sh

6) Wait for a message that looks like this (it might take a while):

"Listening on address: 0.0.0.0
Root directory: /home/[user]/projects/sketchbuilder/src/WWW
Listening on port: 9000 (non-secure)
Hit Return to stop the server."

<<<<<<< HEAD
7) Leave this window open at that message until you want to stop the server.
To stop the server without closing the window hit Enter.

8) Take note of the port number at "Listening on port: [portNumber]". It may be one of the following (or it may be something else)
  - 8080
  - 9000

9) Once the server has started (and displays the message above) open the browser to
  http://localhost:8080
(Change the port to the one displayed on the web server message mentioned above.)

The sketchbuilder application should load and you can start using it.

10) Plug in your arduino and you should be able to upload sketches.
Note: If the arduino can't be detected then refresh the page and it'll try again.


Launch/Run

To launch the sketchbuilder app...

Note: The instructions above (and run-from-git.sh script) installed and launched the sketchbuilder app, but if you stop the server and want to re-launch it at a later point follow these instructions. It will launch the application more quickly than the run-from-git.sh script because it skips the installation step.

1) Open a terminal window
  CTRL+ALT+T

2) Navigate to the sketchbuilder directory
  ~/Desktop/sketchbuilder

=======
7) Leave this window open at that message until you want to stop the eserver.
To stop the server without closing the window hit Enter.

8) Take note of the port number at "Listening on port: [portNumber]". It may be one of the following (or it may be something else)
  - 8080
  - 9000

9) Once the server has started and display the message above, open the browser to
  http://localhost:8080
or
  http://localhost:9000
(Change the port to the one displayed on the web server message mentioned above.)

The web application should load and you can start using it.

10) Plug in your arduino and you should be able to upload sketches.
Note: If the arduino can't be detected then refresh the page and it'll try again.


Launch/Run

To launch the sketchbuilder app...

Note: The instructions above (and run-from-git.sh script) installed and launched the sketchbuilder app, but if you stop the server and want to re-launch it at a later point follow these instructions. It will launch the application more quickly than the run-from-git.sh script because it skips the installation step.

1) Open a terminal window
  CTRL+ALT+T

2) Navigate to the sketchbuilder directory
  ~/Desktop/sketchbuilder

>>>>>>> files
3) Run the launch.sh script
  sudo sh launch.sh

4) Follow steps 6-10 of the install guide (above) to open sketchbuilder via the browser

