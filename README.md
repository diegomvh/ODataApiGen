<h1 align="center">OData Angular Code Generator</h1>

## Overview
OData Angular Generator allows generation of API client libraries, server stubs and configuration automatically given an [OData Metadata](https://www.google.com).

### Docker

#### Public Pre-built Docker images

 - [https://hub.docker.com/r/diegomvh/odataapigen](https://hub.docker.com/r/diegomvh/odataapigen) (official CLI)


#### OData Angular Generator CLI Docker Image

The OData Angular Generator image acts as a standalone executable.

To generate code with this image, you'll need to mount a local location as a volume.

### Example One:

If metadata are in the web like [TripPin](https://services.odata.org/v4/TripPinService/$metadata)

```bash
  docker run -it --rm -v ${PWD}:/local diegomvh/odataapigen \
    Name=TripPin \
    Metadata=https://services.odata.org/v4/TripPinService/$metadata \
    Output=/local
```

The generated code will be located under `./trippin` in the current directory.

### Example Two:

If metadata are in the local file system. Put the `trippin.xml` file on the directory and then run docker on the same directory.

```bash
  docker run -it --rm -v ${PWD}:/local diegomvh/odataapigen \
    Name=TripPin \
    Metadata=file:///local/trippin.xml \
    Output=/local
```

The generated code will be located under `./trippin` in the current directory.

### Example Three:

If metadata are served by yourself on a localhost application. Thanks to [Norm-Cota](https://github.com/diegomvh/ODataApiGen/issues/7)

```bash
  docker run -it --rm -v ${PWD}:/local diegomvh/odataapigen \
    Name=TripPin \
    Metadata=http://host.docker.internal/$metadata \
    Output=/local
```

The generated code will be located under `./trippin` in the current directory.