git submodule update --init --recursive

apt-get install -y mono-runtime mono-xsp4

mkdir lib
cd lib

sudo mozroots --import --sync

wget http://nuget.org/nuget.exe

mono nuget.exe install nunit

cd ..
