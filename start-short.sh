#!/bin/sh

chmod +x ./scripts/build_api.sh

if ./scripts/build_api.sh
then
	echo "[INFO] Simple.Server is built."
else
	echo "[ERROR] Some error occured while building Simple.Server!"
	exit 1
fi

docker-compose -f docker-compose-short.yml build
docker-compose -f docker-compose-short.yml up -d

docker ps