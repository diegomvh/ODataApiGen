docker run -it --rm -v /home/diego/Workspace/GitHub/diegomvh/TripPinEntity/src/app:/local diegomvh/odataapigen \
  Name=TripPin \
  Metadata=https://services.odata.org/V4/TripPinServiceRW/\$metadata \
  Output=/local
