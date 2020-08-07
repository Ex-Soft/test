@echo off
java -classpath . TestPackages
java -jar TestPackages.jar
java -cp "./TestPackages.jar" TestPackages
pause > nul
