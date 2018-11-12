cmake_minimum_required (VERSION 3.5)
project (TestConstructor)

set (TestConstructor_VERSION_MAJOR 1)
set (TestConstructor_VERSION_MINOR 0)

#Can manually add the sources using the set command as follows:
#set (SOURCES main.cpp a.cpp c.cpp d.cpp container.cpp)

#However, the file(GLOB...) allows for wildcard additions:
file(GLOB SOURCES "*.cpp")

add_executable(TestConstructor ${SOURCES})
