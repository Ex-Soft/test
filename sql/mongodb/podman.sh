sudo mkdir -p /mongo/data
sudo chown -R 1000:1000 /mongo/data

sudo mkdir -p /mongo/config

sudo podman run -d --name mongo \
    -e MONGO_INITDB_ROOT_USERNAME=root \
    -e MONGO_INITDB_ROOT_PASSWORD=password \
    -v /mongo/data:/data/db \
    -v /mongo/config:/data/configdb \
    -p 27017:27017 \
    mongo

sudo podman ps
