# sketchbuilder
A browser based arduino sketch builder. Build and upload sketches remotely without touching the code.

To install to a new location run the following 2 commands in the terminal:

wget https://raw.githubusercontent.com/CompulsiveCoder/sketchbuilder/master/run-from-git.sh

sudo sh run-from-git.sh

Wait for a message that looks like this (it might take a while):

Listening on address: 0.0.0.0
Root directory: /home/[user]/projects/sketchbuilder/src/WWW
Listening on port: 9000 (non-secure)
Hit Return to stop the server.

When you want to end the server hit Enter.
Leave the window open unless you want to end the web server.

Once the server has started open the browser to
http://localhost:9000

The web application should load and you can start using it.
Plug in your arduino and you should be able to upload sketches.

To launch the application after the files have been downloaded go to the sketchbuilder folder
cd sketchbuilder

Run the launch.sh script (as root; ie use sudo)
sudo sh launch.sh

It should display the same server welcome message as above, and indicates to open browser.
