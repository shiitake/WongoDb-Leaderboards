# -*- mode: ruby -*-
# vi: set ft=ruby :

Vagrant.configure(2) do |config|  
  config.vm.box = "dansweeting/ubuntu-trusty64-mongo-node"
  config.vm.network "forwarded_port", guest: 27272, host: 27017
  config.vm.provider "virtualbox" do |vb|
     vb.gui = false
  end  
  config.vm.provision "shell", inline: "mkdir -p /data/db && chmod -R ugo+rw /data/db"
  config.vm.provision "shell", inline: "mongod --dbpath /data/db --port 27272 &",
    run: "always"
end
