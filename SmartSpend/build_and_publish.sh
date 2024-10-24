#!/bin/bash  
  
# Variables  
IMAGE_NAME="scab1001/smartspend"  
TAG="latest"  
  
# Build the Docker image  
docker build -t ${IMAGE_NAME}:${TAG} .  
  
# Tag the Docker image  
docker tag ${IMAGE_NAME}:${TAG} ${IMAGE_NAME}:${TAG}  
  
# Push the Docker image to Docker Hub  
docker push ${IMAGE_NAME}:${TAG}  
