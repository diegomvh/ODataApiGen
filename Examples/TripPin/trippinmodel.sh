docker run -it --rm -v ${PWD}:/local diegomvh/odataapigen \
  Name=TripPin \
  Model=true \
  Metadata=https://services.odata.org/V4/TripPinServiceRW/\$metadata \
  Output=/local
