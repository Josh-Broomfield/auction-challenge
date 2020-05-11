## Example build and execution

```bash
$ docker build -t challenge .
$ docker run -i -v /path/to/challenge/config.json:/auction/config.json challenge < /path/to/challenge/input.json
```

## Example unit test build and execution
In the Dockerfile, comment out the first ENTRYPOINT and uncomment the second ENTRYPOINT.

```bash
$ docker build -t challenge .
$ docker run challenge
```

# Auction Coding Challenge

My solution to the sortable coding challenge. Uses .NET Framework 4.6.2 and NUnit for mono compatibility.
