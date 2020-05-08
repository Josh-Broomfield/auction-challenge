## Example build and execution

```bash
$ docker build -t challenge .
$ docker run -i -v /path/to/challenge/config.json:/auction/config.json challenge < /path/to/challenge/input.json
```

# Auction Coding Challenge

My solution to the sortable coding challenge. Uses the mono docker image because the Windows one is very large. Also uses .NET Framework 4.6.2 for mono compatibility.
Unit tests were written, but I couldn't figure out how to execute them on docker.
