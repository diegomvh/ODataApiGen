docker run -it --rm -v ${PWD}:/local diegomvh/odataapigen \
  Name=MsGraph \
  Metadata=file:///local/graph.xml \
  Output=/local
