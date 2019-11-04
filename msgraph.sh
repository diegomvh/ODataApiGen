docker run -it --rm -v ${PWD}:/local odataapigen \
  Name=MsGraph \
  Metadata=https://graph.microsoft.com/v1.0/\$metadata \
  Output=/local