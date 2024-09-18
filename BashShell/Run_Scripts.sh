#!/bin/bash

function updateSource(){
    #Update Sources
    sudo apt-get update
}

function upgradeClamAv(){
	sudo apt remove clamav -y
	installClamAv
}
function installClamAv(){
    updateSource

    #Intall ClamAV
    sudo apt-get install clamav clamav-daemon -y

    clamscan --version
}

function updateClamAv(){
    #Stop Instance
    sudo systemctl stop clamav-freshclam
    
    #Update DB Definition
    sudo freshclam

    #Start Instance
    sudo systemctl enable clamav-daemon
    sudo systemctl start clamav-daemon

    #Current Directory
    pwd 

    # runClamAv
}

function runClamAv(){
   echo "::::::::::::::::::::::::::::::::ClamAv Scan"
    #Scan
      sudo clamscan --infected --remove --recursive /home
    # sudo clamdscan --fdpass --infected --remove --recursive /home
}

function updateLinux(){
    echo "::::::::::::::::::::::::::::::::Update Source"
    sudo apt update
    echo "::::::::::::::::::::::::::::::::Upgrade"
    sudo apt upgrade -y
    echo "::::::::::::::::::::::::::::::::Autoremove"
    sudo apt autoremove
    echo "::::::::::::::::::::::::::::::::AutoClean"
    sudo apt autoclean
    echo "::::::::::::::::::::::::::::::::Clean"
    sudo apt clean
}

function updateSnap(){
   echo "::::::::::::::::::::::::::::::::Update Snap Store"
   snap-store --quit
   sudo killall -s KILL snapd
   sudo snap refresh
}

function updateAll(){
	updateLinux
	updateSnap
	updatePodman
	updateClamAv
}

function installJquery(){
 sudo apt install libjs-jquery -y
 node -v
}

function installNodeJs(){
#curl -fsSL https://deb.nodesource.com/setup_20.x | sudo -E bash - &&\
#sudo apt-get install -y nodejs
sudo apt install nodejs -y
sudo apt install npm -y
}

function removeNodeJs () {
 sudo apt remove nodejs -y
 sudo apt purge nodejs -y
 node -v
}

function dotNet(){
 dotnet --list-sdks
 dotnet --list-runtimes
}

function installDotNet(){
 updateLinux

 sudo apt-get install -y aspnetcore-runtime-7.0
 sudo apt-get install -y dotnet-runtime-7.0
 sudo apt-get install -y dotnet-sdk-7.0
}

function installJava(){
 updateLinux
 sudo apt install default-jre -y
 sudo apt install default-jdk -y
}

function createNewConsoleApp(){
  appName = $1
  
  dotnet new console -n $1 -f net7.0
}

function createNewWebApi(){
  apiName = $1
  dotnet new webapi -o $1
  cd $1
  dotnet add package Microsoft.EntityFrameworkCode.InMemory
  code -r ../$1 

  dotnet dev-cert  
}

function addNewController(){
 projectName = $1
 controllerName = $2
 addScaffoldController $projectName $controllerName
}

function addReferenceScaffoldController(){
 addPackage "Microsoft.VisualStudio.Web.CodeGeneration.Design" "7.0.0"
 addPackage "Microsoft.EntityFrameworkCore.Design" "7.0.0"
 addPackage "Microsoft.EntityFrameworkCore.SqlServer" "7.0.0"

 dotnet tool uninstall -g dotnet-aspnet-codegenerator
 dotnet tool install -g dotnet-aspnet-codegenerator
}

function addScaffoldController(){
 projectName = $1
 controllerName = $2
 contextName = projectNameContext
 
 dotnet-aspnet-codegenerator controller -name $controllerName -async -api -m $projectName -dc $contextName -outDir Controllers
}

function createCertTrustApps(){
  dotnet dev-certs https --trust
}

function addPackage(){
 packageName = $1
 version = $2
 if [ -z "$version" ] 
 then 
  dotnet add package $packageName
 else
  dotnet add package $packageName -b $version
 fi 
 
}

function createSshKey(){

 #create ssh file at /home/<user>/.ssh/id_<algorithm>XXX | id_<algorithm>XXX.pub
 ssh-keygen -t ed25519 -C "rome0918@gmail.com"
 
 #Display PID SSH server
 eval "$(ssh-agent -s)"
 
 # add identity to ssh server
 # ssh-add id_<algorithm>XXX
 
 # Display public key should be add into Setting/SSH and PGP Key
 # cat id_<algorithm>XXX.pub
 
}

function enableDisableWydeland(){
 sudo nano /etc/gdm3/custom.conf
 #Add Comment to Enable
 #WaylandEnable=false

}

function updatePodman(){
 #install podman desktop : https://podman-desktop.io/docs/installation/linux-install
 flatpak update --user io.podman_desktop.PodmanDesktop
}

#How run
# source Run_Scripts; runClamAv
# source Run_Scripts; updateLinux

function enableScreenSaver(){
 xscreensaver-command -activate
 
}
function disableScreenSaver(){
 xscreensaver-command -deactivate
 
}

/*
sudo apt install usb-creator-gtk
usb-creator-gtk

*/
