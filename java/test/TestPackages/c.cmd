@echo off
javac TestPackages.java
jar cvfm TestPackages.jar Manifest.txt TestPackages.class package1\*.class package2\*.class package2\package3\*.class package4\*.class
