FROM mono:latest

#RUN apt-get upgrade && apt-get update
RUN mono --version
ADD . /src
WORKDIR /src
RUN nuget restore
WORKDIR /src/Auction-Challenge
RUN xbuild /p:Configuration=Release
WORKDIR /
#CMD mono /src/Auction-Challenge/bin/Release/Auction-Challenge.exe
ENTRYPOINT [ "mono", "/src/Auction-Challenge/bin/Release/Auction-Challenge.exe" ]