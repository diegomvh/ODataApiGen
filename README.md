<h1 align="center">OData Angular Code Generator</h1>

## Overview
OData Angular Generator allows generation of API client libraries, server stubs and configuration automatically given an [OData Metadata](https://www.google.com).

### Docker

#### Public Pre-built Docker images

 - [https://hub.docker.com/r/diegomvh/odataapigen](https://hub.docker.com/r/diegomvh/odataapigen) (official CLI)


#### OData Angular Generator CLI Docker Image

The OData Angular Generator image acts as a standalone executable.

To generate code with this image, you'll need to mount a local location as a volume.

Example:

```sh
  docker run -it --rm -v ${PWD}:/local diegomvh/odataapigen \
    Name=MsGraph \
    Metadata=https://graph.microsoft.com/v1.0/\$metadata \
    Output=/local
```

The generated code will be located under `./msgraph` in the current directory.
