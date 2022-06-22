#!/bin/bash

node -p "require('./test.json').version"

SUB_SCRIPT="version.sh"
echo "#!/bin/bash" > $SUB_SCRIPT
echo export APP_VERSION=`node -p "require('./test.json').version"` >> $SUB_SCRIPT
source "./$SUB_SCRIPT" # 1.2.3.4
#. "$SUB_SCRIPT" # 1.2.3.4 .===source
#sh "$SUB_SCRIPT" # empty - not set
#("./$SUB_SCRIPT") # empty - not set
echo "begin"
printenv APP_VERSION
echo "end"

