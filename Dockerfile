FROM mono:latest

#RUN apt-get upgrade && apt-get update
#RUN mono --version
ADD . /src
WORKDIR /src
RUN nuget restore && msbuild Auction-Challenge.sln /p:Configuration=Release
ENTRYPOINT [ "mono", "/src/Auction-Challenge/bin/Release/Auction-Challenge.exe" ]