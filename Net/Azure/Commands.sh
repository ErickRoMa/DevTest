#!/bin/bash
#path: /c/Projects/DevTest/Net/Azure
fncLoadAzure(){
    # https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=visual-studio%2Cblob-storage#azurite-executable-file-location
    # Visual Studio Community 2022
    # Note the "\" before the space and bracket characters. These characters must be "escaped" or Bash won't realize the characters are part of a file path.
    /c/Program\ Files/Microsoft\ Visual\ Studio/2022/Community/Common7/IDE/Extensions/Microsoft/Azure\ Storage\ Emulator/azurite.exe
}

fncAzureCosmoCert(){
    # https://learn.microsoft.com/en-us/azure/cosmos-db/how-to-develop-emulator?tabs=windows%2Ccsharp&pivots=api-nosql
    # https://learn.microsoft.com/en-us/troubleshoot/azure/cosmos-db/tools-connectors/emulator
    # If the emulator was started with /AllowNetworkAccess, replace the following with the actual IP address of it:
    EMULATOR_HOST=localhost
    EMULATOR_PORT=8081
    EMULATOR_CERT_PATH=/tmp/cosmos_emulator.cert
    openssl s_client -connect ${EMULATOR_HOST}:${EMULATOR_PORT} </dev/null | sed -ne '/-BEGIN CERTIFICATE-/,/-END CERTIFICATE-/p' > $EMULATOR_CERT_PATH
    # Delete the cert if it already exists
    sudo $JAVA_HOME/bin/keytool -cacerts -delete -alias cosmos_emulator
    # Import the cert
    sudo $JAVA_HOME/bin/keytool -cacerts -importcert -alias cosmos_emulator -file $EMULATOR_CERT_PATH
}

fncAzureDb(){
 azureOption=$1 
 newPath=''
 
 #windowsPath="c:\Program Files\Azure Cosmos DB Emulator\Microsoft.Azure.Cosmos.Emulator.exe"
 windowsPath="c:\Program Files\Azure Cosmos DB Emulator\CosmosDB.Emulator.exe"
 
 if [ $azureOption == 1 ]; then    
    newPath="${windowsPath} /Port=65000" 
 fi
 
 # source Commands.sh ; fncAzureDb 2
 #Mongo 
 if [ $azureOption == 2 ]; then        
    newPath="\"${windowsPath}\" /EnableMongoDb=true /EnableMongoDbEndpoint=4.0 /MongoPort=65200"
 fi

 #Cassandra
 if [ $azureOption == 3 ]; then    
    newPath="${windowsPath} /EnableCassandra=true /EnableCassandraEndpoint /CassandraPort=65300"
 fi

 #Gremlin
 if [ $azureOption == 4 ]; then    
    newPath="${windowsPath} /EnableGremlin=true /EnableGremlinEndpoint /GremlinPort=65400"
 fi

 #Table
 if [ $azureOption == 5 ]; then
   newPath="${windowsPath} /EnableTableEndpoint /TablePort=65500"
 fi
   echo "default url: https://localhost:8081/_explorer/index.html"
   echo "execute command using cmd : ${newPath}"    
}