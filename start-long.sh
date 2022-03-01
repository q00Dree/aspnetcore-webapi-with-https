#!/bin/sh

docker-compose -f docker-compose-long.yml build
docker-compose -f docker-compose-long.yml up -d

docker ps