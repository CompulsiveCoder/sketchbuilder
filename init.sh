git submodule update --init --recursive

apt-get install mono-complete mono-devel mono-xsp4

mkdir lib
cd lib

sudo mozroots --import --sync

wget http://nuget.org/nuget.exe

mono nuget.exe install nunit

cd ..
