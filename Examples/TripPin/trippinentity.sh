docker run -it --rm -v ${PWD}:/local diegomvh/odataapigen \
  Name=TripPin \
  Metadata=https://services.odata.org/V4/TripPinServiceRW/\$metadata \
  Output=/local
