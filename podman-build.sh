#!/bin/bash

set -ex

IMAGE_NAME="diegomvh/odataapigen"
TAG="${1}"

REGISTRY="docker.io"

podman build -t ${REGISTRY}/${IMAGE_NAME}:${TAG} -t ${REGISTRY}/${IMAGE_NAME}:latest .
podman push ${REGISTRY}/${IMAGE_NAME}:${TAG}
podman push ${REGISTRY}/${IMAGE_NAME}:latest
